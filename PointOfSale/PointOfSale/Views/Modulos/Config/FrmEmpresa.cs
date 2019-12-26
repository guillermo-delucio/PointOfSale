using PointOfSale.CFDI33;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.IO;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Config
{
    public partial class FrmEmpresa : Form
    {
        Empresa empresa;
        PFX oPFX;
        EmpresaController empresaController;
        public FrmEmpresa()
        {
            InitializeComponent();
            empresaController = new EmpresaController();

        }


        private void InsertOrUpdate()
        {
            if (empresa == null)
            {
                empresa = new Empresa();
                empresa.Nombre = TxtNombre.Text;
                empresa.RazonSocial = TxtRazonSocial.Text;
                empresa.Rfc = TxtRFC.Text;
                empresa.RegimenFiscal = TxtRegimenFiscal.Text;
                empresa.RegimenFiscalId = TxtRegimenFiscalId.Text;
                empresa.Domicilio = TxtDomicilio.Text;
                empresa.Cp = TxtCP.Text;
                empresa.RutaCer = TxtRutaCer.Text;
                empresa.DirectorioComprobantes = TxtRutaComprobantes.Text;
                empresa.RutaKey = TxtRutaKey.Text;
                empresa.ClavePrivada = TxtClavePrivada.Text;
                empresa.RutaFormatoTicket = TxtFormatoTicket.Text;
                empresa.RutaCadenaOriginal = TxtRutaCO.Text;
                empresa.RutaFormatoCorte = TxtFormatoCorte.Text;
                empresa.RutaFormatoFactura = TxtFormatoFactura.Text;
                empresa.DirectorioCortes = TxtRutaCortes.Text;
                empresa.UserWstimbrado = TxtUserWS.Text.Trim();
                empresa.PassWstimbrado = TxtPassWS.Text.Trim();
                empresa.DirectorioTickets = TxtDirectorioTickets.Text.Trim();
                empresa.DirectorioTraspasos = TxtDirectorioTraspasos.Text.Trim();
                empresa.DirectorioTrabajo = TxtDirectorioTrabajo.Text.Trim();
                empresa.DirectorioImg = TxtDirectorioImg.Text.Trim();
                empresa.RutaPlantillaDetalleTraspaso = TxtRutaPlantillaDetalleTraspaso.Text.Trim();
                empresa.DirectorioReportes = TxtDirectorioReportes.Text.Trim();
                empresa.DirectorioOpenSslBin = TxtOpenSslBin.Text;
                empresa.RutaArchivoPfx = TxtRutaArchivoPfx.Text;
                empresa.TimbradoTest = ChkTimbradoTest.Checked;
                empresa.FormatoParaTickets = TxtFormatoParaTickets.Text.Trim();
                empresa.FormatoParaFacturas = TxtFormatoParaFacturas.Text.Trim();
                empresa.FormatoCortes = TxtFormatoCortes.Text.Trim();
                empresa.FormatoCierres = TxtFormatoCierres.Text.Trim();

                empresa.FormatoClientesXpuntos = TxtClientesXpuntos.Text.Trim();
                empresa.FormatoProdsXcompra = TxtProdsXCompra.Text.Trim();
                empresa.FormatoComprasXperido = TxtComprasXPeriodo.Text.Trim();
                empresa.FormatoMovsInv = TxtMovsInv.Text.Trim();
                empresa.FormatoStockXprods = TxtStockXprod.Text.Trim();
                empresa.FormatoInventarioAut = TxtInvAut.Text.Trim();
                empresa.FormatoComprasVsventas = TxtComprasVsVentas.Text.Trim();
                empresa.FormatoCatProds = TxtCatProd.Text.Trim();
                empresa.FormatoProdsXprecios = TxtProdsXprecios.Text.Trim();
                empresa.FormatoProveed = TxtProveed.Text.Trim();
                empresa.FormatoVentasAcosto = TxtVentasAcosto.Text.Trim();
                empresa.FormatoVentasXpuntos = TxtVentasXpuntos.Text.Trim();
                empresa.FormatoVentasXperiodo = TxtVentasXperiodo.Text.Trim();
                empresa.FormatoVentasXperiodoDet = TxtVentasXperiodoDet.Text.Trim();
                empresa.FormatoEntradaXcompra = TxtEntradaXcompra.Text.Trim();






                if (empresa.RegimenFiscalId.Trim().Length == 0)
                {
                    Ambiente.Mensaje("Nada que guardar");
                    return;
                }
                if (empresaController.InsertOne(empresa))
                    Ambiente.Mensaje("Cambios Guarados");
                else
                    Ambiente.Mensaje("Algo salió mal");
            }
            else
            {
                empresa.Nombre = TxtNombre.Text;
                empresa.RazonSocial = TxtRazonSocial.Text;
                empresa.Rfc = TxtRFC.Text;
                empresa.RegimenFiscal = TxtRegimenFiscal.Text;
                empresa.RegimenFiscalId = TxtRegimenFiscalId.Text;
                empresa.Domicilio = TxtDomicilio.Text;
                empresa.Cp = TxtCP.Text;
                empresa.RutaCer = TxtRutaCer.Text;
                empresa.DirectorioComprobantes = TxtRutaComprobantes.Text;
                empresa.RutaKey = TxtRutaKey.Text;
                empresa.ClavePrivada = TxtClavePrivada.Text;
                empresa.RutaFormatoTicket = TxtFormatoTicket.Text;
                empresa.RutaCadenaOriginal = TxtRutaCO.Text;
                empresa.RutaFormatoCorte = TxtFormatoCorte.Text;
                empresa.RutaFormatoFactura = TxtFormatoFactura.Text;
                empresa.DirectorioCortes = TxtRutaCortes.Text;
                empresa.UserWstimbrado = TxtUserWS.Text.Trim();
                empresa.PassWstimbrado = TxtPassWS.Text.Trim();
                empresa.DirectorioTickets = TxtDirectorioTickets.Text;
                empresa.DirectorioTraspasos = TxtDirectorioTraspasos.Text.Trim();
                empresa.DirectorioTrabajo = TxtDirectorioTrabajo.Text.Trim();
                empresa.DirectorioImg = TxtDirectorioImg.Text.Trim();
                empresa.RutaPlantillaDetalleTraspaso = TxtRutaPlantillaDetalleTraspaso.Text.Trim();
                empresa.DirectorioReportes = TxtDirectorioReportes.Text.Trim();
                empresa.DirectorioOpenSslBin = TxtOpenSslBin.Text;
                empresa.RutaArchivoPfx = TxtRutaArchivoPfx.Text;
                empresa.TimbradoTest = ChkTimbradoTest.Checked;
                empresa.FormatoParaTickets = TxtFormatoParaTickets.Text.Trim();
                empresa.FormatoParaFacturas = TxtFormatoParaFacturas.Text.Trim();
                empresa.FormatoCortes = TxtFormatoCortes.Text.Trim();
                empresa.FormatoCierres = TxtFormatoCierres.Text.Trim();

                empresa.FormatoClientesXpuntos = TxtClientesXpuntos.Text.Trim();
                empresa.FormatoProdsXcompra = TxtProdsXCompra.Text.Trim();
                empresa.FormatoComprasXperido = TxtComprasXPeriodo.Text.Trim();
                empresa.FormatoMovsInv = TxtMovsInv.Text.Trim();
                empresa.FormatoStockXprods = TxtStockXprod.Text.Trim();
                empresa.FormatoInventarioAut = TxtInvAut.Text.Trim();
                empresa.FormatoComprasVsventas = TxtComprasVsVentas.Text.Trim();
                empresa.FormatoCatProds = TxtCatProd.Text.Trim();
                empresa.FormatoProdsXprecios = TxtProdsXprecios.Text.Trim();
                empresa.FormatoProveed = TxtProveed.Text.Trim();
                empresa.FormatoVentasAcosto = TxtVentasAcosto.Text.Trim();
                empresa.FormatoVentasXpuntos = TxtVentasXpuntos.Text.Trim();
                empresa.FormatoVentasXperiodo = TxtVentasXperiodo.Text.Trim();
                empresa.FormatoVentasXperiodoDet = TxtVentasXperiodoDet.Text.Trim();
                empresa.FormatoEntradaXcompra = TxtEntradaXcompra.Text.Trim();

                if (empresa.RegimenFiscalId.Trim().Length == 0)
                {
                    Ambiente.Mensaje("Nada que guardar");
                    return;
                }
                if (empresaController.Update(empresa))
                    Ambiente.Mensaje("Cambios Guarados");
                else
                    Ambiente.Mensaje("Algo salió mal");
            }
        }
        private void LlenaDatos(Empresa empresa)
        {
            if (empresa == null)
                return;

            TxtNombre.Text = empresa.Nombre;
            TxtRazonSocial.Text = empresa.RazonSocial;
            TxtRFC.Text = empresa.Rfc;
            TxtRegimenFiscal.Text = empresa.RegimenFiscal;
            TxtRegimenFiscalId.Text = empresa.RegimenFiscalId;
            TxtDomicilio.Text = empresa.Domicilio;
            TxtCP.Text = empresa.Cp;
            TxtRutaCer.Text = empresa.RutaCer;
            TxtRutaComprobantes.Text = empresa.DirectorioComprobantes;
            TxtRutaKey.Text = empresa.RutaKey;
            TxtClavePrivada.Text = empresa.ClavePrivada;
            TxtFormatoTicket.Text = empresa.RutaFormatoTicket;
            TxtRutaCO.Text = empresa.RutaCadenaOriginal;
            TxtFormatoCorte.Text = empresa.RutaFormatoCorte;
            TxtFormatoFactura.Text = empresa.RutaFormatoFactura;
            TxtRutaCortes.Text = empresa.DirectorioCortes;
            TxtPassWS.Text = empresa.PassWstimbrado;
            TxtUserWS.Text = empresa.UserWstimbrado;
            TxtDirectorioTickets.Text = empresa.DirectorioTickets;
            TxtDirectorioTraspasos.Text = empresa.DirectorioTraspasos;
            TxtDirectorioTrabajo.Text = empresa.DirectorioTrabajo;
            TxtDirectorioImg.Text = empresa.DirectorioImg;
            TxtRutaPlantillaDetalleTraspaso.Text = empresa.RutaPlantillaDetalleTraspaso;
            TxtDirectorioReportes.Text = empresa.DirectorioReportes;
            TxtOpenSslBin.Text = empresa.DirectorioOpenSslBin;
            TxtRutaArchivoPfx.Text = empresa.RutaArchivoPfx;
            ChkTimbradoTest.Checked = empresa.TimbradoTest;
            TxtFormatoParaTickets.Text = empresa.FormatoParaTickets;
            TxtFormatoParaFacturas.Text = empresa.FormatoParaFacturas;
            TxtFormatoCortes.Text = empresa.FormatoCortes;
            TxtFormatoCierres.Text = empresa.FormatoCierres;

            TxtClientesXpuntos.Text = empresa.FormatoClientesXpuntos;
            TxtProdsXCompra.Text = empresa.FormatoProdsXcompra;
            TxtComprasXPeriodo.Text = empresa.FormatoComprasXperido;
            TxtMovsInv.Text = empresa.FormatoMovsInv;
            TxtStockXprod.Text = empresa.FormatoStockXprods;
            TxtInvAut.Text = empresa.FormatoInventarioAut;
            TxtComprasVsVentas.Text = empresa.FormatoComprasVsventas;
            TxtCatProd.Text = empresa.FormatoCatProds;
            TxtProdsXprecios.Text = empresa.FormatoProdsXprecios;
            TxtProveed.Text = empresa.FormatoProveed;
            TxtVentasAcosto.Text = empresa.FormatoVentasAcosto;
            TxtVentasXpuntos.Text = empresa.FormatoVentasXpuntos;
            TxtVentasXperiodo.Text = empresa.FormatoVentasXperiodo;
            TxtVentasXperiodoDet.Text = empresa.FormatoVentasXperiodoDet;
            TxtEntradaXcompra.Text = empresa.FormatoEntradaXcompra;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }



        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtNombre_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtNombre.Text.Trim(), (int)Ambiente.TipoBusqueda.Empresas))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        empresa = form.Empresa;

                        LlenaDatos(empresa);
                        if (!File.Exists(@"C:\Dympos\FacturaElectronica\Certificados\PFX.pfx"))
                        {
                            oPFX = new PFX(empresa.RutaCer,
                            empresa.RutaKey,
                            empresa.ClavePrivada,
                            @"C:\Dympos\FacturaElectronica\Certificados\PFX.pfx",
                            @"C:\Dympos\FacturaElectronica\Certificados\",
                            empresa.DirectorioOpenSslBin);
                            if (!oPFX.creaPFX())
                                Ambiente.Mensaje(oPFX.error);
                        }

                    }

                }
            }
        }

        private void BtnFormatoFactura_Click_1(object sender, EventArgs e)
        {
            TxtFormatoFactura.Text = Ambiente.GetFilePath().Item1;
        }

        private void BtnCo_Click(object sender, EventArgs e)
        {
            TxtRutaCO.Text = Ambiente.GetFilePath().Item1;
        }

        private void BtnComprobantes_Click(object sender, EventArgs e)
        {
            TxtRutaComprobantes.Text = Ambiente.GetFolderPath();
        }

        private void BtnCortes_Click(object sender, EventArgs e)
        {
            TxtRutaCortes.Text = Ambiente.GetFolderPath();
        }

        private void BtnFormatoCorte_Click(object sender, EventArgs e)
        {
            TxtFormatoCorte.Text = Ambiente.GetFilePath().Item1;
        }

        private void BtnFormatoTicket_Click(object sender, EventArgs e)
        {
            TxtFormatoTicket.Text = Ambiente.GetFilePath().Item1;
        }

        private void BtnKey_Click(object sender, EventArgs e)
        {
            TxtRutaKey.Text = Ambiente.GetFilePath().Item1;
        }

        private void BtnCer_Click(object sender, EventArgs e)
        {
            TxtRutaCer.Text = Ambiente.GetFilePath().Item1;
        }

        private void TxtRegimenFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtRegimenFiscal.Text.Trim(), (int)Ambiente.TipoBusqueda.RegimenFiscal))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtRegimenFiscal.Text = form.Regimenfiscal.Descripcion;
                        TxtRegimenFiscalId.Text = form.Regimenfiscal.RegimenFiscalId;
                    }

                }
            }
        }

        private void BtnTickets_Click(object sender, EventArgs e)
        {
            TxtDirectorioTickets.Text = Ambiente.GetFolderPath();
        }




        private void FrmEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void BtnDirTrabajo_Click(object sender, EventArgs e)
        {
            TxtDirectorioTrabajo.Text = Ambiente.GetFolderPath();
        }

        private void BtnDirTraspsos_Click(object sender, EventArgs e)
        {
            TxtDirectorioTraspasos.Text = Ambiente.GetFolderPath();
        }

        private void BtnPlanTraspaso_Click(object sender, EventArgs e)
        {
            TxtDirectorioImg.Text = Ambiente.GetFolderPath();
        }

        private void BtnPlanDetTraspaso_Click(object sender, EventArgs e)
        {
            TxtRutaPlantillaDetalleTraspaso.Text = Ambiente.GetFilePath().Item1;
        }

        private void BtnDirReportes_Click(object sender, EventArgs e)
        {
            TxtDirectorioReportes.Text = Ambiente.GetFolderPath();
        }

        private void BtnOpenSslBin_Click(object sender, EventArgs e)
        {
            TxtOpenSslBin.Text = Ambiente.GetFolderPath();
        }

        private void BtnCrearPFX_Click(object sender, EventArgs e)
        {

        }

        private void BtnPFX_Click(object sender, EventArgs e)
        {
            TxtRutaArchivoPfx.Text = TxtFormatoTicket.Text = Ambiente.GetFilePath().Item1;
        }

        private void TxtFormatoTickets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtFormatoParaTickets.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtFormatoParaTickets.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtFormatoParaFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtFormatoParaFacturas.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtFormatoParaFacturas.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }

        }

        private void BtnUpdateDb_Click(object sender, EventArgs e)
        {
            Ambiente.InsertaActualizacion();
        }

        private void TxtFormatoCortes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtFormatoCortes.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtFormatoCortes.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtFormatoCierres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtFormatoCierres.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtFormatoCierres.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }
        /*******************************/

        private void TxtClientesXpuntos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtClientesXpuntos.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtClientesXpuntos.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtProdsXCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtProdsXCompra.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtProdsXCompra.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtComprasXPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtComprasXPeriodo.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtComprasXPeriodo.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtMovsInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtMovsInv.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtMovsInv.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtStockXprod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtStockXprod.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtStockXprod.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TextBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtInvAut.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtInvAut.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtComprasVsVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtComprasVsVentas.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtComprasVsVentas.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtCatProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtCatProd.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtCatProd.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtProdsXprecios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtProdsXprecios.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtProdsXprecios.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtProveed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtProveed.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtProveed.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtVentasAcosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtVentasAcosto.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtVentasAcosto.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtVentasXpuntos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtVentasXpuntos.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtVentasXpuntos.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtVentasXperiodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtVentasXperiodo.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtVentasXperiodo.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }

        private void TxtVentasXperiodoDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtVentasXperiodoDet.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtVentasXperiodoDet.Text = form.Reporte == null ? "" : form.Reporte.Nombre;
                    }
                }
            }
        }
    }
}
