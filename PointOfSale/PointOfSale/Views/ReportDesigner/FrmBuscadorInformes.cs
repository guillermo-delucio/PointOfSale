using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.ReportDesigner
{
    public partial class FrmBuscadorInformes : Form
    {
        public Informe Informe { get; set; }
        private InformeController informeController;
        public FrmBuscadorInformes()
        {
            InitializeComponent();
            Informe = null;
            informeController = new InformeController();
        }

        private void TxtNombreRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RecargarGrid();
            }
        }
        private void RecargarGrid()
        {
            Malla.Rows.Clear();
            foreach (var r in informeController.SelectByDescrip(TxtNombreRep.Text))
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = r.InformeId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = r.Sistema;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = r.Descripcion;
            }
            Malla.Focus();
        }
        private void Selecionar()
        {
            if (Malla.RowCount > 0)
            {
                if (Malla.CurrentRow.Index >= 0)
                {
                    Informe = informeController.SelectOne(int.Parse(Malla.Rows[Malla.CurrentRow.Index].Cells[0].Value.ToString()));
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            Selecionar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Selecionar();
            }
        }
    }
}
