using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class ProductoAlmacen
    {
        public string ProductoId { get; set; }
        public string AlmacenId { get; set; }
        public int? Existencia { get; set; }

        public virtual Almacen Almacen { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
