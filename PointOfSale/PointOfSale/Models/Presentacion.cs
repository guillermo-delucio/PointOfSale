using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Presentacion
    {
        public Presentacion()
        {
            Producto = new HashSet<Producto>();
        }

        public string PresentacionId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
