using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class EstadoDoc
    {
        public EstadoDoc()
        {
            Compra = new HashSet<Compra>();
            Cxp = new HashSet<Cxp>();
        }

        public string EstadoDocId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Cxp> Cxp { get; set; }
    }
}
