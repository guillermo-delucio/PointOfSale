using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CMetodopago
    {
        public CMetodopago()
        {
            Cliente = new HashSet<Cliente>();
        }

        public string MetodoPagoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
