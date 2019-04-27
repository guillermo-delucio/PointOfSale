using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class ProductoImpuesto
    {
        public string ProductoId { get; set; }
        public string ImpuestoId { get; set; }

        public virtual Impuesto Impuesto { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
