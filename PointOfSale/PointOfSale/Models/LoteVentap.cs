using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class LoteVentap
    {
        public int LotepId { get; set; }
        public int LoteId { get; set; }
        public string ProductoId { get; set; }
        public int VentaId { get; set; }
        public decimal? Cantidad { get; set; }
        public string NoLote { get; set; }

        public virtual Lote Lote { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
