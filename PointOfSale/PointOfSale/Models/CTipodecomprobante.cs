using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CTipodecomprobante
    {
        public int Id { get; set; }
        public string CTipoDeComprobante1 { get; set; }
        public string Descripción { get; set; }
        public string ValorMáximo { get; set; }
        public string D { get; set; }
        public string FechaInicioDeVigencia { get; set; }
        public string FechaFinDeVigencia { get; set; }
    }
}
