using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CImpuesto
    {
        public CImpuesto()
        {
            Impuesto = new HashSet<Impuesto>();
            VentapClaveImpuesto1Navigation = new HashSet<Ventap>();
            VentapClaveImpuesto2Navigation = new HashSet<Ventap>();
        }

        public string ImpuestoId { get; set; }
        public string Descripcion { get; set; }
        public string Retencion { get; set; }
        public string Traslado { get; set; }

        public virtual ICollection<Impuesto> Impuesto { get; set; }
        public virtual ICollection<Ventap> VentapClaveImpuesto1Navigation { get; set; }
        public virtual ICollection<Ventap> VentapClaveImpuesto2Navigation { get; set; }
    }
}
