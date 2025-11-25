using SmartBook.Application.Extensions;
using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Dtos.Responses;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Exceptions;
using SmartBook.Persistence.Repositories.Interfaces;

namespace SmartBook.Application.Services
{
    public class LibroService
    {
        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public LibroResponses? Crear(CrearLibroRequest request)
        {
            // Validar que no exista un libro con la misma combinación
            var existe = _libroRepository.ValidarLibroUnico(
                request.Nombre,
                request.Nivel,
                request.Tipo,
                request.Edicion
            );

            if (existe)
            {
                throw new BussinesRuleException("Ya existe un libro con esa combinación de Nombre, Nivel, Tipo y Edición");
            }

            var libro = new Libro
            {
                Nombre = request.Nombre.Sanitize().RemoveAccents(),
                Nivel = request.Nivel.Trim(),
                Tipo = request.Tipo.Trim(),
                Editorial = request.Editorial?.Trim(),
                Edicion = request.Edicion?.Trim(),
                StockTotal = 0,
                FechaCreacion = DateTime.Now
            };

            _libroRepository.Insertar(libro);

            var response = new LibroResponses(
                libro.Id,
                libro.Nombre,
                libro.Nivel,
                libro.Tipo,
                libro.Editorial,
                libro.Edicion,
                libro.StockTotal,
                libro.FechaCreacion,
                libro.FechaActualizacion
            );

            return response;
        }

        public bool Borrar(int id)
        {
            return _libroRepository.Eliminar(id);
        }

        public IEnumerable<LibroResponses> Consultar(string? nombre, string? nivel, string? tipo)
        {
            var libros = _libroRepository.Consultar();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(nombre))
            {
                libros = libros.Where(l => l.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(nivel))
            {
                libros = libros.Where(l => l.Nivel.Contains(nivel, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                libros = libros.Where(l => l.Tipo.Contains(tipo, StringComparison.OrdinalIgnoreCase));
            }

            return libros.Select(l => new LibroResponses(
                l.Id,
                l.Nombre,
                l.Nivel,
                l.Tipo,
                l.Editorial,
                l.Edicion,
                l.StockTotal,
                l.FechaCreacion,
                l.FechaActualizacion
            ));
        }

        public LibroResponses? Consultar(int id)
        {
            var libro = _libroRepository.Consultar(id);

            if (libro is null)
            {
                return null;
            }

            return new LibroResponses(
                libro.Id,
                libro.Nombre,
                libro.Nivel,
                libro.Tipo,
                libro.Editorial,
                libro.Edicion,
                libro.StockTotal,
                libro.FechaCreacion,
                libro.FechaActualizacion
            );
        }

        public bool Actualizar(int id, ActualizarLibroRequest request)
        {
            return _libroRepository.Actualizar(id, request);
        }
    }
}