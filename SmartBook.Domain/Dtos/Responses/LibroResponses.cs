using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Responses
{
    public record LibroResponses
    (
        int Id,
        string Nombre,
        string Nivel,
        string Tipo,
        string? Editorial,
        string? Edicion,
        int StockTotal,
        DateTime FechaCreacion,
        DateTime? FechaActualizacion

    );
}
