using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class MovInv
    {
        public int MovInvId { get; set; }
        public string ConceptoMovsInvId { get; set; }
        public int NoRef { get; set; }
        public string EntradaSalida { get; set; }
        public int? IdEntrada { get; set; }
        public int? IdSalida { get; set; }
        public string ProductoId { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ConceptoMovInv ConceptoMovsInv { get; set; }
    }
}
