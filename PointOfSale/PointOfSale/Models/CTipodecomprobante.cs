using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CTipodecomprobante
    {
        public CTipodecomprobante()
        {
            Venta = new HashSet<Venta>();
        }

        public string TipoComprobanteId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
