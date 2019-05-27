using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CFormapago
    {
        public int Id { get; set; }
        public string CFormaPago1 { get; set; }
        public string Descripción { get; set; }
        public string Bancarizado { get; set; }
        public string NúmeroDeOperación { get; set; }
        public string RfcDelEmisorDeLaCuentaOrdenante { get; set; }
        public string CuentaOrdenante { get; set; }
        public string PatrónParaCuentaOrdenante { get; set; }
        public string RfcDelEmisorCuentaDeBeneficiario { get; set; }
        public string CuentaDeBenenficiario { get; set; }
        public string PatrónParaCuentaBeneficiaria { get; set; }
        public string TipoCadenaPago { get; set; }
        public string NombreDelBancoEmisorDeLaCuentaOrdenanteEnCasoDeExtran { get; set; }
    }
}
