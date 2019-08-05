using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Corte
    {
        public int CorteId { get; set; }
        public string EstacionId { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public decimal Importe { get; set; }
        public string RutaArchivo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Usuario CreatedByNavigation { get; set; }
        public virtual Estacion Estacion { get; set; }
    }
}
