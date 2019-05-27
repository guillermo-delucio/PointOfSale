using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CClaveunidad
    {
        public int Id { get; set; }
        public string CClaveUnidad1 { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Nota { get; set; }
        public string Fechadeiniciodevigencia { get; set; }
        public string Fechadefindevigencia { get; set; }
        public string Símbolo { get; set; }
    }
}
