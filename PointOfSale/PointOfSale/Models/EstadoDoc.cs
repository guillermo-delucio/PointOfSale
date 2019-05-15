using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class EstadoDoc
    {
        public EstadoDoc()
        {
            Cxp = new HashSet<Cxp>();
        }

        public string EstadoIdocId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cxp> Cxp { get; set; }
    }
}
