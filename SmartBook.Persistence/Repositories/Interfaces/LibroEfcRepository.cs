using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Entities;
using SmartBook.Persistence.DbContexts;
using SmartBook.Persistence.Repositories.Interfaces;

namespace SmartBook.Persistence.Repositories
{
    public class LibroEfcRepository : ILibroRepository
    {
        private readonly SmartBookDbContext _context;

        public LibroEfcRepository(SmartBookDbContext context)
        {
            _context = context;
        }

        public bool Insertar(Libro libro)
        {
            /*
             INSERT INTO Libros 
             VALUES(@id, @nombre, @nivel, @tipo, @editorial, @edicion, @stockTotal, @fechaCreacion, @fechaActualizacion)
             */
            _context.Libros.Add(libro);
            return _context.SaveChanges() > 0;
        }

        public bool ValidarLibroUnico(string nombre, string nivel, string tipo, string? edicion)
        {
            /*
             SELECT COUNT(id) FROM Libros
             WHERE Nombre = @nombre 
               AND Nivel = @nivel 
               AND Tipo = @tipo 
               AND (Edicion = @edicion OR (Edicion IS NULL AND @edicion IS NULL))
             */
            return _context.Libros.Any(l =>
                l.Nombre == nombre &&
                l.Nivel == nivel &&
                l.Tipo == tipo &&
                l.Edicion == edicion
            );
        }

        public Libro? Consultar(int id)
        {
            /*
             SELECT * FROM Libros WHERE Id = @id
             */
            return _context.Libros.Find(id);
        }

        public IEnumerable<Libro> Consultar()
        {
            /*
             SELECT * FROM Libros
             */
            return _context.Libros.ToList();
        }

        public bool Actualizar(int id, ActualizarLibroRequest actualizarLibro)
        {
            var libro = _context.Libros.Find(id);
            if (libro is null)
            {
                return false;
            }

            // Actualizar propiedades
            libro.Nombre = actualizarLibro.Nombre;
            libro.Nivel = actualizarLibro.Nivel;
            libro.Tipo = actualizarLibro.Tipo;
            libro.Editorial = actualizarLibro.Editorial;
            libro.Edicion = actualizarLibro.Edicion;
            libro.FechaActualizacion = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool Eliminar(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro is not null)
            {
                _context.Libros.Remove(libro);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public void BorrarTodos()
        {
            _context.Libros.RemoveRange(_context.Libros);
            _context.SaveChanges();
        }
    }
}