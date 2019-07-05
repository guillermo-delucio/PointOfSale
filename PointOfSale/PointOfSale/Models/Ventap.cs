using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Ventap
    {
        public int VentapId { get; set; }
        public int VentaId { get; set; }
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public string LoteId { get; set; }
        public DateTime? Caducidad { get; set; }
        public string ClaveImpuesto1 { get; set; }
        public string ClaveImpuesto2 { get; set; }
        public string TasaOcuota1 { get; set; }
        public string TasaOcuota2 { get; set; }
        public decimal Impuesto1 { get; set; }
        public decimal Impuesto2 { get; set; }
        public decimal ImporteImpuesto1 { get; set; }
        public decimal ImporteImpuesto2 { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string ClaveProdServ { get; set; }
        public string ClaveUnidad { get; set; }
        public string Unidad { get; set; }

        public virtual CImpuesto ClaveImpuesto1Navigation { get; set; }
        public virtual CImpuesto ClaveImpuesto2Navigation { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
