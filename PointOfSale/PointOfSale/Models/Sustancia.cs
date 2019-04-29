using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Sustancia
    {
        public Sustancia()
        {
            ProductoSustancia = new HashSet<ProductoSustancia>();
        }

        public string SustanciaId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductoSustancia> ProductoSustancia { get; set; }
    }
}
