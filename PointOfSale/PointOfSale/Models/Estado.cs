using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Municipio = new HashSet<Municipio>();
        }

        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int? PaisId { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
