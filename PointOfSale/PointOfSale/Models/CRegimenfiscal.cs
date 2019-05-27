using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CRegimenfiscal
    {
        public int Id { get; set; }
        public string CRegimenFiscal1 { get; set; }
        public string Descripción { get; set; }
        public string Física { get; set; }
        public string Moral { get; set; }
        public string FechaDeInicioDeVigencia { get; set; }
        public string FechaDeFinDeVigencia { get; set; }
    }
}
