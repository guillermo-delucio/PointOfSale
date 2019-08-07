using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class PuntoConfig
    {
        public int PuntosConfigId { get; set; }
        public decimal TasaDescuento { get; set; }
        public int DiasReset { get; set; }
        public bool IsDeleted { get; set; }
        public bool Vigente { get; set; }
    }
}
