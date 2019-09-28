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

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class FrmBuscaProducto : Form
    {
        public Producto Producto { get; set; }

        readonly ProductoController ProductoController;
        readonly PresentacionController PresentacionController;
        readonly LaboratorioController LaboratorioController;


        public FrmBuscaProducto()
        {
            InitializeComponent();
            ProductoController = new ProductoController();
            PresentacionController = new PresentacionController();
            LaboratorioController = new LaboratorioController();

        }

        private void TxtDescrip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenaGrid(ProductoController.FiltrarVsDescrip(TxtDescrip.Text));
            }
        }

        private void LlenaGrid(List<Producto> productos)
        {
            Mallap.Rows.Clear();
            Mallap.Refresh();
            foreach (var p in productos)
            {
                Mallap.Rows.Add();
                Mallap.Rows[Mallap.RowCount - 1].Cells[0].Value = p.Descripcion;
                Mallap.Rows[Mallap.RowCount - 1].Cells[1].Value = p.Contenido;
                var pr = PresentacionController.SelectOne(p.PresentacionId);
                if (pr != null)
                    Mallap.Rows[Mallap.RowCount - 1].Cells[2].Value = pr.Nombre;
                else
                    Mallap.Rows[Mallap.RowCount - 1].Cells[2].Value = "SYS";

                var lab = LaboratorioController.SelectOne(p.LaboratorioId);
                if (lab != null)
                    Mallap.Rows[Mallap.RowCount - 1].Cells[3].Value = lab.Nombre;
                else
                    Mallap.Rows[Mallap.RowCount - 1].Cells[3].Value = "SYS";

                Mallap.Rows[Mallap.RowCount - 1].Cells[4].Value = p.Unidades;
                Mallap.Rows[Mallap.RowCount - 1].Cells[5].Value = Math.Round(Ambiente.GetPrecioSalida(p), 1);
                Mallap.Rows[Mallap.RowCount - 1].Cells[6].Value = p.Stock;
                Mallap.Rows[Mallap.RowCount - 1].Cells[7].Value = p.ProductoId;
            }
            LblCoincidencias.Text = productos.Count + " Coincidencias";
            if (Mallap.RowCount > 0)
            {
                Mallap.Focus();
                Mallap.Rows[0].Selected = true;
            }

        }

        private void TxtSustancia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenaGrid(ProductoController.FiltrarVsSustancia(TxtSustancia.Text));

            }
        }

        private void Mallap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Mallap.Rows[Mallap.CurrentCell.RowIndex].Cells[0].Value != null)
                {
                    Producto = ProductoController.SelectOne(Mallap.Rows[Mallap.CurrentCell.RowIndex].Cells[7].Value.ToString());
                    CargaConfigProd();
                }
                DescargaForma();
            }
        }

        private void DescargaForma()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Mallap_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void CargaConfigProd()
        {
            Mallas.Rows.Clear();
            Mallas.Refresh();
            foreach (var s in Producto.ProductoSustancia)
            {
                Mallas.Rows.Add();
                Mallas.Rows[Mallas.RowCount - 1].Cells[0].Value = s.SustanciaId;
            }
            PbxImagen.Image = GetImg(Producto.RutaImg);
        }
        private Image GetImg(string ruta)
        {
            try
            {
                if (ruta == null)
                    return null;

                Image img = Image.FromFile(ruta);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (Mallap.RowCount == 0)
                return;

            if (Mallap.Rows[Mallap.CurrentCell.RowIndex].Cells[0].Value != null)
            {
                Producto = ProductoController.SelectOne(Mallap.Rows[Mallap.CurrentCell.RowIndex].Cells[7].Value.ToString());
                CargaConfigProd();
            }
            DescargaForma();
        }

        private void BtnBuscarXDescrip_Click(object sender, EventArgs e)
        {
            LlenaGrid(ProductoController.FiltrarVsDescrip(TxtDescrip.Text));
        }

        private void BtnBuscarXSustancia_Click(object sender, EventArgs e)
        {
            LlenaGrid(ProductoController.FiltrarVsSustancia(TxtSustancia.Text));
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
