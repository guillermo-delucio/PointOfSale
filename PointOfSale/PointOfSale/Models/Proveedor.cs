using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Proveedor
    {
        public string ProveedorId { get; set; }
        public string Rfc { get; set; }
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
        public int? DiasCredito { get; set; }
        public decimal? LimiteCredito { get; set; }
        public decimal? Saldo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
