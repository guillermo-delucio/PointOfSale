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
        private int? noRef;

        public FrmTicketFactura()
        {
            InitializeComponent();
            Reset();
        }

        public FrmTicketFactura(int? noRef)
        {
            InitializeComponent();
            Reset();
            this.noRef = noRef;
            TxtNoRereren.Text = ((int)this.noRef).ToString();
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

            if (venta.UuId != null)
            {
                Ambiente.Mensaje("No se clono la venta. Este documento ya es  una factura. ");
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
                    Ambiente.UpdateSiguiente("FAC");
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
            if (!Ambiente.LoggedUser.Facturar)
            {
                Ambiente.Mensaje("Operacion denegada. No tienes permiso para operar esta vista.");
                return;
            }

            if (venta == null)
            {
                Ambiente.Mensaje("Proceso abortado, no se encontró ninguna venta seleccionada");
                return;
            }
            //Si no seleccionó otro cliente, se recupera el de la venta
            if (cliente == null)
                cliente = clienteController.SelectOne(venta.ClienteId);

            //verificar que no sea pago con puntos
            if (venta.PuntosAplicados || venta.DescXpuntos > 0)
            {
                Ambiente.Mensaje("Proceso abortado, el documento se cobró con puntos.");
                return;
            }

            //valida rfc
            if (Ambiente.RFCvalido(cliente.Rfc))
            {

                //Anula el ticket y crea la venta factura (sin timbrar)
                if (ClonarVenta())
                {
                    var oCFDI = new CFDI();
                    oCFDI.Venta = venta;

                    //Timbra la venta
                    if (oCFDI.Facturar())
                    {
                        Ambiente.SaveAndPrintFactura(venta, true, false);
                        Close();
                    }
                    else
                        Ambiente.Mensaje("Algo salió mal al facturar la venta");
                }
                else
                    Ambiente.Mensaje("No se clonó la venta");
            }
            else
                Ambiente.Mensaje("El rfc del cliente está mal formado");
        }

        private void TxtNoRereren_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                if (TxtNoRereren.Text.Trim().Length == 0)
                {
                    return;
                }
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChkMismoCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMismoCliente.Checked)
            {
                DeabilitarCampos();
            }
            if (!ChkMismoCliente.Checked)
            {
                HabilitarCampos();
            }

        }

        private void HabilitarCampos()
        {
            TxtCliente.Enabled = true;
            TxtUsoCFDI.Enabled = true;
            TxtFormaPago.Enabled = true;
            TxtMetodoPago.Enabled = true;
        }

        private void DeabilitarCampos()
        {
            TxtCliente.Text = "";
            TxtUsoCFDI.Text = "";
            TxtFormaPago.Text = "";
            TxtMetodoPago.Text = "";

            TxtCliente.Enabled = true;
            TxtUsoCFDI.Enabled = true;
            TxtFormaPago.Enabled = true;
            TxtMetodoPago.Enabled = true;

        }

        private void FrmTicketFactura_Load(object sender, EventArgs e)
        {

        }
    }
}

