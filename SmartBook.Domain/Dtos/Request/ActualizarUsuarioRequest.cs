using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Request
{
    public record ActualizarUsuarioRequest
    (
        string Nombre,
        string Email,
        RolUsuario Rol,
        ActivoUsuario Activo

    );
}
