using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CMoneda
    {
        public int Id { get; set; }
        public string CMoneda1 { get; set; }
        public string Descripción { get; set; }
        public string Decimales { get; set; }
        public string PorcentajeVariación { get; set; }
    }
}
