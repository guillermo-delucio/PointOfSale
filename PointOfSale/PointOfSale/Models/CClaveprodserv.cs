using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CClaveprodserv
    {
        public int Id { get; set; }
        public string CClaveProdServ1 { get; set; }
        public string Descripción { get; set; }
        public string IncluirIvaTrasladado { get; set; }
        public string IncluirIepsTrasladado { get; set; }
        public string ComplementoQueDebeIncluir { get; set; }
        public string FechaInicioVigencia { get; set; }
        public string FechaFinVigencia { get; set; }
        public string PalabrasSimilares { get; set; }
    }
}
