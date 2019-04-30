using PointOfSale.Views.Modulos.Catalogos;
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
    }
}
