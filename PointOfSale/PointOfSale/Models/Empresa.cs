using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Serie = new HashSet<Serie>();
        }

        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Rfc { get; set; }
        public string Negocio { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Cp { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string RutaCer { get; set; }
        public string RutaKey { get; set; }
        public string ClavePrivada { get; set; }
        public string RutaComprobantes { get; set; }
        public string RegimenFiscalId { get; set; }

        public virtual CRegimenfiscal RegimenFiscal { get; set; }
        public virtual ICollection<Serie> Serie { get; set; }
    }
}
