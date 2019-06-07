using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Lote
    {
        public string LoteId { get; set; }
        public decimal StockInicial { get; set; }
        public string ProductoId { get; set; }
        public DateTime? Caducidad { get; set; }
        public decimal? StockRestante { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string EstadoDocId { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
