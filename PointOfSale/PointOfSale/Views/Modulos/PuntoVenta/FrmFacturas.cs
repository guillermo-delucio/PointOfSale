using PointOfSale.CFDI33;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using PointOfSale.Views.Modulos.Catalogos;
using Stimulsoft.Report;
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
    public partial class FrmFacturas : Form
    {
        private VentaController ventaController;
        private ClienteController clienteController;
        private EmpresaController empresaController;
        private Cliente cliente;
        private Empresa empresa;
        private CFDI oCFDI;
        private StiReport report;

        List<Venta> facturas;
        public FrmFacturas()
        {
            InitializeComponent();
            ventaController = new VentaController();
            clienteController = new ClienteController();
            empresaController = new EmpresaController();
            oCFDI = new CFDI();
            cliente = null;
            empresa = empresaController.SelectTopOne();
        }


        private void CargaGrid()
        {

            facturas = ventaController.SelectFacturas(DpFechaIni.Value.Date, DpFechaFin.Value.Date, ChkSinTimbrar.Checked);

            Grid.Rows.Clear();
            foreach (var f in facturas)
            {
                Grid.Rows.Add();
                cliente = clienteController.SelectOne(f.ClienteId);
                Grid.Rows[Grid.RowCount - 1].Cells[0].Value = f.VentaId;
                Grid.Rows[Grid.RowCount - 1].Cells[1].Value = f.NoRef;
                Grid.Rows[Grid.RowCount - 1].Cells[2].Value = f.CreatedAt;
                Grid.Rows[Grid.RowCount - 1].Cells[3].Value = cliente.RazonSocial.Trim().Length == 0 ? cliente.Negocio : cliente.RazonSocial;
                Grid.Rows[Grid.RowCount - 1].Cells[4].Value = f.Total;
                Grid.Rows[Grid.RowCount - 1].Cells[5].Value = f.UuId;
            }
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            CargaGrid();
        }

        private void BtnCambiarCliente_Click(object sender, EventArgs e)
        {
            if (Grid.RowCount > 0)
            {
                int index = Grid.CurrentCell.RowIndex;
                int i = 0;
                foreach (var f in facturas)
                {
                    if (index == i)
                    {
                        cliente = clienteController.SelectOne(f.ClienteId);
                        oCFDI.Venta = f;
                        var c = new FrmClientes(cliente);
                        c.Show();
                    }
                    i++;
                }
            }

        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {

            if (oCFDI.Venta == null)
            {
                Ambiente.Mensaje("Primero actualice los datos del cliente");
                return;
            }
            if (oCFDI.Venta.UuId == null)
            {
                Ambiente.SaveAndPrintFactura(oCFDI.Venta, false, true);
                Close();
            }
            else
                Ambiente.Mensaje("Este documento ya es un CDFI");
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnFiltrarFecha_Click(object sender, EventArgs e)
        {
            CargaGrid();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
