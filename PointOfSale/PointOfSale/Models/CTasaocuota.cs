using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CTasaocuota
    {
        public int Id { get; set; }
        public string RangoOfijo { get; set; }
        public string ValorMínimo { get; set; }
        public string ValorMáximo { get; set; }
        public string Impuesto { get; set; }
        public string Factor { get; set; }
        public string Traslado { get; set; }
        public string Retención { get; set; }
        public string FechaInicioDeVigencia { get; set; }
        public string FechaFinDeVigencia { get; set; }
    }
}
