using SmartBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Dtos.Responses
{
    public record UsuarioResponses
    (
      string Id,
      string Identificacion,
      string Nombre,
      string Email,
      RolUsuario Rol,
      bool CuentaConfirmada,
      ActivoUsuario Activo,
      DateTime FechaCreacion,
      DateTime? FechaActualizacion

    );
}
