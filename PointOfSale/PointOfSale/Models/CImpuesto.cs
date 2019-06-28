using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CImpuesto
    {
        public CImpuesto()
        {
            Impuesto = new HashSet<Impuesto>();
        }

        public string ImpuestoId { get; set; }
        public string Descripcion { get; set; }
        public string Retencion { get; set; }
        public string Traslado { get; set; }

        public virtual ICollection<Impuesto> Impuesto { get; set; }
    }
}
