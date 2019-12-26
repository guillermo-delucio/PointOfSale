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
    public partial class FrmBuscadorReportes : Form
    {
        public Reporte reporte;
        private ReporteController reporteController;
        public FrmBuscadorReportes()
        {
            InitializeComponent();
            reporteController = new ReporteController();
            reporte = null;
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
            foreach (var r in reporteController.FiltrarVsNombre(TxtNombreRep.Text))
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = r.ReporteId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = r.Nombre;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = r.DelSistema;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = r.Parametrizado;
            }
            Malla.Focus();
        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelecionarCerrar();
            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            SelecionarCerrar();
        }

        private void SelecionarCerrar()
        {
            if (Malla.RowCount > 0)
            {
                if (Malla.CurrentRow.Index >= 0)
                {
                    reporte = reporteController.SelectOneByName(Malla.Rows[Malla.CurrentRow.Index].Cells[1].Value.ToString());
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
