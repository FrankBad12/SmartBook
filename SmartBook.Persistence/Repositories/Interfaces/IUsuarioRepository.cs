using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Persistence.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {

        bool Insertar(Usuario usuario);
        bool ValidarIdentificacion(string identificacion);
        bool ValidarEmail(string email);
        Usuario? Consultar(string id);
        IEnumerable<Usuario> Consultar();
        bool Actualizar(string id, ActualizarUsuarioRequest actualizarUsuario);
        bool Eliminar(string id);
        void BorrarTodos();

    }
}
