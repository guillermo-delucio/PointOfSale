using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CUsocfdi
    {
        public CUsocfdi()
        {
            Cliente = new HashSet<Cliente>();
        }

        public string UsoCfdiid { get; set; }
        public string Descripcion { get; set; }
        public string Fisica { get; set; }
        public string Moral { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
