using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Comprap
    {
        public int CompraPid { get; set; }
        public int CompraId { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Descuento { get; set; }
        public decimal Precio { get; set; }
        public int CantImpuestos { get; set; }
        public int Impuesto1 { get; set; }
        public int Impuesto2 { get; set; }
        public int Impuesto3 { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Importe { get; set; }
        public bool IsDeleted { get; set; }
    }
}
