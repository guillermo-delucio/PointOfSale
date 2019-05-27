using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Serie
    {
        public int SerieId { get; set; }
        public string SerieName { get; set; }
        public string Descripcion { get; set; }
        public int UltimoFolioUsado { get; set; }
        public int? EmpresaId { get; set; }
    }
}
