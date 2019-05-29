using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Serie
    {
        public Serie()
        {
            Venta = new HashSet<Venta>();
        }

        public string SerieDocId { get; set; }
        public string Descripcion { get; set; }
        public int UltimoFolioUsado { get; set; }
        public int? EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
