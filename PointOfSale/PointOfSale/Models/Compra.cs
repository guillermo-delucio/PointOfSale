using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Compra
    {
        public int CompraId { get; set; }
        public DateTime FechaDocumento { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string ProveedorId { get; set; }
        public bool EsCxp { get; set; }
        public int? CxpId { get; set; }
        public decimal Importe { get; set; }
        public decimal Impuesto { get; set; }
        public string FacturaProveedor { get; set; }
        public string TipoDocId { get; set; }
        public string EstadoDocId { get; set; }
        public string AlmacenId { get; set; }
        public string EstacionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Datos { get; set; }

        public virtual Almacen Almacen { get; set; }
        public virtual Cxp Cxp { get; set; }
        public virtual Estacion Estacion { get; set; }
    }
}
