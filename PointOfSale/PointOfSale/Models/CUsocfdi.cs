using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CUsocfdi
    {
        public int Id { get; set; }
        public string CUsoCfdi1 { get; set; }
        public string Descripción { get; set; }
        public string Fisica { get; set; }
        public string Moral { get; set; }
        public string FechaInicioDeVigencia { get; set; }
        public string FechaFinDeVigencia { get; set; }
    }
}
