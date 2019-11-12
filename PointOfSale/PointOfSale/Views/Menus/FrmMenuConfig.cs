using PointOfSale.Views.Modulos.Catalogos;
using PointOfSale.Views.Modulos.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Menus
{
    public partial class FrmMenuConfig : Form
    {
        public FrmMenuConfig()
        {
            InitializeComponent();
        }

        private void BtnEmpresa_Click(object sender, EventArgs e)
        {
            var o = new FrmEmpresa();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnEstaciones_Click(object sender, EventArgs e)
        {
            var o = new FrmEstaciones();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnMonedero_Click(object sender, EventArgs e)
        {
            var o = new FrmPuntosConfig();
            o.MdiParent = MdiParent;
            o.Show();
        }
    }
}
