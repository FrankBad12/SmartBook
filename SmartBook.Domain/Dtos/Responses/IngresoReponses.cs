using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Responses
{
    public record IngresoResponse
    (
        int Id,
        DateTime Fecha,
        int LibroId,
        string LibroNombre,
        int LoteId,
        string LoteCodigo,
        int Unidades,
        decimal ValorCompra,
        decimal ValorVentaPublico,
        DateTime FechaCreacion
    );

}
