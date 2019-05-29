using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CFormapago
    {
        public CFormapago()
        {
            Cliente = new HashSet<Cliente>();
        }

        public string FormaPagoId { get; set; }
        public string Descripcion { get; set; }
        public string Bancarizado { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
