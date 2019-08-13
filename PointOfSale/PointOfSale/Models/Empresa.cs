using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Empresa
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string RegimenFiscalId { get; set; }
        public string RegimenFiscal { get; set; }
        public string Domicilio { get; set; }
        public string Cp { get; set; }
        public string RutaCer { get; set; }
        public string RutaKey { get; set; }
        public string ClavePrivada { get; set; }
        public string RutaFormatoTicket { get; set; }
        public string RutaFormatoFactura { get; set; }
        public string RutaFormatoCorte { get; set; }
        public string RutaCadenaOriginal { get; set; }
        public string DirectorioComprobantes { get; set; }
        public string DirectorioTickets { get; set; }
        public string DirectorioCortes { get; set; }
        public bool? IsDeleted { get; set; }
        public string UserWstimbrado { get; set; }
        public string PassWstimbrado { get; set; }
        public string DirectorioTrabajo { get; set; }
        public string DirectorioTraspasos { get; set; }
        public string RutaPlantillaTraspaso { get; set; }
        public string RutaPlantillaDetalleTraspaso { get; set; }
        public string DirectorioReportes { get; set; }

        public virtual CRegimenfiscal RegimenFiscalNavigation { get; set; }
    }
}
