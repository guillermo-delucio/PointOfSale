using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cp
    {
        public int CpId { get; set; }
        public string Codigo { get; set; }
        public int? MunicipioId { get; set; }

        public virtual Municipio Municipio { get; set; }
    }
}
