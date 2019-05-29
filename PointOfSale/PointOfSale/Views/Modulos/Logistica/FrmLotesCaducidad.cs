using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmLotesCaducidad : Form
    {
        private Producto producto;
        private decimal cantidad;
        private bool modover;
        private LoteController loteController;
        ProductoController productoController;

        public FrmLotesCaducidad()
        {
            InitializeComponent();
            loteController = new LoteController();
            productoController = new ProductoController();
            modover = true;
            this.producto = null;
            this.cantidad = 0;
            NCantidad.Maximum = cantidad;
        }

        public FrmLotesCaducidad(Producto p, decimal c)
        {
            InitializeComponent();
            this.producto = p;
            this.cantidad = c;
            modover = false;
            loteController = new LoteController();
            productoController = new ProductoController();
            TxtProductoId.Text = producto.ProductoId;
            NCantidad.Maximum = cantidad;
        }



        private void CargaGrid(string productoId)
        {
            List<Lote> lotes = loteController.SelectMany(productoId);

            GridPartidas.Rows.Clear();
            GridPartidas.Refresh();
            foreach (var l in lotes)
            {
                GridPartidas.Rows.Add();
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = l.LoteId;
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = l.Caducidad;
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = l.StockInicial;
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = l.StockRestante;
            }


        }



        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                producto = productoController.SelectOne(TxtProductoId.Text);
                if (producto != null)
                {
                    CargaGrid(producto.ProductoId);
                    NCantidad.Value = cantidad;
                    NCantidad.Focus();
                    return;
                }
                using (var form = new FrmBusqueda(TxtProductoId.Text, (int)Ambiente.TipoBusqueda.Productos))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtProductoId.Text = form.Producto.ProductoId;
                    }
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!modover && cantidad > 0)
            {
                if (TxtLoteId.Text.Trim().Length == 0 || producto == null || NCantidad.Value == 0)
                {
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-8]);
                    return;
                }
                InsertaPartidaGrid();
                InsertaPartidadb();
            }
            else
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-8]);
        }
        private void InsertaPartidaGrid()
        {
            GridPartidas.Rows.Add();
            GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = TxtLoteId.Text;
            GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = DpFechaCaducidad.Value;
            GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = NCantidad.Value;
            GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = NCantidad.Value;
        }

        private void InsertaPartidadb()
        {
            var lotep = new Lote();
            lotep.LoteId = TxtLoteId.Text;
            lotep.ProductoId = producto.ProductoId;
            lotep.Caducidad = DpFechaCaducidad.Value;
            lotep.StockInicial = NCantidad.Value;
            lotep.StockRestante = NCantidad.Value;
            lotep.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            lotep.CreatedAt = DateTime.Now;
            cantidad -= NCantidad.Value;
            if (!loteController.InsertOne(lotep))
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);

        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            if (cantidad == 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-8] + " HAY " + cantidad + "EXISTENCIAS SIN LOTE");
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (cantidad == 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-8] + " HAY " + cantidad + "EXISTENCIAS SIN LOTE");
        }
    }
}
