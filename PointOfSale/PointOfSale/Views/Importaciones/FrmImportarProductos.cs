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

namespace PointOfSale.Views.Importaciones
{
    public partial class FrmImportarProductos : Form
    {

        ImportaExcelController ImportaExcelController;
        public FrmImportarProductos()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Productos);
        }
    }
}
