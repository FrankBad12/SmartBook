using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Request
{
    public record CrearLibroRequest
    (
        string Nombre,
        string Nivel,
        string Tipo,
        string? Editorial,
        string? Edicion

    );
}
