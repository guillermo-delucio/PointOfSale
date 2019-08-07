using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Punto
    {
        public int PuntoId { get; set; }
        public string ClienteId { get; set; }
        public string ClienteName { get; set; }
        public int VentaId { get; set; }
        public decimal Base { get; set; }
        public decimal Tasa { get; set; }
        public decimal Importe { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ResetedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
