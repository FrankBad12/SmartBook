using MySqlX.XDevAPI;
using SmartBook.Application.Extensions;
using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Dtos.Responses;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Exceptions;
using SmartBook.Persistence.Repositories.Interfaces;

namespace SmartBook.Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteResponses? Crear(CrearClienteRequest request)
        {
            // Validaciones de reglas de negocio
            var existeIdentificacion = _clienteRepository.ValidarIdentificacion(request.Identificacion);
            if (existeIdentificacion)
            {
                throw new BussinesRuleException("Ya existe un cliente con esa identificación");
            }

            var existeEmail = _clienteRepository.ValidarEmail(request.Email);
            if (existeEmail)
            {
                throw new BussinesRuleException("Ya existe un cliente con ese email");
            }

            var existeCelular = _clienteRepository.ValidarCelular(request.Celular);
            if (existeCelular)
            {
                throw new BussinesRuleException("Ya existe un cliente con ese celular");
            }

            // Validar edad mínima (opcional - ejemplo: 13 años)
            var edad = DateTime.Now.Year - request.FechaNacimiento.Year;
            if (request.FechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;

            if (edad < 13)
            {
                throw new BussinesRuleException("El cliente debe tener al menos 13 años");
            }

            var cliente = new Cliente
            {
                Identificacion = request.Identificacion.Trim(),
                Nombre = request.Nombre.Sanitize().RemoveAccents(),
                Email = request.Email.ToLower().Trim(),
                Celular = request.Celular.Trim(),
                FechaNacimiento = request.FechaNacimiento,
                FechaCreacion = DateTime.Now
            };

            _clienteRepository.Insertar(cliente);

            var response = new ClienteResponses(
                cliente.Id,
                cliente.Identificacion,
                cliente.Nombre,
                cliente.Email,
                cliente.Celular,
                cliente.FechaNacimiento,
                cliente.FechaCreacion,
                cliente.FechaActualizacion
            );

            return response;
        }

        public bool Borrar(int id)
        {
            return _clienteRepository.Eliminar(id);
        }

        public IEnumerable<ClienteResponses> Consultar(string? nombre, string? identificacion, string? email)
        {
            var clientes = _clienteRepository.Consultar();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(nombre))
            {
                clientes = clientes.Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(identificacion))
            {
                clientes = clientes.Where(c => c.Identificacion.Contains(identificacion));
            }

            if (!string.IsNullOrEmpty(email))
            {
                clientes = clientes.Where(c => c.Email.Contains(email, StringComparison.OrdinalIgnoreCase));
            }

            return clientes.Select(c => new ClienteResponses(
                c.Id,
                c.Identificacion,
                c.Nombre,
                c.Email,
                c.Celular,
                c.FechaNacimiento,
                c.FechaCreacion,
                c.FechaActualizacion
            ));
        }

        public ClienteResponses? Consultar(int id)
        {
            var cliente = _clienteRepository.Consultar(id);

            if (cliente is null)
            {
                return null;
            }

            return new ClienteResponses(
                cliente.Id,
                cliente.Identificacion,
                cliente.Nombre,
                cliente.Email,
                cliente.Celular,
                cliente.FechaNacimiento,
                cliente.FechaCreacion,
                cliente.FechaActualizacion
            );
        }

        public bool Actualizar(int id, ActualizarClienteRequest request)
        {
            return _clienteRepository.Actualizar(id, request);
        }
    }
}