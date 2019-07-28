using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Flujo
    {
        public int FlujoId { get; set; }
        public string ConceptoIngresoId { get; set; }
        public string ConceptoEgresoId { get; set; }
        public string EntradaSalida { get; set; }
        public decimal Importe { get; set; }
        public string EstacionId { get; set; }
        public int? VentaOrigen { get; set; }
        public bool Cortado { get; set; }
        public string ConceptoImporteId { get; set; }
        public string RefBancaria { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ConceptoEgreso ConceptoEgreso { get; set; }
        public virtual ConceptoIngreso ConceptoIngreso { get; set; }
    }
}
