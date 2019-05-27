using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CNumpedimentoaduana
    {
        public int Id { get; set; }
        public string CAduana { get; set; }
        public string Patente { get; set; }
        public string Ejercicio { get; set; }
        public string Cantidad { get; set; }
        public string FechaInicioDeVigencia { get; set; }
        public string FechaFinDeVigencia { get; set; }
    }
}
