using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Responses
{
    public record ClienteResponses
    (
        int Id,
        string Identificacion,
        string Nombre,
        string Email,
        string Celular,
        DateTime FechaNacimiento,
        DateTime FechaCreacion,
        DateTime? FechaActualizacion

    );
}
