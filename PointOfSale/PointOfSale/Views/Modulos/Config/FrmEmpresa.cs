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
    }
}
