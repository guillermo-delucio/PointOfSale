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
        public string DirectorioImg { get; set; }
        public string RutaPlantillaDetalleTraspaso { get; set; }
        public string DirectorioReportes { get; set; }
        public string DirectorioOpenSslBin { get; set; }
        public string RutaArchivoPfx { get; set; }
        public bool TimbradoTest { get; set; }
        public string FormatoParaTickets { get; set; }
        public string FormatoParaFacturas { get; set; }
        public string FormatoCortes { get; set; }
        public string FormatoCierres { get; set; }
        public string FormatoClientesXpuntos { get; set; }
        public string FormatoComprasXperido { get; set; }
        public string FormatoProdsXcompra { get; set; }
        public string FormatoMovsInv { get; set; }
        public string FormatoStockXprods { get; set; }
        public string FormatoInventarioAut { get; set; }
        public string FormatoComprasVsventas { get; set; }
        public string FormatoCatProds { get; set; }
        public string FormatoProdsXprecios { get; set; }
        public string FormatoProveed { get; set; }
        public string FormatoVentasAcosto { get; set; }
        public string FormatoVentasXpuntos { get; set; }
        public string FormatoVentasXperiodo { get; set; }
        public string FormatoVentasXperiodoDet { get; set; }
        public string FormatoEntradaXcompra { get; set; }

        public virtual CRegimenfiscal RegimenFiscalNavigation { get; set; }
    }
}
