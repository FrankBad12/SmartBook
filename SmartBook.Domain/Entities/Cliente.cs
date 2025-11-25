using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        // Relación con ventas
        public ICollection<Venta>? Ventas { get; set; }
    }

}
