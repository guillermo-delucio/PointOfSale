using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class TipoDoc
    {
        public TipoDoc()
        {
            Compra = new HashSet<Compra>();
            Cxp = new HashSet<Cxp>();
            Venta = new HashSet<Venta>();
        }

        public string TipoDocId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Cxp> Cxp { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
