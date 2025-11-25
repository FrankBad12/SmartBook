using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Responses
{
    public record VentaResponse
    (
        int Id,
        string NumeroReciboPago,
        DateTime Fecha,
        int ClienteId,
        string ClienteNombre,
        int UsuarioId,
        string UsuarioNombre,
        string? Observaciones,
        DateTime FechaCreacion
    );

}
