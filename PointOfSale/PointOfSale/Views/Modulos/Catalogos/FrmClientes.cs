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
    public partial class FrmClientes : Form
    {
        private dynamic objeto;

        public FrmClientes()
        {
            InitializeComponent();
        }

        public FrmClientes(dynamic objeto)
        {
            this.objeto = objeto;
        }
    }
}
