using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Ventap = new HashSet<Ventap>();
        }

        public int VentaId { get; set; }
        public string TipoDocId { get; set; }
        public string SerieDocId { get; set; }
        public int NoReferencia { get; set; }
        public DateTime? FechaDoc { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string ClienteId { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Descuento { get; set; }
        public int? NoPrecio { get; set; }
        public int? AlmacenId { get; set; }
        public string EstadoDocId { get; set; }
        public string MonedaId { get; set; }
        public string DatosCliente { get; set; }
        public bool EnFactCierre { get; set; }
        public bool EsConversiondeTaF { get; set; }
        public int? VentaOrigen { get; set; }
        public int? CxcId { get; set; }
        public decimal Pago1 { get; set; }
        public string Pago2 { get; set; }
        public string Pago3 { get; set; }
        public string ConceptoPago1 { get; set; }
        public string ConceptoPago2 { get; set; }
        public string ConceptoPago3 { get; set; }
        public string EstacionId { get; set; }
        public bool Cortada { get; set; }
        public string RutaXml { get; set; }
        public string ImporteLetra { get; set; }
        public string UuId { get; set; }
        public string Xml { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string TipoComprobanteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario CreatedByNavigation { get; set; }
        public virtual Estacion Estacion { get; set; }
        public virtual Serie SerieDoc { get; set; }
        public virtual CTipodecomprobante TipoComprobante { get; set; }
        public virtual TipoDoc TipoDoc { get; set; }
        public virtual ICollection<Ventap> Ventap { get; set; }
    }
}
