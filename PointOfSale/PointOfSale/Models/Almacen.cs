using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Almacen
    {
        public Almacen()
        {
            ProductoAlmacen = new HashSet<ProductoAlmacen>();
        }

        public string AlmacenId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ProductoAlmacen> ProductoAlmacen { get; set; }
    }
}
