using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cxcp
    {
        public int CxcpId { get; set; }
        public int? CxcId { get; set; }
        public int? ClienteId { get; set; }
        public int? NoReferencia { get; set; }
        public string CargoAbono { get; set; }
        public decimal? Importe { get; set; }
        public string ConceptoPago { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }

        public virtual Cxc Cxc { get; set; }
    }
}
