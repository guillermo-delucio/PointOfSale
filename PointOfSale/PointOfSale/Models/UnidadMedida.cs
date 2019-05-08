using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            Producto = new HashSet<Producto>();
        }

        public string UnidadMedidaId { get; set; }
        public string Nombre { get; set; }
        public string UnidadSat { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
