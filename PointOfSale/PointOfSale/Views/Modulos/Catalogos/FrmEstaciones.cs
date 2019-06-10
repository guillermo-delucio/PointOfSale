using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if (objeto == null)
                ModoCreate = true;
            else
            {
                ModoCreate = false;
                TxtClave.Text = objeto.EstacionId;
                TxtNombre.Text = objeto.Nombre;
                TxtAlmacenId.Text = objeto.DefaultAlmacenId.ToString();
                CboIT.Text = objeto.ImpresoraT;
                CboIR.Text = objeto.ImpresoraR;
                CboIF.Text = objeto.ImpresoraF;
                CboINC.Text = objeto.ImpresoraNc;
            }


        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
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
                if (estacionController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Nombre = TxtNombre.Text.Trim();
                TxtAlmacenId.Text = objeto.DefaultAlmacenId.ToString();
                CboIT.Text = objeto.ImpresoraT;
                CboIR.Text = objeto.ImpresoraR;
                CboIF.Text = objeto.ImpresoraF;
                CboINC.Text = objeto.ImpresoraNc;

                if (estacionController.Update(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);

                Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtClave_Leave(object sender, EventArgs e)
        {
            LlenaCampos();
        }
    }
}
