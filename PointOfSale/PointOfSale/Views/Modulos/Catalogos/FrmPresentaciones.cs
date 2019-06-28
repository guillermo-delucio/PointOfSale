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
    public partial class FrmPresentaciones : Form
    {
        private dynamic objeto;
        private PresentacionController presentacionController;
        bool ModoCreate;

        public FrmPresentaciones()
        {
            InitializeComponent();
            presentacionController = new PresentacionController();
            ModoCreate = true;
        }

        public FrmPresentaciones(dynamic objeto)
        {
            InitializeComponent();
            presentacionController = new PresentacionController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Presentacion)this.objeto;
                TxtClave.Text = objeto.PresentacionId;
            }

        }

       

        private void LlenaCampos()
        {
            objeto = presentacionController.SelectOne(TxtClave.Text.Trim());
            if (objeto == null)
                ModoCreate = true;
            else
            {
                ModoCreate = false;
                TxtClave.Text = objeto.PresentacionId;
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

                objeto = new Presentacion();
                objeto.PresentacionId = TxtClave.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();
                if (presentacionController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Nombre = TxtNombre.Text.Trim();
                if (presentacionController.Update(objeto))
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
