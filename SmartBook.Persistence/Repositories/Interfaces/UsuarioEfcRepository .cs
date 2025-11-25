using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using SmartBook.Persistence.DbContexts;
using SmartBook.Persistence.Repositories.Interfaces;

namespace SmartBook.Persistence.Repositories
{
    public class UsuarioEfcRepository : IUsuarioRepository
    {
        private readonly SmartBookDbContext _context;

        public UsuarioEfcRepository(SmartBookDbContext context)
        {
            _context = context;
        }

        public bool Insertar(Usuario usuario)
        {
            /*
             INSERT INTO usuarios 
             VALUES(@id, @identificacion, @nombre, @email, @contrasenaHash, @rol, 
                    @cuentaConfirmada, @activo, @fechaCreacion, @fechaActualizacion)
             */
            _context.Usuarios.Add(usuario);
            return _context.SaveChanges() > 0;
        }

        public bool ValidarIdentificacion(string identificacion)
        {
            /*
             SELECT COUNT(id) FROM usuarios
             WHERE identificacion = @identificacion
             */
            return _context.Usuarios.Any(u => u.Identificacion == identificacion);
        }

        public bool ValidarEmail(string email)
        {
            /*
             SELECT COUNT(id) FROM usuarios
             WHERE email = @email
             */
            return _context.Usuarios.Any(u => u.Email == email);
        }

        public Usuario? Consultar(string id)
        {
            /*
             SELECT * FROM usuarios WHERE id = @id
             */
            return _context.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> Consultar()
        {
            /*
             SELECT * FROM usuarios
             */
            return _context.Usuarios.ToList();
        }

        public bool Actualizar(string id, ActualizarUsuarioRequest actualizarUsuario)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario is null)
            {
                return false;
            }

            // Actualizar propiedades
            usuario.Nombre = actualizarUsuario.Nombre;
            usuario.Email = actualizarUsuario.Email;
            usuario.Rol = actualizarUsuario.Rol;
            usuario.FechaActualizacion = DateTime.Now;

            // Si actualizas otros campos, agrégalos aquí

            return _context.SaveChanges() > 0;
        }

        public bool Eliminar(string id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario is not null)
            {
                _context.Usuarios.Remove(usuario);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public void BorrarTodos()
        {
            _context.Usuarios.RemoveRange(_context.Usuarios);
            _context.SaveChanges();
        }
    }
}