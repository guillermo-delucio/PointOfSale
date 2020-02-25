using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class InformeCategoria
    {
        public InformeCategoria()
        {
            Informe = new HashSet<Informe>();
        }

        public int InformeCategoriaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Informe> Informe { get; set; }
    }
}
