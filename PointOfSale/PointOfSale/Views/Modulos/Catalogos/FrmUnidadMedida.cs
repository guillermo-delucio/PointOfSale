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
    public partial class FrmUnidadMedida : Form
    {
        private dynamic objeto;
        private UnidadMedidaController unidadMedidaController;
        bool ModoCreate;

        public FrmUnidadMedida()
        {
            InitializeComponent();
            unidadMedidaController = new UnidadMedidaController();
            ModoCreate = true;
        }

        public FrmUnidadMedida(dynamic objeto)
        {
            InitializeComponent();
            unidadMedidaController = new UnidadMedidaController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (UnidadMedida)this.objeto;
                TxtClave.Text = objeto.UnidadMedidaId;
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
                TxtClave.Text = objeto.UnidadMedidaId;
                TxtNombre.Text = objeto.Nombre;
                TxtUnidadSat.Text = objeto.UnidadSat;

            }


        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Ambiente.Pregunta("¡ADVERTENCIA! \n\n SI LA EQUIVALENCIA SAT ES INCORRECTA, NO SE PODRÁ EMITIR FACTURAS CON ESTA UNIDAD. \nQUIERE CONTINUAR"))
                InsertOrUpdate();
            else
                MessageBox.Show("Proceso abortado");

        }

        private void InsertOrUpdate()
        {
            if (ModoCreate)
            {
                if (TxtClave.Text.Trim().Length == 0)
                    return;

                objeto = new UnidadMedida();
                objeto.UnidadMedidaId = TxtClave.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();
                objeto.UnidadSat = TxtUnidadSat.Text.Trim();
                if (unidadMedidaController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Nombre = TxtNombre.Text.Trim();
                objeto.UnidadSat = TxtUnidadSat.Text.Trim();
                if (unidadMedidaController.Update(objeto))
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
