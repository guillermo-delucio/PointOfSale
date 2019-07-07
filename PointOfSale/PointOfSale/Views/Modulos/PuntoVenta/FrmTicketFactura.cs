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
    public partial class FrmTicketFactura : Form
    {
        private Cliente cliente;
        private Venta ventaO;
        private Venta ventaN;
        private VentaController ventaController;
        private VentapController ventapController;
        private ClienteController clienteController;
        private List<Ventap> partidas;


        public FrmTicketFactura()
        {
            InitializeComponent();
            Reset();
        }
        private void Reset()
        {

            cliente = null;
            ventaO = null;
            ventaN = null;
            ventaController = new VentaController();
            ventapController = new VentapController();
            clienteController = new ClienteController();
            partidas = new List<Ventap>();
            TxtClienteId.Text = string.Empty;
            TxtClienteId.Text = string.Empty;
            Malla.Rows.Clear();
        }
        private void CargaDatos()
        {
            if (ventaO == null)
                return;

            cliente = clienteController.SelectOne(ventaO.ClienteId);
            if (cliente != null)
            {
                TxtClienteId.Text = cliente.Negocio;

                Malla.Rows.Clear();
                Malla.Refresh();
                partidas = ventapController.SelectPartidas(ventaO.VentaId);

                if (partidas.Count > 0)
                {
                    Malla.Rows.Add();
                    Malla.Rows[Malla.RowCount - 1].Cells[0].Value = ventaO.NoRef;
                    Malla.Rows[Malla.RowCount - 1].Cells[1].Value = ventaO.DatosCliente;
                }
                BtnAceptar.Focus();
            }
            else
                Ambiente.Mensaje("El cliente ya no existe");
        }

        private bool Facturar()
        {


            Ambiente.Mensaje("Facturado");

            return true;

        }

        private bool ClonaVenta()
        {
            bool succes = false;

            ventaO.Anulada = false;

            if (ventaController.UpdateOne(ventaO))
            {

                ventaO.EsConversiondeTaF = true;
                ventaO.TipoDocId = "FAC";
                ventaO.Anulada = false;
                ventaO.NoRef = Ambiente.TraeSiguiente("FAC");
                ventaO.VentaOrigen = ventaO.VentaId;
                ventaO.VentaId = 0;
                if (ventaController.InsertOne(ventaO))
                {
                    Ambiente.UpdateSiguiente("FAC");
                    foreach (var p in partidas)
                    {
                        p.VentapId = 0;
                        p.VentaId = ventaO.VentaId;
                        succes = ventapController.InsertOne(p);
                    }
                }
            }
            return succes;
        }
        private void TxtNoRereren_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (TxtNoRereren.Text.Trim().Length == 0)
                    return;

                int NoRef = int.Parse(TxtNoRereren.Text.Trim());
                ventaO = ventaController.SelectTicket(NoRef);

                if (ventaO == null)
                {
                    Reset();
                    Ambiente.Mensaje("El ticket no existe");
                }

                CargaDatos();
            }
        }

        private void TxtClienteId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtClienteId.Text, (int)Ambiente.TipoBusqueda.Clientes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        cliente = form.Cliente;
                        TxtClienteId.Text = cliente.Negocio;
                    }
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtNoRereren_Leave(object sender, EventArgs e)
        {

        }

        private void TxtClienteId_Leave(object sender, EventArgs e)
        {

        }

        private void ChkMismoCliente_Leave(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ClonaVenta())
                if (Facturar())
                {

                }
        }
    }
}
