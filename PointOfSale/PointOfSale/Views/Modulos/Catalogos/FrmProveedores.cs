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
    public partial class FrmProveedores : Form
    {
        private dynamic objeto;

        public FrmProveedores()
        {
            InitializeComponent();
        }

        public FrmProveedores(dynamic objeto)
        {
            this.objeto = objeto;
        }
    }
}
