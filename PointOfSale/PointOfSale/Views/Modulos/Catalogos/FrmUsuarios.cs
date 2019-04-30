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
    public partial class FrmUsuarios : Form
    {
        private dynamic objeto;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        public FrmUsuarios(dynamic objeto)
        {
            this.objeto = objeto;
        }
    }
}
