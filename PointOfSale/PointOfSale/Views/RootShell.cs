using DYM.Views;
using PointOfSale.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views
{
    public partial class RootShell : Form
    {

        public RootShell()
        {
            InitializeComponent();
            Inicializador.IniciliazaConexion();
            Inicializador.InicializaListas();
            Inicializador.InicializaProdiedades();
            GetLogin();
        }

        private void GetLogin()
        {
            var form = new FrmLogin
            {
                MdiParent = this
            };
            form.Show();
        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            var form = new FrmMain()
            {
                MdiParent = this
            };
            form.Show();
        }
    }
}
