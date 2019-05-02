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
    public partial class FrmAlmacenes : Form
    {
        private dynamic objeto;
        private AlmacenController almacenController;
        bool ModoCreate;

        public FrmAlmacenes()
        {
            InitializeComponent();
            almacenController = new AlmacenController();
            ModoCreate = true;
        }

        public FrmAlmacenes(dynamic objeto)
        {
            InitializeComponent();
            almacenController = new AlmacenController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Almacen)this.objeto;
                TxtClave.Text = objeto.AlmacenId;
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
                TxtClave.Text = objeto.AlmacenId;
                TxtNombre.Text = objeto.Nombre;

            }


        }
        private void InsertOrUpdate()
        {
            if (ModoCreate)
            {
                if (TxtClave.Text.Trim().Length == 0)
                    return;

                objeto = new Almacen();
                objeto.AlmacenId = TxtClave.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();
                if (almacenController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Nombre = TxtNombre.Text.Trim();
                if (almacenController.Update(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);

                Close();
            }
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
