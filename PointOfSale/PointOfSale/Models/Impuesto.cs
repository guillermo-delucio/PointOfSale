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
        public decimal Tasa { get; set; }
        public bool IsDeleted { get; set; }
        public string CImpuesto { get; set; }

        public virtual ICollection<ProductoImpuesto> ProductoImpuesto { get; set; }
    }
}
