using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CMoneda
    {
        public CMoneda()
        {
            Estacion = new HashSet<Estacion>();
        }

        public string MonedaId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Estacion> Estacion { get; set; }
    }
}
