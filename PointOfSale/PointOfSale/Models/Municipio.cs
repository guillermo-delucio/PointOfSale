using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Cp = new HashSet<Cp>();
        }

        public int MucipioId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int? EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Cp> Cp { get; set; }
    }
}
