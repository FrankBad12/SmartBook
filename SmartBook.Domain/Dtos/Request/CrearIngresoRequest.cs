using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Request
{
    public record CrearIngresoRequest
    (

        int LibroId,
        int LoteId,
        int Unidades,
        decimal ValorCompra,
        decimal ValorVentaPublico

    );
}
