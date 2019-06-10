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
    public partial class FrmImpuestos : Form
    {
        private dynamic objeto;
        private ImpuestoController impuestoController;
        bool ModoCreate;

        public FrmImpuestos()
        {
            InitializeComponent();
            impuestoController = new ImpuestoController();
            ModoCreate = true;
        }

        public FrmImpuestos(dynamic objeto)
        {
            InitializeComponent();
            impuestoController = new ImpuestoController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Impuesto)this.objeto;
                TxtImpuestoId.Text = objeto.ImpuestoId;
            }

        }


        private void LlenaCampos()
        {
            if (objeto == null)
                ModoCreate = true;
            else
            {
                ModoCreate = false;
                TxtImpuestoId.Text = objeto.ImpuestoId;
                TxtTasa.Text = objeto.Tasa.ToString();
                TxtClaveSat.Text = objeto.CImpuesto;

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
                if (TxtImpuestoId.Text.Trim().Length == 0)
                    return;

                objeto = new Impuesto();
                objeto.ImpuestoId = TxtImpuestoId.Text.Trim();
                objeto.CImpuesto = TxtClaveSat.Text.Trim().Length == 0 ? "002" : TxtClaveSat.Text.Trim();
                // objeto.
                if (decimal.TryParse(TxtTasa.Text.Trim(), out decimal DecTasa))
                    objeto.Tasa = DecTasa;
                else
                {
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-7]);
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                    return;
                }




                if (impuestoController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                if (decimal.TryParse(TxtTasa.Text.Trim(), out decimal DecTasa))
                    objeto.Tasa = DecTasa;

                else
                {
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-7]);
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                    return;
                }
                objeto.CImpuesto = TxtClaveSat.Text.Trim().Length == 0 ? "002" : TxtClaveSat.Text.Trim();
                if (impuestoController.Update(objeto))
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
