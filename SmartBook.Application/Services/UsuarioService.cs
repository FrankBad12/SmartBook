using SmartBook.Application.Extensions;
using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Dtos.Responses;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using SmartBook.Domain.Exceptions;
using SmartBook.Persistence.Repositories.Interfaces;
namespace SmartBook.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioResponses? Crear(CrearUsuarioRequest request)
        {
            // Validaciones de reglas de negocio
            var existeIdentificacion = _usuarioRepository.ValidarIdentificacion(request.Identificacion);
            if (existeIdentificacion)
            {
                throw new BussinesRuleException("Ya existe un usuario con esa identificación");
            }

            var existeEmail = _usuarioRepository.ValidarEmail(request.Email);
            if (existeEmail)
            {
                throw new BussinesRuleException("Ya existe un usuario con ese email");
            }

            var usuario = new Usuario
            {
                Id = DateTime.Now.Ticks.ToString(),
                Identificacion = request.Identificacion.Sanitize().RemoveAccents(),
                Nombre = request.Nombre.Sanitize().RemoveAccents(),
                Email = request.Email.ToLower().Trim(),
                ContrasenaHash = request.Contrasena, // Considera hashear la contraseña aquí
                Rol = request.Rol,
                CuentaConfirmada = false,
                Activo = ActivoUsuario.Activo,
                FechaCreacion = DateTime.Now
            };

            _usuarioRepository.Insertar(usuario);

            var response = new UsuarioResponses(
                usuario.Id,
                usuario.Identificacion,
                usuario.Nombre,
                usuario.Email,
                usuario.Rol,
                usuario.CuentaConfirmada,
                usuario.Activo,
                usuario.FechaCreacion,
                usuario.FechaActualizacion
            );

            return response;
        }

        public bool Borrar(string id)
        {
            return _usuarioRepository.Eliminar(id);
        }

        public IEnumerable<UsuarioResponses> Consultar(string? nombre, string? email)
        {
            var usuarios = _usuarioRepository.Consultar();

            // Aplicar filtros si se proporcionan
            if (!string.IsNullOrEmpty(nombre))
            {
                usuarios = usuarios.Where(u => u.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(email))
            {
                usuarios = usuarios.Where(u => u.Email.Contains(email, StringComparison.OrdinalIgnoreCase));
            }

            return usuarios.Select(u => new UsuarioResponses(
                u.Id,
                u.Identificacion,
                u.Nombre,
                u.Email,
                u.Rol,
                u.CuentaConfirmada,
                u.Activo,
                u.FechaCreacion,
                u.FechaActualizacion
            ));
        }

        public UsuarioResponses? Consultar(string id)
        {
            var usuario = _usuarioRepository.Consultar(id);

            if (usuario is null)
            {
                return null;
            }

            return new UsuarioResponses(
                usuario.Id,
                usuario.Identificacion,
                usuario.Nombre,
                usuario.Email,
                usuario.Rol,
                usuario.CuentaConfirmada,
                usuario.Activo,
                usuario.FechaCreacion,
                usuario.FechaActualizacion
            );
        }

        public bool Actualizar(string id, ActualizarUsuarioRequest request)
        {
            return _usuarioRepository.Actualizar(id, request);
        }
    }


}
    



 
