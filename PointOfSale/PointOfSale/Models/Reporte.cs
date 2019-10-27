using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Reporte
    {
        public int ReporteId { get; set; }
        public string Nombre { get; set; }
        public string SecuenciaCifrado { get; set; }
        public string Sql { get; set; }
        public string Codigo { get; set; }
        public bool Parametrizado { get; set; }
    }
}
