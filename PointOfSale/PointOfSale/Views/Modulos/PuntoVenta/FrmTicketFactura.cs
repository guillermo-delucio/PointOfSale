using PointOfSale.CFDI33;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
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
    public partial class FrmTicketFactura : Form
    {
        private VentaController ventaController;
        private VentapController ventapController;
        private ClienteController clienteController;
        private EmpresaController empresaController;

        private Empresa empresa;
        private Cliente cliente;
        private CUsocfdi usocfdi;
        private CMetodopago metodoPago;
        private FormaPago formaPago;
        private Venta venta;
        private List<Ventap> partidas;
        private StiReport report;
        private DataSet ds;

        public FrmTicketFactura()
        {
            InitializeComponent();
            Reset();
        }
        private void Reset()
        {
            ventaController = new VentaController();
            ventapController = new VentapController();
            clienteController = new ClienteController();
            empresaController = new EmpresaController();
            partidas = new List<Ventap>();
            report = new StiReport();
            ds = new DataSet();

            empresa = empresaController.SelectTopOne();
            report.Load(empresa.RutaFormatoFactura);
            cliente = null;
            venta = null;


        }

        private bool ClonarVenta()
        {
            if (venta == null)
            {
                Ambiente.Mensaje("La venta ya no existe");
                return false;
            }

            partidas = ventapController.SelectPartidas(venta.VentaId);
            if (partidas.Count == 0)
            {
                Ambiente.Mensaje("La venta ya no tiene partidas");
                return false;
            }

            //Anular la el ticket antes de insertar la factura
            venta.Anulada = true;
            if (ventaController.UpdateOne(venta))
            {
                if (!ChkMismoCliente.Checked)
                {
                    if (cliente == null || formaPago == null || metodoPago == null || usocfdi == null)
                    {
                        Ambiente.Mensaje("cliente || formaPago || metodoPago || usocfdi == null");
                        venta.Anulada = false;
                        ventaController.UpdateOne(venta);
                        return false;
                    }

                    venta.ClienteId = cliente.ClienteId;
                    venta.FormaPago1 = formaPago.FormaPagoId;
                    venta.MetodoPago = metodoPago.MetodoPagoId;
                    venta.UsoCfdi = usocfdi.UsoCfdiid;

                }

                venta.NoRef = Ambiente.TraeSiguiente("FAC");
                venta.VentaOrigen = venta.VentaId;
                venta.VentaId = 0;
                venta.TipoDocId = "FAC";
                venta.Anulada = false;
                venta.EsConversiondeTaF = true;
                if (ventaController.InsertOne(venta))
                {
                    foreach (var p in partidas)
                    {
                        p.VentapId = 0;
                        p.VentaId = venta.VentaId;
                        if (!ventapController.InsertOne(p))
                            Ambiente.Mensaje("La partida tuvo problemas al re-insertarse");
                    }
                }
                else
                {
                    Ambiente.Mensaje("Imposible re-insertar la venta");
                    return false;
                }
            }
            else
            {
                Ambiente.Mensaje("Imposible anular el ticket");
                return false;
            }
            return true;
        }
        private void CargarDatos()
        {
            if (venta != null)
            {
                TxtCliente.Text = venta.ClienteId;
                TxtUsoCFDI.Text = venta.UsoCfdi;
                TxtFormaPago.Text = venta.FormaPago1;
                TxtMetodoPago.Text = venta.MetodoPago;
                Malla.Rows.Clear();
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = venta.NoRef;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = venta.EstadoDocId;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = venta.DatosCliente;
            }
            else
            {

                TxtCliente.Text = "";
                TxtUsoCFDI.Text = "";
                TxtFormaPago.Text = "";
                TxtMetodoPago.Text = "";
                Malla.Rows.Clear();
                Ambiente.Mensaje("El ticket no existe");
            }
        }
        private bool Facturar()
        {
            var oCFDI = new CFDI();
            oCFDI.Venta = venta;
            return oCFDI.Facturar();
        }
        private bool GenerarPDF()
        {
            ds = new DataSet();
            ds.Tables.Add(Ambiente.DT("select * from venta where VentaId=" + venta.VentaId, "v"));
            ds.Tables.Add(Ambiente.DT("select * from ventap where VentaId=" + venta.VentaId, "vp"));
            ds.Tables.Add(Ambiente.DT("select * from cliente where ClienteId=" + venta.ClienteId, "c"));
            ds.Tables.Add(Ambiente.DT("select top 1 * from Empresa", "e"));
            report.RegData(ds);
            report.Dictionary.Synchronize();
            // Design report in Designer dialog window
            report.Design();
            return true;
        }

        private void TxtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtCliente.Text.Trim(), (int)Ambiente.TipoBusqueda.Clientes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        cliente = form.Cliente;
                        TxtCliente.Text = cliente.RazonSocial;
                    }
                }
            }
        }

        private void TxtUsoCFDI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtUsoCFDI.Text.Trim(), (int)Ambiente.TipoBusqueda.UsoCDFI))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        usocfdi = form.Usocfdi;
                        TxtUsoCFDI.Text = usocfdi.Descripcion;
                    }
                }
            }
        }

        private void TxtFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtFormaPago.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        formaPago = form.FormaPago;
                        TxtFormaPago.Text = formaPago.Descripcion;
                    }
                }
            }
        }

        private void TxtMetodoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtMetodoPago.Text.Trim(), (int)Ambiente.TipoBusqueda.MetodoPago))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        metodoPago = form.MetodoPago;
                        TxtMetodoPago.Text = metodoPago.Descripcion;
                    }
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ClonarVenta())
                if (Facturar())
                    if (!GenerarPDF())
                        Ambiente.Mensaje("Algo salio mal al generar el PDF");
                    else
                        Ambiente.Mensaje("Proceso completado");




        }

        private void TxtNoRereren_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                int referencia = int.Parse(TxtNoRereren.Text.Trim());
                venta = ventaController.SelectTicket(referencia);
                CargarDatos();
            }
        }

        private void TxtNoRereren_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

        }
    }
}

