using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cxc
    {
        public Cxc()
        {
            Cxcp = new HashSet<Cxcp>();
        }

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
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Usuario CreatedByNavigation { get; set; }
        public virtual ICollection<Cxcp> Cxcp { get; set; }
    }
}
