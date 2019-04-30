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

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmBusinessManager : Form
    {
        BMController bMController;
        string NodoName;
        dynamic SelectedObject;
        public FrmBusinessManager()
        {
            InitializeComponent();
            bMController = new BMController();
            NodoName = string.Empty;
        }



        private void BMtree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            NodoName = BMtree.SelectedNode.Name;
            if (NodoName.Length > 0)
                bMController.LlenaNodo(NodoName, Grid1);
        }

        private void ImportarDesdeExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NodoName.Length > 0)
                bMController.Importa(NodoName, Grid1);
        }


        private void Grid1_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value != null)
                SelectedObject = bMController.GetSelectedObject(NodoName, Grid1);

        }

        private void BtnBMUpdate_Click(object sender, EventArgs e)
        {
            bMController.LanzaFormaUpdate(NodoName, SelectedObject);
        }

        private void BtnBMEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BtnBMAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
