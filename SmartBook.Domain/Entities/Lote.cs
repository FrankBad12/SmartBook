using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Lote
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;  // Ej: 2025-1

        // Relación con ingresos
        public ICollection<Ingreso>? Ingresos { get; set; }
    }

}
