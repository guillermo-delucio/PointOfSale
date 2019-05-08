using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public string CategoriaId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
