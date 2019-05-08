using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class ClaveSat
    {
        public ClaveSat()
        {
            Producto = new HashSet<Producto>();
        }

        public string ClaveSatId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
