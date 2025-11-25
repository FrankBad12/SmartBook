using SmartBook.Domain.Dtos.Request;
using SmartBook.Domain.Entities;

namespace SmartBook.Persistence.Repositories.Interfaces
{
    public interface ILibroRepository
    {
        bool Insertar(Libro libro);
        bool ValidarLibroUnico(string nombre, string nivel, string tipo, string? edicion);
        Libro? Consultar(int id);
        IEnumerable<Libro> Consultar();
        bool Actualizar(int id, ActualizarLibroRequest actualizarLibro);
        bool Eliminar(int id);
        void BorrarTodos();
    }
}