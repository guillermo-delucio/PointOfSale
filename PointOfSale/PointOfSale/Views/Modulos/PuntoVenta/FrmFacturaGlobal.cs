using PointOfSale.CFDI33;
using PointOfSale.Controllers;
using PointOfSale.Controllers.Utils;
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
    public partial class FrmFacturaGlobal : Form
    {
        //Controladores
        private VentaController ventaController;
        private VentapController ventapController;

        //Objetos
        private Venta venta;
        private string formaPago;
        private Moneda moneda;
        private CFDI oCFDI;
        //Listas
        private List<Ventap> partidas;
        private List<Venta> ventas;

        //Variables
        decimal subtotal = 0, iva = 0, ieps = 0, total = 0;

        public FrmFacturaGlobal()
        {
            InitializeComponent();
            Inicializa();
        }

        #region Metodos
        private void Inicializa()
        {
            ventapController = new VentapController();
            ventaController = new VentaController();
            venta = new Venta();
            ventas = new List<Venta>();
            partidas = new List<Ventap>();
            formaPago = null;
            moneda = new Moneda();
            oCFDI = new CFDI();

        }



        private void TraerVentas()
        {
            using (var db = new DymContext())
            {
                if (ChkFacturarTodo.Checked)
                {
                    var q = from v in db.Venta
                            where v.TipoDocId.Equals("TIC")
                            && v.EstadoDocId.Equals("CON")
                            && v.Anulada == false
                            && v.EnFactCierre == false
                            // && v.CreatedAt.Date >= DpInicial.Value.Date && v.CreatedAt.Date <= DpFinal.Value.Date
                            select v;
                    ventas = q.ToList();
                }
                else
                {
                    var q = from v in db.Venta
                            where v.TipoDocId.Equals("TIC")
                            && v.EstadoDocId.Equals("CON")
                            && v.Anulada == false
                            && v.EnFactCierre == false
                            && v.CreatedAt.Date >= DpInicial.Value.Date && v.CreatedAt.Date <= DpFinal.Value.Date
                            select v;
                    ventas = q.ToList();
                }


            }
        }

        private void CalculaImpuestos()
        {
            using (var db = new DymContext())
            {
                foreach (var v in ventas)
                {
                    decimal iv = db.Ventap
                        .Where(x => x.VentaId == v.VentaId)
                        .Sum(x => x.ImporteImpuesto1);

                    decimal ie = db.Ventap
                    .Where(x => x.VentaId == v.VentaId)
                    .Sum(x => x.ImporteImpuesto2);

                    v.Iva = iv;
                    v.Ieps = ie;

                    subtotal += v.SubTotal;
                    iva += iv;
                    ieps += ie;
                    total += v.Total;

                    iv += iv;
                    db.Update(v);
                    db.SaveChanges();
                }
                TxtSubtotal.Text = Ambiente.FDinero(subtotal.ToString());
                TxtIva.Text = Ambiente.FDinero(iva.ToString());
                TxtIeps.Text = Ambiente.FDinero(ieps.ToString());
                TxtTotal.Text = Ambiente.FDinero(total.ToString());

            }

        }
        private void LlenaGrid()
        {
            Malla.Rows.Clear();

            foreach (var v in ventas)
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = v.VentaId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = v.NoRef;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = v.DatosCliente;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = v.CreatedAt;
                Malla.Rows[Malla.RowCount - 1].Cells[4].Value = v.SubTotal;
                Malla.Rows[Malla.RowCount - 1].Cells[5].Value = v.Iva;
                Malla.Rows[Malla.RowCount - 1].Cells[6].Value = v.Ieps;
                Malla.Rows[Malla.RowCount - 1].Cells[7].Value = v.Total;
            }
        }
        private void InsertaVenta()
        {
            venta = new Venta();
            venta.NoRef = Ambiente.TraeSiguiente("FAC");
            venta.TipoDocId = "FAC";
            venta.FechaDoc = DateTime.Now;
            venta.ClienteId = "SYS";
            venta.Descuento = 0;
            venta.NoPrecio = 1;
            venta.EstadoDocId = "CON";
            venta.MonedaId = "MXN";
            venta.DatosCliente = "PUBLICO EN GENERAL";
            venta.EnFactCierre = false;
            venta.Anulada = false;
            venta.EsConversiondeTaF = false;
            venta.VentaOrigen = null;
            venta.CxcId = null;
            venta.Pago1 = total;
            venta.FormaPago1 = formaPago;
            venta.EstacionId = Ambiente.Estacion.EstacionId;
            venta.Cortada = false;
            venta.CreatedAt = DateTime.Now;
            venta.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            venta.SubTotal = subtotal;
            venta.Iva = iva;
            venta.Ieps = ieps;
            venta.Total = total;
            venta.DescXpuntos = 0;
            venta.PuntosAplicados = false;
            venta.Cambio = 0;
            venta.TotalConLetra = moneda.Convertir(venta.Total.ToString(), true);
            venta.Unidades = ventas.Count;
            venta.UsoCfdi = "P01";
            venta.MetodoPago = "PUE";
            venta.EsCxc = false;
            ventaController.InsertOne(venta);
        }

        private void InsertaPartidas()
        {
            foreach (var v in ventas)
            {
                var partida = new Ventap();
                partida.VentaId = venta.VentaId;
                partida.ProductoId = v.NoRef.ToString();
                partida.Descripcion = "VENTA";
                partida.Cantidad = 1;
                partida.Precio = v.SubTotal;
                partida.Descuento = 0;
                partida.ClaveImpuesto1 = "002";
                partida.ClaveImpuesto2 = "003";
                partida.TasaOcuota1 = "Tasa";
                partida.TasaOcuota2 = "Tasa";
                partida.Impuesto1 = 0.160000m;
                partida.Impuesto2 = 0.080000m;
                partida.SubTotal = v.SubTotal;
                partida.ImporteImpuesto1 = v.Iva;
                partida.ImporteImpuesto2 = v.Ieps;
                partida.Total = v.Total;
                partida.ClaveProdServ = "1010101";
                partida.ClaveUnidad = "ACT";
                ventapController.InsertOne(partida);
            }

        }
        private void TimbraFactura()
        {

            oCFDI.Venta = venta;

            //Timbra la venta
            if (oCFDI.Facturar())
            {
                Ambiente.SaveAndPrintFactura(venta, true);
                Ambiente.UpdateSiguiente("FAC");
                Close();
            }
            else
                Ambiente.Mensaje("Algo salió mal al facturar la venta");

        }
        #endregion

        #region Eventos
        private void BtnTraerVentas_Click(object sender, EventArgs e)
        {
            TraerVentas();
            CalculaImpuestos();
            LlenaGrid();
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            SeleccionaMetodoPago();
            InsertaVenta();
            InsertaPartidas();
            TimbraFactura();

            //ESTE ES UN COMEN
        }

        private void SeleccionaMetodoPago()
        {
            using (var form = new FrmFormaPago())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    formaPago = form.formapago == null ? "01" : form.formapago.FormaPagoId;
                }
                else formaPago = "01";
            }
        }
        #endregion


    }
}
