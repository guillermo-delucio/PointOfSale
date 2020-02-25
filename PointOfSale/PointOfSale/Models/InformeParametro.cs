using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class InformeParametro
    {
        public int ParametroId { get; set; }
        public int InformeId { get; set; }
        public string Nombre { get; set; }
        public string Estandar { get; set; }

        public virtual Informe Informe { get; set; }
    }
}
