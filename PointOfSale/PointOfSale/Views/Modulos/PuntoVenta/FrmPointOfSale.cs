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
        private Cliente oCliente;
        public Venta oVenta;
        private Ventap oVentap;
        private Producto oProducto;
        private Cxc oCxc;
        private VentaController oVentaController;
        private VentapController oVentapController;
        private ProductoController oProductoController;
        private ClienteController oClienteController;
        private int MaxPartidas;
        private int SigPartida;
        private int nImpuestos;
        bool succes;




        public FrmPointOfSale()
        {
            InitializeComponent();
        }
        private void Reload()
        {
            oCliente = null;
            oVenta = null;
            oVentap = null;
            oProducto = null;
            oCxc = null;
            oVentaController = new VentaController();
            oVentapController = new VentapController();
            oProductoController = new ProductoController();
            oClienteController = new ClienteController();
            //oCxcController = new CxcController();

            MaxPartidas = 100;
            SigPartida = 0;
            nImpuestos = 0;
            succes = true;

        }

        private void InicializaPOS()
        {
            Reload();
            InicializaMalla();

        }

        private void InsertaVenta()
        {
            if (oCliente == null)
            {
                oCliente = oClienteController.SelectOne("SYS");
            }
            oVenta = new Venta();
            oVenta.ClienteId = oCliente.ClienteId;
            oVenta.DatosCliente = oCliente.Negocio + " " + oCliente.Direccion + " " + oCliente.Colonia
                            + " " + oCliente.Municipio + " " + oCliente.Localidad + " " + oCliente.Estado + " TEL." + oCliente.Telefono;
            oVenta.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            oVenta.EstacionId = Ambiente.Estacion.EstacionId;

            oVenta.NoPrecio = oCliente.PrecioDefault;


            succes = oVentaController.InsertOne(oVenta);

        }

        private void InsertaPartida()
        {
            if (SigPartida >= MaxPartidas)
            {
                Ambiente.Mensaje("Limite de partidas alcanzado");
                return;
            }

            if (!succes)
            {
                Ambiente.Mensaje("Algo salio mal con la venta");
                return;
            }

            oVentap = new Ventap();
            oVentap.VentaId = oVenta.VentaId;
            oVentap.ProductoId = oProducto.ProductoId;
            oVentap.Descripcion = oProducto.Descripcion;
            oVentap.Cantidad = 1;
            oVentap.Descuento = 0;

            //seleccion de precio
            if (oVenta.NoPrecio == 1)
                oVentap.Precio = oProducto.Precio1;

            else if (oVenta.NoPrecio == 2)
                oVentap.Precio = oProducto.Precio2;

            else if (oVenta.NoPrecio == 3)
                oVentap.Precio = oProducto.Precio3;

            else
                oVentap.Precio = oProducto.Precio4;



            //impuestos
            if (Ambiente.GetTasaImpuesto(oProducto.Impuesto1Id) > 0)
            {
                oVentap.Impuesto1 = Ambiente.GetTasaImpuesto(oProducto.Impuesto1Id);
                nImpuestos++;
            }
            if (Ambiente.GetTasaImpuesto(oProducto.Impuesto2Id) > 0)
            {
                oVentap.Impuesto2 = Ambiente.GetTasaImpuesto(oProducto.Impuesto2Id);
                nImpuestos++;
            }


            oVentap.CantImpuestos = nImpuestos;
            oVentap.LoteId = oProductoController.TraeSiguienteLote(oProducto, (decimal)oVentap.Cantidad);


            //Importes de la partida
            oVentap.SubTotal = oVentap.Cantidad * oVentap.Precio;
            oVentap.ImporteImpuesto1 = oVentap.SubTotal * oVentap.Impuesto1;
            oVentap.ImporteImpuesto2 = oVentap.SubTotal * oVentap.Impuesto2;
            oVentap.Total = oVentap.SubTotal + oVentap.ImporteImpuesto1 + oVentap.ImporteImpuesto2;

            if (oVentapController.InsertOne(oVentap))
            {
                Malla.Rows[SigPartida].Cells[0].Value = oVentap.Descripcion;
                Malla.Rows[SigPartida].Cells[1].Value = oProducto.Stock;
                Malla.Rows[SigPartida].Cells[2].Value = oVentap.Cantidad;
                Malla.Rows[SigPartida].Cells[3].Value = Math.Round((decimal)oVentap.Precio, 2);
                Malla.Rows[SigPartida].Cells[4].Value = oVentap.SubTotal;
                Malla.Rows[SigPartida].Cells[5].Value = oVentap.Impuesto1;
                Malla.Rows[SigPartida].Cells[6].Value = oVentap.Impuesto2;
                Malla.Rows[SigPartida].Cells[7].Value = oVentap.Total;
                Malla.Rows[SigPartida].Cells[8].Value = oVentap.LoteId;
                Malla.Rows[SigPartida].Cells[9].Value = oVentap.VentapId;
                Malla.Rows[SigPartida].Cells[10].Value = oProducto.ProductoId;
                SigPartida++;
                CalculaTotales();
                ResetPartida();

            }
            else Ambiente.Mensaje("Algo salio mal con la venta");



        }

        private void ResetPartida()
        {

            TxtProductoId.Text = string.Empty;
            oProducto = null;
            oVentap = null;
        }

        private void CalculaTotales()
        {
            if (SigPartida == 0)
                return;


            oVenta.SubTotal = 0;
            oVenta.Impuesto = 0;
            oVenta.Total = 0;

            for (int i = 0; i < Malla.RowCount; i++)
            {

                if (Malla.Rows[i].Cells[10].Value == null)
                {
                    TxtSubtotal.Text = oVenta.SubTotal.ToString();
                    TxtTotal.Text = oVenta.Total.ToString();
                    return;
                }

                var productoId = Malla.Rows[i].Cells[10].Value.ToString().Trim();
                oProducto = oProductoController.SelectOne(productoId);

                if (oProducto != null)
                {
                    oVenta.NoPrecio = oCliente.PrecioDefault;
                    //seleccion de precio
                    if (oVenta.NoPrecio == 1)
                        Malla.Rows[i].Cells[3].Value = oProducto.Precio1;

                    else if (oVenta.NoPrecio == 2)
                        Malla.Rows[i].Cells[3].Value = oProducto.Precio2;

                    else if (oVenta.NoPrecio == 3)
                        Malla.Rows[i].Cells[3].Value = oProducto.Precio3;

                    else
                        Malla.Rows[i].Cells[3].Value = oProducto.Precio4;

                }

                decimal Cant = Convert.ToDecimal(Malla.Rows[i].Cells[2].Value);
                decimal Prec = Convert.ToDecimal(Malla.Rows[i].Cells[3].Value);
                decimal Imp1 = Convert.ToDecimal(Malla.Rows[i].Cells[5].Value);
                decimal Imp2 = Convert.ToDecimal(Malla.Rows[i].Cells[6].Value);


                decimal Subt = Cant * Prec;
                oVenta.SubTotal += Subt;

                Malla.Rows[i].Cells[4].Value = Math.Round(Subt, 2);

                decimal ImpImp1 = Subt * Imp1;
                decimal ImpImp2 = Subt * Imp2;

                oVenta.Impuesto += ImpImp1;
                oVenta.Impuesto += ImpImp2;

                decimal Tot = Subt + ImpImp1 + ImpImp2;
                Malla.Rows[i].Cells[7].Value = Math.Round(Tot, 2);
                oVenta.Total += Tot;

            }

        }

        private void InicializaMalla()
        {
            Malla.Rows.Clear();
            Malla.Refresh();

            for (int i = 0; i < MaxPartidas; i++)
            {
                Malla.Rows.Add();
                Malla.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
            }
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




        private void LanzaBusquedaClientes()
        {
            using (var form = new FrmBusqueda(TxtCliente.Text.Trim(), (int)Ambiente.TipoBusqueda.Clientes))
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    oCliente = form.Cliente;
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
                    oProducto = form.Producto;
                    TxtProductoId.Text = oProducto.ProductoId;
                    TxtProductoId.Focus();
                }
            }
        }

        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Significa que fue recibido por scanner
                if (oProducto == null)
                    oProducto = oProductoController.SelectOne(TxtProductoId.Text.Trim());

                if (oProducto == null)
                {
                    Ambiente.Mensaje("Producto no encontrado");
                    return;
                }

                //Significa que es la primera partida
                if (oVenta == null)
                {
                    InsertaVenta();
                    InsertaPartida();
                }
                else
                    InsertaPartida();
            }
            else if (e.KeyCode == Keys.F5)
            {
                using (var form = new FrmCobroRapido((decimal)oVenta.Total))
                {
                    
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        oVenta.TipoDocId = form.tipoDoc;
                        oVenta.TotalConLetra = form.totalLetra;
                        oVenta.EsCxc = form.Cxc;

                        oVenta.FormaPago1 = form.formapago1;
                        oVenta.FormaPago2 = form.formapago2;
                        oVenta.FormaPago3 = form.formapago3;

                        oVenta.ConceptoPago1 = form.concepto1;
                        oVenta.ConceptoPago2 = form.concepto2;
                        oVenta.ConceptoPago3 = form.concepto3;

                        oVenta.Pago1 = form.pago1;
                        oVenta.Pago2 = form.pago2;
                        oVenta.Pago3 = form.pago3;
                        oVenta.EstadoDocId = "CON";

                        if ((bool)oVenta.EsCxc)
                        {
                            InsertaCXC();

                        }


                        if (!oVentaController.UpdateOne(oVenta))
                            Ambiente.Mensaje("Algo salío mal al confirmar la venta");
                        MessageBox.Show("Venta cerrada");
                    }
                }
            }
        }

        private void InsertaCXC()
        {
            MessageBox.Show("CXC insertada");
        }

        private void TxtCliente_Leave(object sender, EventArgs e)
        {
            CalculaTotales();
            ActualizaDatosCliente();
            TxtProductoId.Focus();
        }

        private void ActualizaDatosCliente()
        {
            if (oVenta == null)
                return;

            oVenta.ClienteId = oCliente.ClienteId;
            oVenta.DatosCliente = oCliente.Negocio + " " + oCliente.Direccion + " " + oCliente.Colonia
                            + " " + oCliente.Municipio + " " + oCliente.Localidad + " " + oCliente.Estado + " TEL." + oCliente.Telefono;
            if (!oVentaController.UpdateOne(oVenta))
                Ambiente.Mensaje("Error al actualizar los datos del cliente");
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            FinalizaVenta();
        }

        private void FinalizaVenta()
        {


            Close();
        }

        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculaTotales();
            TxtProductoId.Text = "";
            TxtProductoId.Focus();
        }

        private void TxtProductoId_TextChanged(object sender, EventArgs e)
        {
            if (TxtProductoId.Text.Trim().Equals("*"))
            {
                Malla.Focus();
                Malla.CurrentCell = Malla.Rows[SigPartida - 1].Cells[2];
            }
        }

        private void BtnRecalculaTotales_Click(object sender, EventArgs e)
        {
            var o = new FrmCobroRapido(455.90m);
            o.Show();

        }
    }
}
