using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Nivel { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string? Editorial { get; set; }
        public string? Edicion { get; set; }

        public int StockTotal { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        // Relaciones
        public ICollection<Ingreso>? Ingresos { get; set; }
    }

}
