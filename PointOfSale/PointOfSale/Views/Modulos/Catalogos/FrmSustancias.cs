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
    public partial class FrmSustancias : Form
    {
        private dynamic objeto;
        private SustanciaController sustanciaController;
        bool ModoCreate;

        public FrmSustancias()
        {
            InitializeComponent();
            sustanciaController = new SustanciaController();
            ModoCreate = true;
        }

        public FrmSustancias(dynamic objeto)
        {
            InitializeComponent();
            sustanciaController = new SustanciaController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Sustancia)this.objeto;
                TxtClave.Text = objeto.SustanciaId;
            }

        }

        private void TxtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenaCampos();
            }
        }

        private void LlenaCampos()
        {
            if (objeto == null)
                ModoCreate = true;
            else
            {
                ModoCreate = false;
                TxtClave.Text = objeto.SustanciaId;
                TxtNombre.Text = objeto.Nombre;

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

                objeto = new Sustancia();
                objeto.SustanciaId = TxtClave.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();
                if (sustanciaController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Nombre = TxtNombre.Text.Trim();
                if (sustanciaController.Update(objeto))
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
    }
}
