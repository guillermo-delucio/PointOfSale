using PointOfSale.Controllers;
using PointOfSale.Controllers.Utils;
using PointOfSale.Models;
using System;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class FrmFacturaGlobal3 : Form
    {
        VentaController ventaController;
        VentapController ventapController;
        Moneda moneda;
        Venta venta;



        public FrmFacturaGlobal3()
        {
            InitializeComponent();
            ventaController = new VentaController();
            ventapController = new VentapController();
            moneda = new Moneda();

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            GenerarFactura();
        }

        private void GenerarFactura()
        {

            if (Ambiente.Pregunta("¿Realmente quiere generar esté documento?"))
            {
                InsertarVenta();
                InsertarPartidas();
                Calcular();
                if (Ambiente.Pregunta("¿Verique las cantidades, quiere continuar con este proceso?"))
                    Confirmar();
            }
        }
        private void Calcular()
        {
            TxtSubtotal.Text = Ambiente.FDinero(venta.SubTotal.ToString());
            TxtImpuestos.Text = Ambiente.FDinero(venta.Impuesto.ToString());
            TxtTotal.Text = Ambiente.FDinero(venta.Total.ToString());
        }

        private void Confirmar()
        {
            venta.EstadoDocId = "CON";
            venta.Pago1 = venta.Total;
            venta.TotalConLetra = moneda.Convertir(venta.Total.ToString(), true);
            if (ventaController.UpdateOne(venta))
            {
                Ambiente.UpdateSiguiente("FAC");
                Ambiente.Mensaje("Proceso concluido con exito, sólo timbra la factura");
                BtnAceptar.Enabled = false;
            }
        }

        private void InsertarPartidas()
        {
            if (venta.VentaId <= 0)
            {
                Ambiente.Mensaje("La venta no existe");
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                //partida a la lista
                var partida = new Ventap();
                partida.VentaId = venta.VentaId;
                partida.ProductoId = "01010101";
                partida.Descripcion = "VENTA ";
                partida.Descuento = 0;
                partida.Cantidad = 1;

                if (i == 0)
                {
                    partida.Precio = TxtImporteIva16.Value;
                    partida.ClaveImpuesto1 = "002";
                    partida.Impuesto1 = 0.160000m;
                    partida.ClaveImpuesto2 = "002";
                    partida.Impuesto2 = 0.000000m;

                }
                else if (i == 1)
                {
                    partida.Precio = TxtImporteExcento.Value;
                    partida.ClaveImpuesto1 = "002";
                    partida.Impuesto1 = 0.000000m;
                    partida.ClaveImpuesto2 = "002";
                    partida.Impuesto2 = 0.000000m;
                }

                partida.LoteId = null;
                partida.NoLote = null;
                partida.Caducidad = null;

                partida.PrecioCaja = 0;
                partida.ClaveProdServ = "01010101";
                partida.ClaveUnidad = "ACT";
                partida.Unidad = "SYS";

                partida.TasaOcuota1 = "Tasa";
                partida.TasaOcuota2 = "Tasa";
                partida.SubTotal = partida.Cantidad * partida.Precio;
                partida.ImporteImpuesto1 = partida.SubTotal * partida.Impuesto1;
                partida.ImporteImpuesto2 = partida.SubTotal * partida.Impuesto2;
                partida.Total = partida.SubTotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;

                if (ventapController.InsertOne(partida))
                {
                    venta.SubTotal += partida.SubTotal;
                    venta.Impuesto += partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                    venta.Total = venta.SubTotal + venta.Impuesto;
                }
            }
        }
        private void InsertarVenta()
        {
            try
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
                venta.Pago1 = 0;
                venta.EstacionId = Ambiente.Estacion.EstacionId;
                venta.Cortada = false;
                venta.CreatedAt = DateTime.Now;
                venta.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                venta.EstadoDocId = "PEN";
                venta.SubTotal = 0;
                venta.Impuesto = 0;
                venta.Total = 0;
                venta.TotalConLetra = "";
                venta.DescXpuntos = 0;
                venta.PuntosAplicados = false;
                venta.Cambio = 0;
                //venta.Unidades = ventas.Count;
                venta.UsoCfdi = "P01";
                venta.FormaPago1 = "99";
                venta.MetodoPago = "PUE";
                venta.EsCxc = false;
                ventaController.InsertOne(venta);
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.Message);
            }
        }


        private void TxtImporteIva16_ValueChanged(object sender, EventArgs e)
        {
            TxtImporteImpuestoIva16.Text = Ambiente.FDinero((TxtImporteIva16.Value * 0.16m).ToString());
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
