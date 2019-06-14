using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
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
    public partial class FrmPointOfSale : Form
    {
        Cliente cliente;
        Venta venta;
        Ventap ventaP;
        Producto producto;



        public FrmPointOfSale()
        {
            InitializeComponent();

        }


        private void FrmPointOfSale_Load(object sender, EventArgs e)
        {
            InicializaPOS();
        }



        private void TxtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LanzaBusquedaClientes();
            }
        }


        private void InicializaPOS()
        {

        }

        private void LanzaBusquedaClientes()
        {
            using (var form = new FrmBusqueda(TxtCliente.Text.Trim(), (int)Ambiente.TipoBusqueda.Clientes))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    cliente = form.Cliente;
                    TxtCliente.Text = form.Cliente.RazonSocial;
                }
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            LanzaBusquedaClientes();
        }

        private void BtnBuscarProd_Click(object sender, EventArgs e)
        {
            using (var form = new FrmBuscaProducto())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TxtProductoId.Text = form.Producto.ProductoId;
                    TxtProductoId.Focus();
                }
            }
        }

        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InsertaPartida();
            }
        }

        private void InsertaPartida()
        {
            MessageBox.Show("Partida Insertada");
        }
    }
}
