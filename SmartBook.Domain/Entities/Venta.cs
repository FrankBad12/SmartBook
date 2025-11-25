using System;
using System.Collections.Generic;

namespace SmartBook.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public string NumeroReciboPago { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }  // Nullable

        public string UsuarioId { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }  // Nullable

        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}