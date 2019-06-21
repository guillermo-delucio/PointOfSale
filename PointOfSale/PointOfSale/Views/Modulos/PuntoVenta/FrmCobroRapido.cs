using PointOfSale.Controllers;
using PointOfSale.Controllers.Utils;
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
    public partial class FrmCobroRapido : Form
    {
        private Moneda moneda;
        public decimal total;
        public decimal pago1;
        public decimal pago2;
        public decimal pago3;
        public decimal cambio;

        public string formapago1;
        public string formapago2;
        public string formapago3;
        public string concepto1;
        public string concepto2;
        public string concepto3;
        public string totalLetra;
        public string tipoDoc;
        public bool Cxc;


        public FrmCobroRapido()
        {
            InitializeComponent();
        }

        public FrmCobroRapido(decimal total)
        {
            InitializeComponent();
            this.total = total;
            InicializaCampos();
        }

        private void InicializaCampos()
        {
            TxtTotal.Text = total.ToString();
            TxtPago1.Text = total.ToString();
            formapago1 = "01";
            concepto1 = "EFECTIVO";
            formapago2 = null;
            concepto2 = null;
            formapago3 = null;
            concepto3 = null;
            totalLetra = "";
            pago1 = 0;
            pago2 = 0;
            pago3 = 0;
            Cxc = false;
            moneda = new Moneda();
        }

        private void TxtConceptoPago2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtConceptoPago2.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtFormaPago2.Text = form.FormaPago.FormaPagoId;
                        TxtConceptoPago2.Text = form.FormaPago.Descripcion.ToUpper();
                    }
                }
            }
        }

        private void TxtConceptoPago3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtConceptoPago3.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtFormaPago3.Text = form.FormaPago.FormaPagoId;
                        TxtConceptoPago3.Text = form.FormaPago.Descripcion.ToUpper();
                    }
                }
            }
        }

        private void RFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (RFactura.Checked)
                tipoDoc = "FAC";
        }

        private void RTicket_CheckedChanged(object sender, EventArgs e)
        {
            if (RTicket.Checked)
                tipoDoc = "TIC";
        }

        private void TxtPago1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculaCambio();
                if (cambio >= 0)
                    BtnAceptar.Focus();
            }
        }

        private void TxtPago1_TextChanged(object sender, EventArgs e)
        {
            CalculaCambio();
        }

        private void CalculaCambio()
        {
            decimal.TryParse(TxtPago1.Text.Trim(), out pago1);
            decimal.TryParse(TxtPago2.Text.Trim(), out pago2);
            decimal.TryParse(TxtPago3.Text.Trim(), out pago3);

            cambio = total - (pago1 + pago2 + pago3);
            cambio *= -1;
            TxtCambio.Text = cambio.ToString();
        }

        private void TxtPago1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void TxtPago2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void TxtPago3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void TxtConceptoPago1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtConceptoPago1.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtFormaPago1.Text = form.FormaPago.FormaPagoId;
                        TxtConceptoPago1.Text = form.FormaPago.Descripcion.ToUpper();
                    }
                }
            }
        }

        private void TxtPago2_TextChanged(object sender, EventArgs e)
        {
            CalculaCambio();
        }

        private void TxtPago3_TextChanged(object sender, EventArgs e)
        {
            CalculaCambio();
        }

        private void TxtPago2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculaCambio();
                if (cambio >= 0)
                    BtnAceptar.Focus();
            }
        }

        private void TxtPago3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculaCambio();
                if (cambio >= 0)
                    BtnAceptar.Focus();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Cxc = false;
            CerrarVenta();
        }

        private void CerrarVenta()
        {

            if (cambio < 0)
            {
                Ambiente.Mensaje("Liquida el documento o mándalo a cuentas por cobrar");
                return;
            }


            totalLetra = moneda.Convertir(total.ToString(), true);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TxtFormaPago1_TextChanged(object sender, EventArgs e)
        {
            formapago1 = TxtFormaPago1.Text.Trim();
        }

        private void TxtFormaPago2_TextChanged(object sender, EventArgs e)
        {
            formapago2 = TxtFormaPago2.Text.Trim();
        }

        private void TxtFormaPago3_TextChanged(object sender, EventArgs e)
        {
            formapago3 = TxtFormaPago3.Text.Trim();
        }

        private void TxtConceptoPago1_TextChanged(object sender, EventArgs e)
        {
            concepto1 = TxtConceptoPago1.Text.Trim();
        }

        private void TxtConceptoPago2_TextChanged(object sender, EventArgs e)
        {
            concepto2 = TxtConceptoPago2.Text.Trim();
        }

        private void TxtConceptoPago3_TextChanged(object sender, EventArgs e)
        {
            concepto3 = TxtConceptoPago3.Text.Trim();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnCXC_Click(object sender, EventArgs e)
        {
            Cxc = true;
            CerrarVenta();
        }
    }
}
