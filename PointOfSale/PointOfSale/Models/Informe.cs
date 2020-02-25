using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Informe
    {
        public Informe()
        {
            InformeParametro = new HashSet<InformeParametro>();
        }

        public int InformeId { get; set; }
        public string Descripcion { get; set; }
        public string Guid { get; set; }
        public string Codigo { get; set; }
        public bool Sistema { get; set; }
        public int InformeCateforiaId { get; set; }

        public virtual InformeCategoria InformeCateforia { get; set; }
        public virtual ICollection<InformeParametro> InformeParametro { get; set; }
    }
}
