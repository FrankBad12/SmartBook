using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Entities;
using SmartBook.Persistence.DbContexts;
using SmartBook.Persistence.Repositories.Interfaces;

namespace SmartBook.Persistence.Repositories
{
    public class ClienteEfcRepository : IClienteRepository
    {
        private readonly SmartBookDbContext _context;

        public ClienteEfcRepository(SmartBookDbContext context)
        {
            _context = context;
        }

        public bool Insertar(Cliente cliente)
        {
            /*
             INSERT INTO Clientes 
             VALUES(@id, @identificacion, @nombre, @email, @celular, @fechaNacimiento, @fechaCreacion, @fechaActualizacion)
             */
            _context.Clientes.Add(cliente);
            return _context.SaveChanges() > 0;
        }

        public bool ValidarIdentificacion(string identificacion)
        {
            /*
             SELECT COUNT(id) FROM Clientes
             WHERE Identificacion = @identificacion
             */
            return _context.Clientes.Any(c => c.Identificacion == identificacion);
        }

        public bool ValidarEmail(string email)
        {
            /*
             SELECT COUNT(id) FROM Clientes
             WHERE Email = @email
             */
            return _context.Clientes.Any(c => c.Email == email);
        }

        public bool ValidarCelular(string celular)
        {
            /*
             SELECT COUNT(id) FROM Clientes
             WHERE Celular = @celular
             */
            return _context.Clientes.Any(c => c.Celular == celular);
        }

        public Cliente? Consultar(int id)
        {
            /*
             SELECT * FROM Clientes WHERE Id = @id
             */
            return _context.Clientes.Find(id);
        }

        public IEnumerable<Cliente> Consultar()
        {
            /*
             SELECT * FROM Clientes
             */
            return _context.Clientes.ToList();
        }

        public bool Actualizar(int id, ActualizarClienteRequest actualizarCliente)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente is null)
            {
                return false;
            }

            // Actualizar propiedades
            cliente.Nombre = actualizarCliente.Nombre;
            cliente.Email = actualizarCliente.Email;
            cliente.Celular = actualizarCliente.Celular;
            cliente.FechaNacimiento = actualizarCliente.FechaNacimiento;
            cliente.FechaActualizacion = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool Eliminar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente is not null)
            {
                _context.Clientes.Remove(cliente);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public void BorrarTodos()
        {
            _context.Clientes.RemoveRange(_context.Clientes);
            _context.SaveChanges();
        }
    }
}