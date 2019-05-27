using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CImpuesto
    {
        public int Id { get; set; }
        public string CImpuesto1 { get; set; }
        public string Descripción { get; set; }
        public string Retención { get; set; }
        public string Traslado { get; set; }
        public string LocalOFederal { get; set; }
        public string EntidadEnLaQueAplica { get; set; }
    }
}
