using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cxp
    {
        public Cxp()
        {
            Compra = new HashSet<Compra>();
            Cxpp = new HashSet<Cxpp>();
        }

        public int CxpId { get; set; }
        public int? CompraId { get; set; }
        public string TipoDocId { get; set; }
        public int NoReferencia { get; set; }
        public string ProveedorId { get; set; }
        public DateTime FechaDocumento { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string FacturaProveedor { get; set; }
        public decimal Importe { get; set; }
        public decimal Saldo { get; set; }
        public string EstadoDocId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual EstadoDoc EstadoDoc { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual TipoDoc TipoDoc { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Cxpp> Cxpp { get; set; }
    }
}
