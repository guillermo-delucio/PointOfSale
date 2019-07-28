using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Traspasop
    {
        public int TraspasopId { get; set; }
        public int TraspasoId { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string LoteId { get; set; }
        public string ImpuestoId1 { get; set; }
        public string ImpuestoId2 { get; set; }
        public decimal? ImporteImpuesto1 { get; set; }
        public decimal? ImporteImpuesto2 { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public virtual Traspaso Traspaso { get; set; }
    }
}
