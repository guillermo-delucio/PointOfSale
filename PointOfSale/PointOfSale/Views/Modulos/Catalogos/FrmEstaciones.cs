using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmEstaciones : Form
    {
        private dynamic objeto;
        private EstacionController estacionController;
        bool ModoCreate;

        public FrmEstaciones()
        {
            InitializeComponent();
            estacionController = new EstacionController();
            ModoCreate = true;
        }

        public FrmEstaciones(dynamic objeto)
        {
            InitializeComponent();
            estacionController = new EstacionController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Estacion)this.objeto;
                TxtClave.Text = objeto.EstacionId;
            }

        }



        private void LlenaCampos()
        {
            objeto = estacionController.SelectOne(TxtClave.Text.Trim());
            if (objeto == null)
                ModoCreate = true;
            else
            {
                ModoCreate = false;
                TxtClave.Text = objeto.EstacionId;
                TxtNombre.Text = objeto.Nombre;
                CboIT.Text = objeto.ImpresoraT;
                CboIF.Text = objeto.ImpresoraF;
                CboINC.Text = objeto.ImpresoraNc;
                ChkVentaSinExistencia.Checked = objeto.VenderSinStock;
                ChkSolicitarFMpago.Checked = objeto.SolicitarFmpago;
                ChkSumarUnidades.Checked = objeto.SumarUnidadesPdv;
                CboImpresoraT.Text = objeto.ImpresoraT;
                CboImpresoraF.Text = objeto.ImpresoraF;
                CboImpresoraNC.Text = objeto.ImpresoraNc;
                NTickets.Value = objeto.TantosT;
                NFacturas.Value = objeto.TantosF;
                NNc.Value = objeto.TantosNc;
            }


        }



        private void InsertOrUpdate()
        {
            if (ModoCreate)
            {
                if (TxtClave.Text.Trim().Length == 0)
                    return;

                objeto = new Estacion();
                objeto.EstacionId = TxtClave.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();

                objeto.VenderSinStock = ChkVentaSinExistencia.Checked;
                objeto.SolicitarFmpago = ChkSolicitarFMpago.Checked;
                objeto.SumarUnidadesPdv = ChkSumarUnidades.Checked;
                objeto.ImpresoraT = CboImpresoraT.Text;
                objeto.ImpresoraF = CboImpresoraF.Text;
                objeto.ImpresoraNC = CboImpresoraNC.Text;
                objeto.TantosT = NTickets.Value;
                objeto.TantosF = NFacturas.Value;
                objeto.TantosNc = NNc.Value;
                if (estacionController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Nombre = TxtNombre.Text.Trim();
                objeto.ImpresoraT = CboIT.Text.Trim();
                objeto.ImpresoraF = CboIF.Text.Trim();
                objeto.ImpresoraNc = CboINC.Text.Trim();
                objeto.VenderSinStock = ChkVentaSinExistencia.Checked;
                objeto.SolicitarFmpago = ChkSolicitarFMpago.Checked;
                objeto.SumarUnidadesPdv = ChkSumarUnidades.Checked;
                objeto.ImpresoraT = CboImpresoraT.Text;
                objeto.ImpresoraF = CboImpresoraF.Text;
                objeto.ImpresoraNc = CboImpresoraNC.Text;
                objeto.TantosT = (int)NTickets.Value;
                objeto.TantosF = (int)NFacturas.Value;
                objeto.TantosNc = (int)NNc.Value;
                if (estacionController.Update(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);

                Close();
            }
        }

        private void LlenaImpresoras()
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                CboImpresoraT.Items.Add(printer);
                CboImpresoraF.Items.Add(printer);
                CboImpresoraNC.Items.Add(printer);
            }
            TxtClave.Focus();
        }

        private void TxtClave_Leave(object sender, EventArgs e)
        {
            LlenaCampos();
        }

        private void BtnAceptar_Click_1(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEstaciones_Load(object sender, EventArgs e)
        {
            LlenaImpresoras();
        }

        private void TxtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtClave.Text.Trim(), (int)Ambiente.TipoBusqueda.Estaciones))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtClave.Text = form.Estacion.EstacionId;
                    }
                }
            }
        }
    }
}
