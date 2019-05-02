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
    public partial class FrmLaboratorios : Form
    {
        private dynamic objeto;
        private LaboratorioController laboratorioController;
        bool ModoCreate;

        public FrmLaboratorios()
        {
            InitializeComponent();
            laboratorioController = new LaboratorioController();
            ModoCreate = true;
        }

        public FrmLaboratorios(dynamic objeto)
        {
            InitializeComponent();
            laboratorioController = new LaboratorioController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Laboratorio)this.objeto;
                TxtClave.Text = objeto.LaboratorioId;
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
                TxtClave.Text = objeto.LaboratorioId;
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

                objeto = new Laboratorio();
                objeto.LaboratorioId = TxtClave.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();
                if (laboratorioController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Nombre = TxtNombre.Text.Trim();
                if (laboratorioController.Update(objeto))
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
