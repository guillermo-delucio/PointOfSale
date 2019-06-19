using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public string ClienteId { get; set; }
        public string Rfc { get; set; }
        public bool IsDeleted { get; set; }
        public string Negocio { get; set; }
        public string RazonSocial { get; set; }
        public string Contancto { get; set; }
        public string Direccion { get; set; }
        public string Cp { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int DiasCredito { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal Saldo { get; set; }
        public string Colonia { get; set; }
        public string Correo { get; set; }
        public string MetodoPagoId { get; set; }
        public string FormaPagoId { get; set; }
        public int? PrecioDefault { get; set; }
        public bool TieneLicencia { get; set; }
        public string UsoCfdiid { get; set; }

        public virtual CFormapago FormaPago { get; set; }
        public virtual FormaPago FormaPagoNavigation { get; set; }
        public virtual CMetodopago MetodoPago { get; set; }
        public virtual MetodoPago MetodoPagoNavigation { get; set; }
        public virtual CUsocfdi UsoCfdi { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
