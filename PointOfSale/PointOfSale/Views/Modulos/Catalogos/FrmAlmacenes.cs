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
    public partial class FrmAlmacenes : Form
    {
        private dynamic objeto;

        public FrmAlmacenes()
        {
            InitializeComponent();
        }

        public FrmAlmacenes(dynamic objeto)
        {
            this.objeto = objeto;
        }
    }
}
