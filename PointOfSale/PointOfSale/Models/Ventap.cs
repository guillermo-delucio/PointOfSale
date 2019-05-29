using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Ventap
    {
        public int Ventap1 { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Descuento { get; set; }
        public int CantImpuestos { get; set; }
        public decimal? Impuesto1 { get; set; }
        public decimal? Impuesto2 { get; set; }
        public decimal? Impuesto3 { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Total { get; set; }
        public string LoteId { get; set; }

        public virtual Venta Venta { get; set; }
    }
}
