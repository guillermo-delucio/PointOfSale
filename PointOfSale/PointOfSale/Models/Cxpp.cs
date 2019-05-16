using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cxpp
    {
        public int Pcxpid { get; set; }
        public int Cxpid { get; set; }
        public int CompraId { get; set; }
        public string ProveedorId { get; set; }
        public string CargoAbono { get; set; }
        public decimal Importe { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Cxp Cxp { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
