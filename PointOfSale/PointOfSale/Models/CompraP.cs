using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Comprap
    {
        public int ComprapId { get; set; }
        public int CompraId { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Impuesto1 { get; set; }
        public decimal Impuesto2 { get; set; }
        public decimal Impuesto3 { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Importe { get; set; }
        public int CantImpuestos { get; set; }

        public virtual Compra Compra { get; set; }
    }
}
