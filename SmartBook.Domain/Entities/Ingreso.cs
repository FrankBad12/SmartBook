using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Ingreso
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int LibroId { get; set; }
        public Libro Libro { get; set; } = null!;

        public int LoteId { get; set; }
        public Lote Lote { get; set; } = null!;

        public int Unidades { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVentaPublico { get; set; }

        public DateTime FechaCreacion { get; set; }
    }

}
