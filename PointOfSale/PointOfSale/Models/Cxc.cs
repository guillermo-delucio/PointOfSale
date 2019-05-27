using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cxc
    {
        public int CxcId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public string TipoDocId { get; set; }
        public string EstadoDocId { get; set; }
        public string SerieDocId { get; set; }
        public int? NoReferencia { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Saldo { get; set; }
        public string MonedaId { get; set; }
        public int VentaId { get; set; }
    }
}
