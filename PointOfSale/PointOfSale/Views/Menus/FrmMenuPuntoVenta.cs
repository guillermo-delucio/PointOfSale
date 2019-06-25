using System;
using System.Windows.Forms;

namespace PointOfSale.Views.Menus
{
    public partial class FrmMenuPuntoVenta : Form
    {
        public FrmMenuPuntoVenta()
        {
            InitializeComponent();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            var o = new PointOfSale.Views.Modulos.PuntoVenta.PointOfSale();
            o.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
