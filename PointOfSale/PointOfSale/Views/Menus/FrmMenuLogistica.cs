using PointOfSale.Views.Modulos.Catalogos;
using PointOfSale.Views.Modulos.Logistica;
using System;
using System.Windows.Forms;

namespace DYM.Views
{
    public partial class FrmMenuLogistica : Form
    {
        public FrmMenuLogistica()
        {
            InitializeComponent();
        }

        private void BtnProductosCapturaPrecios_Click(object sender, EventArgs e)
        {
            var o = new FrmProductos
            {
                MdiParent = this.ParentForm
            };
            o.Show();
        }

        private void BtnSalida_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var o = new FrmEntradaPorCompra2
            {
                MdiParent = this.ParentForm
            };
            o.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var o = new FrmSalidasPorTraspaso
            {
                MdiParent = this.ParentForm
            };
            o.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var o = new FrmEntradasPorTraspaso
            {
                MdiParent = this.ParentForm
            };
            o.Show();
        }
    }
}
