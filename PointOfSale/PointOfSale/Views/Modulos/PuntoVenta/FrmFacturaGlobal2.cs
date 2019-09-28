using PointOfSale.CFDI33;
using PointOfSale.Controllers;
using PointOfSale.Controllers.Utils;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class FrmFacturaGlobal2 : Form
    {
        //Controladores
        VentaController ventaController;
        VentapController ventapController;

        //Listas
        List<Venta> ventas;
        List<Ventap> partidas;
        IQueryable<Venta> query;

        //Objetos
        Venta venta;
        Ventap partida;
        Moneda moneda;
        CFDI oCFDI;



        //Variables
        private decimal subtotal;
        private decimal impuestos;
        private decimal total;


        public FrmFacturaGlobal2()
        {
            InitializeComponent();
            Inicializa();
        }
        #region Metodos
        private void Inicializa()
        {
            //Controladores
            ventaController = new VentaController();
            ventapController = new VentapController();

            //Listas
            ventas = new List<Venta>();
            partidas = new List<Ventap>();

            //Objetos
            venta = null;
            partida = null;
            moneda = new Moneda();
            oCFDI = new CFDI();

            //Variables
            subtotal = 0;
            impuestos = 0;
            total = 0;
        }

        private void LlenaListaVentas()
        {
            using (var db = new DymContext())
            {
                if (ChkFacturarTodo.Checked)
                {
                    query = from v in db.Venta
                            where v.TipoDocId.Equals("TIC")
                            && v.EstadoDocId.Equals("CON")
                            && v.Anulada == false
                            && v.EnFactCierre == false
                            select v;
                    ventas = query.ToList();
                }
                else
                {
                    query = from v in db.Venta
                            where v.TipoDocId.Equals("TIC")
                            && v.EstadoDocId.Equals("CON")
                            && v.Anulada == false
                            && v.EnFactCierre == false
                            && v.CreatedAt.Date >= DpInicial.Value.Date && v.CreatedAt.Date <= DpFinal.Value.Date
                            select v;
                    ventas = query.ToList();
                }

            }

        }



        private void LlenaMalla()
        {
            Malla.Rows.Clear();
            subtotal = 0;
            impuestos = 0;
            total = 0;

            foreach (var v in ventas)
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = v.VentaId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = v.NoRef;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = v.DatosCliente;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = v.CreatedAt;
                Malla.Rows[Malla.RowCount - 1].Cells[4].Value = v.SubTotal;
                Malla.Rows[Malla.RowCount - 1].Cells[5].Value = v.Impuesto;
                Malla.Rows[Malla.RowCount - 1].Cells[6].Value = v.Total;

                subtotal += v.SubTotal;
                impuestos += v.Impuesto;
                total += v.Total;

            }
            TxtSubtotal.Text = Ambiente.FDinero(subtotal.ToString());
            TxtImpuestos.Text = Ambiente.FDinero(impuestos.ToString());
            TxtTotal.Text = Ambiente.FDinero(total.ToString());
        }

        private bool InsertaVenta()
        {
            using (var form = new FrmFormaPago())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    venta = new Venta();
                    venta.NoRef = Ambiente.TraeSiguiente("FAC");
                    venta.TipoDocId = "FAC";
                    venta.FechaDoc = DateTime.Now;
                    venta.ClienteId = "SYS";
                    venta.Descuento = 0;
                    venta.NoPrecio = 1;
                    venta.MonedaId = "MXN";
                    venta.DatosCliente = "PUBLICO EN GENERAL";
                    venta.EnFactCierre = false;
                    venta.Anulada = false;
                    venta.EsConversiondeTaF = false;
                    venta.VentaOrigen = null;
                    venta.CxcId = null;
                    venta.Pago1 = total;
                    venta.FormaPago1 = form.formapago == null ? "01" : form.formapago.FormaPagoId;
                    venta.EstacionId = Ambiente.Estacion.EstacionId;
                    venta.Cortada = false;
                    venta.CreatedAt = DateTime.Now;
                    venta.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                    venta.EstadoDocId = "PEN";
                    venta.SubTotal = 0;
                    venta.Impuesto = 0;
                    venta.Total = 0;
                    venta.TotalConLetra = moneda.Convertir(venta.Total.ToString(), true);
                    venta.DescXpuntos = 0;
                    venta.PuntosAplicados = false;
                    venta.Cambio = 0;
                    //venta.Unidades = ventas.Count;
                    venta.UsoCfdi = "P01";
                    venta.MetodoPago = "PUE";
                    venta.EsCxc = false;
                    return ventaController.InsertOne(venta);
                }
                return false;
            }
        }

        private bool InsertaPartidas()
        {
            try
            {
                foreach (var v in ventas)
                {


                    partidas = ventapController.SelectPartidas(v.VentaId);

                    foreach (var p in partidas)
                    {
                        p.VentapId = 0;
                        p.VentaId = venta.VentaId;
                        p.ClaveProdServ = "01010101";
                        p.ClaveUnidad = "ACT";
                        p.ProductoId = "01010101";
                        p.Descripcion = "VENTA " + v.NoRef;
                        ventapController.InsertOne(p);
                    }
                }



                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Timbrar()
        {
            oCFDI.Venta = venta;
            if (oCFDI.Facturar())
            {
                Ambiente.SaveAndPrintFactura(venta, true);
                Ambiente.UpdateSiguiente("FAC");
                Close();
            }
            else
                Ambiente.Mensaje("Algo salió mal al facturar la venta");
        }

        private void ActualizarVentas()
        {
            //Ambiente.CalculaTotales(venta.VentaId);
            venta.EstadoDocId = "CON";


        }

        #endregion

        #region Eventos

        #endregion

        private void BtnTraerVentas_Click(object sender, EventArgs e)
        {
            LlenaListaVentas();
            LlenaMalla();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (InsertaVenta())
                if (InsertaPartidas())
                    if (Ambiente.Pregunta("Quiere timbrar la factuctura"))
                    {
                        CalculaTotales();
                        Timbrar();
                    }
        }
        private void CalculaTotales()
        {
            //controladores

            partidas = ventapController.SelectPartidas(venta.VentaId);

            if (venta == null || partidas == null)
                return;

            else
            {
                venta.Unidades = 0;
                venta.SubTotal = 0;
                venta.Impuesto = 0;
                venta.Total = 0;

                foreach (var partida in partidas)
                {
                    partida.SubTotal = partida.Cantidad * partida.Precio;
                    partida.ImporteImpuesto1 = partida.SubTotal * partida.Impuesto1;
                    partida.ImporteImpuesto2 = partida.SubTotal * partida.Impuesto2;
                    partida.Total = partida.SubTotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;

                    //sumar el total por partida a los totales de la venta
                    venta.Unidades += partida.Cantidad;
                    venta.SubTotal += partida.SubTotal;
                    venta.Impuesto += partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                    venta.Total += partida.SubTotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                }

                venta.EstadoDocId = "CON";
                venta.TotalConLetra = moneda.Convertir(venta.Total.ToString(), true);
                venta.Pago1 = venta.Total;

                using (var db = new DymContext())
                {
                    db.Update(venta);
                    db.SaveChanges();
                    db.UpdateRange(partidas);
                    db.SaveChanges();
                }

            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
