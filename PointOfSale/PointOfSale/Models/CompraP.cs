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
        public string LaboratorioId { get; set; }
        public decimal? Stock { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioCaja { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Impuesto1 { get; set; }
        public decimal? Impuesto2 { get; set; }
        public decimal? ImporteParcial { get; set; }
        public decimal? ImpuestoParcial { get; set; }
        public decimal? ImporteParcialNeto { get; set; }
        public int? CantImpuestos { get; set; }
        public string Lote { get; set; }
        public DateTime? Caducidad { get; set; }

        public virtual Compra Compra { get; set; }
    }
}
