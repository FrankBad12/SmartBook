using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        bool Insertar(Cliente cliente);
        bool ValidarIdentificacion(string identificacion);
        bool ValidarEmail(string email);
        bool ValidarCelular(string celular);
        Cliente? Consultar(int id);
        IEnumerable<Cliente> Consultar();
        bool Actualizar(int id, ActualizarClienteRequest actualizarCliente);
        bool Eliminar(int id);
        void BorrarTodos();
    }
}