using PointOfSale.Controllers;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class FrmMetodoPago : Form
    {
        public string MetodoPago { get; set; }
        public FrmMetodoPago()
        {
            InitializeComponent();
            MetodoPago = "PUE";
        }


        private void TxtMetodoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtMetodoPago.Text.Trim(), (int)Ambiente.TipoBusqueda.MetodoPago))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtMetodoPagoId.Text = form.MetodoPago.MetodoPagoId;
                        TxtMetodoPago.Text = form.MetodoPago.Descripcion;
                        MetodoPago = form.MetodoPago.MetodoPagoId;
                    }
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
