using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmEntradasPorCompra : Form
    {
        public FrmEntradasPorCompra()
        {
            InitializeComponent();
        }

        private void TxtDescuento_Leave(object sender, EventArgs e)
        {
            TxtU1.Focus();
        }

        private void TxtPrecio4_Leave(object sender, EventArgs e)
        {
            BtnAgregar.Focus();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            TxtProductoId.Focus();
        }
    }
}
