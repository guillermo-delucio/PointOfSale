using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CRegimenfiscal
    {
        public CRegimenfiscal()
        {
            Empresa = new HashSet<Empresa>();
        }

        public string RegimenFiscalId { get; set; }
        public string Descripcion { get; set; }
        public string Física { get; set; }
        public string Moral { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
