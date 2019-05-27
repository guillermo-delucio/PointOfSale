using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CCaducidadfolios
    {
        public int Id { get; set; }
        public int DiasCaducidad { get; set; }
        public int PorcentajeCaducidad { get; set; }
    }
}
