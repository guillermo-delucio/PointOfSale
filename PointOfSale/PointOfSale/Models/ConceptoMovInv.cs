using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class ConceptoMovInv
    {
        public ConceptoMovInv()
        {
            MovInv = new HashSet<MovInv>();
        }

        public string ConceptoMovInvId { get; set; }
        public string Descripcion { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<MovInv> MovInv { get; set; }
    }
}
