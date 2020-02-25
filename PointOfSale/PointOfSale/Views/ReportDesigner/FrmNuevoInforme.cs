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
    public partial class FrmNuevoInforme : Form
    {
        private InformeCategoria informeCategoria;
        private InformeCategoriaController informeCategoriaController;


        public string Descrip { get; set; }
        public int CategoriaId { get; set; }
        public bool Sistema { get; set; }
        public FrmNuevoInforme()
        {
            InitializeComponent();
            CargarCategorias();
        }

        public FrmNuevoInforme(int informeCateforiaId, string descripcion, bool sistema)
        {
            InitializeComponent();
            //CategoriaId = informeCateforiaId;

            Descrip = descripcion;
            TxtDescripcion.Text = descripcion;
            CargarCategorias(informeCateforiaId, sistema);
        }

        private void CargarCategorias()
        {
            informeCategoriaController = new InformeCategoriaController();
            CboCategorias.DataSource = informeCategoriaController.SelectAll();
            CboCategorias.ValueMember = "InformeCategoriaId";
            CboCategorias.DisplayMember = "Nombre";
        }
        private void CargarCategorias(int categoriaId, bool sis)
        {
            informeCategoriaController = new InformeCategoriaController();

            CboCategorias.DataSource = informeCategoriaController.SelectAll();
            CboCategorias.ValueMember = "InformeCategoriaId";
            CboCategorias.DisplayMember = "Nombre";
            CboCategorias.SelectedValue = categoriaId;
            ChkSistema.Checked = sis;
            if (sis)
            {
                TxtDescripcion.Enabled = false;
                CboCategorias.Enabled = false;
                ChkSistema.Enabled = false;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if ((int)CboCategorias.SelectedValue <= 0)
            {
                Ambiente.Mensaje("Informe todos los campos");
                return;
            }
            if (TxtDescripcion.Text.Equals(""))
            {
                Ambiente.Mensaje("Informe todos los campos");
                return;
            }

            CategoriaId = int.Parse(CboCategorias.SelectedValue.ToString());
            Descrip = TxtDescripcion.Text.Trim();
            Sistema = ChkSistema.Checked;
            DialogResult = DialogResult.OK;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (Ambiente.Pregunta("El reporte se perderá, quiere continuar"))
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
