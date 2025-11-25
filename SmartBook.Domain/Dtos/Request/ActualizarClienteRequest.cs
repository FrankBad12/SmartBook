using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Request
{
    public record ActualizarClienteRequest
    (

        string Nombre,
        string Email,
        string Celular,
        DateTime FechaNacimiento

    );
}
