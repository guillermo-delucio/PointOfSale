using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Impuesto
    {
        public Impuesto()
        {
            ProductoImpuesto = new HashSet<ProductoImpuesto>();
        }

        public string ImpuestoId { get; set; }
        public int? Tasa { get; set; }

        public virtual ICollection<ProductoImpuesto> ProductoImpuesto { get; set; }
    }
}
