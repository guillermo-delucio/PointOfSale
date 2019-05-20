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
        }

        public string TipoDocId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Cxp> Cxp { get; set; }
    }
}
