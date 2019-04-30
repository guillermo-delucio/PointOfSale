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
    public partial class FrmPresentaciones : Form
    {
        private dynamic objeto;

        public FrmPresentaciones()
        {
            InitializeComponent();
        }

        public FrmPresentaciones(dynamic objeto)
        {
            this.objeto = objeto;
        }
    }
}
