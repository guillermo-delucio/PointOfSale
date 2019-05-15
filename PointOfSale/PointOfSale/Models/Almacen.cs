using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Almacen
    {
        public Almacen()
        {
            Compra = new HashSet<Compra>();
            ProductoAlmacen = new HashSet<ProductoAlmacen>();
        }

        public string AlmacenId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<ProductoAlmacen> ProductoAlmacen { get; set; }
    }
}
