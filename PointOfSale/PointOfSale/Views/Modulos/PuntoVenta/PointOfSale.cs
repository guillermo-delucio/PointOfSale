using PointOfSale.Controllers;
using PointOfSale.Controllers.Utils;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class PointOfSale : Form
    {
        //Declaraciones
        public Venta venta;
        List<Ventap> partidas;
        public Cliente cliente;
        public Producto producto;
        public Lote lote;


        private VentaController ventaController;
        private VentapController ventapController;
        private ProductoController productoController;
        private ImpuestoController ImpuestoController;
        private ClienteController clienteController;
        private InventarioController inventarioController;
        private EmpresaController empresaController;
        private LoteController loteController;
        private MovInvController movInvController;
        private FlujoController flujoController;
        private ReporteController reporteController;
        private Reporte reporteTickets;


        private const int NPARTIDAS = 400;
        private int SigPartida;
        private string datosCliente;



        public PointOfSale()
        {
            InitializeComponent();
            ResetPDV();
            reporteTickets = reporteController.SelectOneByName(Ambiente.Empresa.FormatoParaTickets);
        }

        private void CalculaTotales()
        {
            venta.Unidades = 0;
            venta.SubTotal = 0;
            venta.Impuesto = 0;
            venta.Total = 0;
            int index = 0;

            if (partidas.Count == 0)
            {
                //Reflear totales en el PDV
                TxtSubtotal.Text = Ambiente.FDinero(0.ToString());
                TxtTotal.Text = Ambiente.FDinero(0.ToString());
                return;
            }
            foreach (var partida in partidas)
            {
                //partida.Cantidad = 1; actualizado desde el grid o incrementos rapidos
                //Calcular el total por partida
                producto = productoController.SelectOne(partida.ProductoId);

                partida.Precio = SeleccionaPrecio(producto, cliente);
                partida.Impuesto1 = Ambiente.GetTasaImpuesto(producto.Impuesto1Id);
                partida.Impuesto2 = Ambiente.GetTasaImpuesto(producto.Impuesto2Id);
                //if (producto.TieneLote)
                //{
                //    //partida.LoteId = loteController.TraeDatosLote(producto, partida.Cantidad).Item1;
                //    //partida.Caducidad = loteController.TraeDatosLote(producto, partida.Cantidad).Item2;
                //}
                partida.SubTotal = partida.Cantidad * partida.Precio;
                partida.ImporteImpuesto1 = partida.SubTotal * partida.Impuesto1;
                partida.ImporteImpuesto2 = partida.SubTotal * partida.Impuesto2;
                partida.Total = partida.SubTotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;

                //sumar unidades

                venta.Unidades += partida.Cantidad;
                if (Ambiente.Estacion.SumarUnidadesPdv)
                {
                    LblUnidades.Visible = true;
                    LblUnidades.Text = venta.Unidades + " Unidades";
                }
                else
                    LblUnidades.Visible = false;

                //sumar el total por partida a los totales de la venta
                venta.SubTotal += partida.SubTotal;
                venta.Impuesto += partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                venta.Total = venta.SubTotal + venta.Impuesto;

                //Refleajar el cambio  de precio y columnas calculadas en la malla                
                Malla.Rows[index].Cells[0].Value = partida.Descripcion;
                Malla.Rows[index].Cells[1].Value = producto.Stock;
                Malla.Rows[index].Cells[2].Value = partida.Cantidad;
                Malla.Rows[index].Cells[3].Value = Math.Round(partida.Precio, 2);
                Malla.Rows[index].Cells[4].Value = partida.SubTotal;
                Malla.Rows[index].Cells[5].Value = partida.Impuesto1;
                Malla.Rows[index].Cells[6].Value = partida.Impuesto2;
                Malla.Rows[index].Cells[7].Value = partida.Total;
                Malla.Rows[index].Cells[8].Value = partida.LoteId;
                Malla.Rows[index].Cells[9].Value = partida.ProductoId;


                //Reflear totales en el PDV
                TxtSubtotal.Text = Ambiente.FDinero(venta.SubTotal.ToString());
                TxtTotal.Text = Ambiente.FDinero(venta.Total.ToString());

                index++;
            }

        }
        private void LimpiarFilaMalla(int index)
        {
            Malla.Rows[index].Cells[0].Value = null;
            Malla.Rows[index].Cells[1].Value = null;
            Malla.Rows[index].Cells[2].Value = null;
            Malla.Rows[index].Cells[3].Value = null;
            Malla.Rows[index].Cells[4].Value = null;
            Malla.Rows[index].Cells[5].Value = null;
            Malla.Rows[index].Cells[6].Value = null;
            Malla.Rows[index].Cells[7].Value = null;
            Malla.Rows[index].Cells[8].Value = null;
            Malla.Rows[index].Cells[9].Value = null;
        }
        private void Incrementa(int rowIndex)
        {
            if (partidas.Count > 0)
            {
                if (Ambiente.Estacion.VenderSinStock)
                {
                    partidas[rowIndex].Cantidad++;
                    CalculaTotales();
                }
                else
                {
                    if (HayStockSuficiente(partidas[rowIndex].ProductoId, partidas[rowIndex].Cantidad + 1))
                    {
                        partidas[rowIndex].Cantidad++;
                        CalculaTotales();
                    }

                    else
                    {
                        Ambiente.Mensaje("Stock insuficiente");
                        return;
                    }
                }

            }
        }
        private void Decrementa(int rowIndex)
        {
            if (partidas.Count > 0)
            {
                if (partidas[rowIndex].Cantidad >= 2)
                {
                    partidas[rowIndex].Cantidad--;
                    CalculaTotales();
                }
                else
                    Ambiente.Mensaje("Operación denegada");
            }
        }
        private void ActualizaCantidad(decimal cant, int rowIndex)
        {
            if (partidas.Count > 0)
            {

                if (Ambiente.Estacion.VenderSinStock)
                {
                    partidas[rowIndex].Cantidad = cant;
                    CalculaTotales();
                }
                else
                {
                    if (HayStockSuficiente(partidas[rowIndex].ProductoId, cant))
                    {
                        partidas[rowIndex].Cantidad = cant;
                        CalculaTotales();
                    }

                    else
                    {
                        Ambiente.Mensaje("Stock insuficiente");
                        return;
                    }
                }

            }
        }
        private void ResetPartida()
        {
            producto = null;
            TxtProductoId.Text = "";
            SigPartida++;
        }
        private void ResetPDV()
        {
            venta = new Venta();
            partidas = new List<Ventap>();
            cliente = null;
            producto = null;
            SigPartida = 0;
            datosCliente = "PUBLICO EN GENERAL";
            TxtSubtotal.Text = "";
            TxtTotal.Text = "";
            TxtCliente.Text = "";

            ventaController = new VentaController();
            ventapController = new VentapController();
            productoController = new ProductoController();
            clienteController = new ClienteController();
            inventarioController = new InventarioController();
            ImpuestoController = new ImpuestoController();
            empresaController = new EmpresaController();
            loteController = new LoteController();
            movInvController = new MovInvController();
            flujoController = new FlujoController();
            reporteController = new ReporteController();
            lote = null;



            //Reset malla
            Malla.Rows.Clear();
            for (int i = 0; i < NPARTIDAS; i++)
            {
                Malla.Rows.Add();
                Malla.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                Malla.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
            }

            CreaVenta();

        }
        private void CreaVenta()
        {

            if (cliente == null)
            {
                venta.ClienteId = "SYS";
                venta.DatosCliente = "PUBLICO EN GENERAL";
                venta.NoPrecio = 1;
            }
            else
            {
                venta.ClienteId = cliente.ClienteId;
                venta.DatosCliente = datosCliente;
                venta.NoPrecio = cliente.PrecioDefault;
            }

            venta.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            venta.EstacionId = Ambiente.Estacion.EstacionId;
            venta.CreatedAt = DateTime.Now;
            venta.SubTotal = 0;
            venta.Impuesto = 0;
            venta.Total = 0;
            venta.Pago1 = 0;
            venta.Pago2 = 0;
            venta.Pago3 = 0;
            venta.NoRef = 0;
            venta.Anulada = false;
            ventaController.InsertOne(venta);

        }
        private void CierraVenta(FrmCobroRapido form)
        {
            venta.TipoDocId = form.tipoDoc;

            if (venta.TipoDocId.Equals("TIC"))
                venta.NoRef = Ambiente.TraeSiguiente("TIC");

            else if (venta.TipoDocId.Equals("FAC"))
                venta.NoRef = Ambiente.TraeSiguiente("FAC");

            if (venta.TipoDocId.Equals("FAC") && venta.ClienteId.Equals("SYS"))
            {
                Ambiente.Mensaje("Operación denegada, selecciona un cliente valido para facturar");
                return;
            }
            if (venta.TipoDocId.Equals("TIC") && !Ambiente.Estacion.SolicitarFmpago)
            {
                if (cliente == null)
                {
                    venta.MetodoPago = "PUE";
                    venta.UsoCfdi = "G01";
                }
                else
                {
                    venta.MetodoPago = cliente.MetodoPagoId.Trim().Length == 0 ? "PUE" : cliente.MetodoPagoId.Trim();
                    venta.UsoCfdi = cliente.UsoCfdiid.Trim().Length == 0 ? "G01" : cliente.UsoCfdiid.Trim();
                }

            }

            //Aplicaion de puntos

            GuardaPuntos();
            AplicaPuntos(form);
            if (Ambiente.CancelaProceso)
                return;



            // venta.TotalConLetra = form.totalLetra;
            venta.TotalConLetra = new Moneda().Convertir(venta.Total.ToString(), true);
            venta.EsCxc = form.Cxc;

            venta.FormaPago1 = form.formapago1;
            venta.FormaPago2 = form.formapago2;
            venta.FormaPago3 = form.formapago3;

            venta.ConceptoPago1 = form.concepto1;
            venta.ConceptoPago2 = form.concepto2;
            venta.ConceptoPago3 = form.concepto3;

            venta.Pago1 = form.pago1;
            venta.Pago2 = form.pago2;
            venta.Pago3 = form.pago3;
            venta.Cambio = form.cambio;
            venta.EstadoDocId = "CON";



            if (ventaController.UpdateOne(venta))
            {
                RestaLotes();
                GuardaPartidas();
                Ambiente.UpdateSiguiente("TIC");
                LblUltDocumento.Text = "TICKET " + venta.NoRef + " " + DateTime.Now.ToShortTimeString();
                LblCambio.Text = "SU CAMBIO: " + Ambiente.FDinero(venta.Cambio.ToString());

                AfectaFlujo();
                AfectaMovsInv();
                AfectaStock();

                if (!venta.PuntosAplicados)
                {
                    if (Ambiente.LoggedUser.Facturar)
                    {
                        if (Ambiente.Pregunta("Requiere factura para este documento"))
                            new FrmTicketFactura(venta.NoRef).Show();
                    }
                }
                Ambiente.SaveAndPrintTicket2(venta, reporteTickets, reporteController);
                ResetPDV();
            }
            else
                Ambiente.Mensaje("Cierre de la venta salió mal :(");
        }

        private void AplicaPuntos(FrmCobroRapido form)
        {
            if (form.CobroConPuntos)
            {
                if (cliente != null && cliente.DineroElectronico > 0 && cliente.TieneMonedero)
                {
                    if (form.NoTarjeta.Length == 0)
                    {
                        Ambiente.Mensaje("Proceso abortado. Si el cobro es con puntos escanee la tarjeta.");
                        Ambiente.CancelaProceso = true;
                        return;
                    }
                    else
                        Ambiente.CancelaProceso = false;

                    var clientem = clienteController.SelectOneByMonedero(form.NoTarjeta);
                    if (clientem == null)
                    {
                        //Cliente no tiene monedero asignado
                        if (Ambiente.Pregunta("El cliente tiene monedero, pero no lo han asignado.  Quieres asignar el esta tarjera de puntos al cliente de la venta"))
                        {
                            cliente.NoTarjetaPuntos = form.NoTarjeta;
                            clienteController.Update(cliente);
                            if (cliente.DineroElectronico >= venta.Total)
                            {
                                if (Ambiente.Pregunta("Aplicar el 100 % de descuento a la venta"))
                                {
                                    venta.DescXpuntos = venta.Total;
                                    venta.Total = 0;
                                    venta.PuntosAplicados = true;
                                    cliente.DineroElectronico -= venta.Total;
                                    clienteController.Update(cliente);
                                }
                            }
                            else
                            {
                                if (Ambiente.Pregunta("Aplicar $" + Math.Round(cliente.DineroElectronico, 1) + " pesos  de descuento a la venta"))
                                {
                                    venta.DescXpuntos = cliente.DineroElectronico;
                                    venta.PuntosAplicados = true;
                                    cliente.DineroElectronico = 0;
                                    venta.Total -= venta.DescXpuntos;
                                    clienteController.Update(cliente);
                                }
                            }
                        }
                        else
                        {
                            Ambiente.Mensaje("No se aplicaron los puntos");
                        }
                    }
                    else
                    {
                        //validar que sea el mismo cliente de la venta
                        if (clientem.ClienteId.Equals(cliente.ClienteId))
                        {
                            //Aplicar los puntos
                            if (cliente.DineroElectronico >= venta.Total)
                            {
                                if (Ambiente.Pregunta("Aplicar el 100 % de descuento a la venta"))
                                {
                                    venta.DescXpuntos = venta.Total;
                                    venta.Total = 0;
                                    venta.PuntosAplicados = true;
                                    cliente.DineroElectronico -= venta.Total;
                                    clienteController.Update(cliente);
                                }
                            }
                            else
                            {
                                if (Ambiente.Pregunta("Aplicar $" + Math.Round(cliente.DineroElectronico, 1) + " pesos  de descuento a la venta"))
                                {
                                    venta.DescXpuntos = cliente.DineroElectronico;
                                    venta.PuntosAplicados = true;
                                    cliente.DineroElectronico = 0;
                                    venta.Total -= venta.DescXpuntos;
                                    clienteController.Update(cliente);
                                }
                            }

                        }
                        else
                        {

                            Ambiente.Mensaje("Esta operacion no está permitida, los puntos no se transfieren entre clientes");
                        }

                    }


                }
                else
                {
                    Ambiente.Mensaje("Puntos no aplicados. El cliente no tiene monedero, o no tiene puntos o el cliente es público en general.  ");
                    return;
                }
            }
        }

        private bool GuardaPuntos()
        {
            var puntoController = new PuntoController();
            var configpc = new PuntoConfigController();
            var configPuntos = configpc.SelectTopOne();
            if (configPuntos != null)
            {
                if (cliente != null)
                {
                    var punto = new Punto();

                    punto.Base = venta.Total;
                    punto.VentaId = venta.VentaId;
                    punto.ClienteId = venta.ClienteId;
                    punto.Tasa = configPuntos.TasaDescuento;
                    punto.Importe = venta.Total * configPuntos.TasaDescuento;
                    punto.CreatedAt = DateTime.Now;
                    punto.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                    punto.ClienteName = cliente.RazonSocial.Trim().Length == 0 ? cliente.Negocio : cliente.RazonSocial;
                    cliente.DineroElectronico += punto.Importe;
                    return puntoController.InsertOne(punto) && clienteController.Update(cliente) == true ? true : false;

                }
                else return false;
            }
            else return false;
        }
        private void AfectaStock()
        {
            foreach (var p in partidas)
            {
                var prod = productoController.SelectOne(p.ProductoId);
                prod.Stock -= p.Cantidad;
                productoController.Update(prod);
            }
        }
        private void AfectaMovsInv()
        {
            foreach (var p in partidas)
            {
                var movInv = new MovInv();
                movInv.ConceptoMovsInvId = "VEN";
                movInv.NoRef = (int)venta.NoRef;
                movInv.EntradaSalida = "S";
                movInv.IdEntrada = null;
                movInv.IdSalida = p.VentapId;
                movInv.ProductoId = p.ProductoId;
                movInv.Precio = p.Precio;
                movInv.Cantidad = p.Cantidad;
                movInv.CreatedAt = DateTime.Now;
                movInv.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                movInvController.InsertOne(movInv);
            }
        }
        private void AfectaFlujo()
        {
            Flujo flujo = new Flujo();

            flujo.ConceptoIngresoId = "CLIEN";
            flujo.EntradaSalida = "E";
            flujo.Importe = venta.Pago1;
            flujo.EstacionId = Ambiente.Estacion.EstacionId;
            flujo.VentaOrigen = venta.VentaId;
            flujo.Cortado = false;
            flujo.ConceptoImporteId = venta.ConceptoPago1;
            flujo.CreatedAt = DateTime.Now;
            flujo.CreatedBy = Ambiente.LoggedUser.UsuarioId;
            flujoController.InsertOne(flujo);
            if (venta.Cambio != null)
            {
                if (venta.Cambio > 0)
                {
                    flujo = new Flujo();
                    flujo.ConceptoEgresoId = "CAM";
                    flujo.EntradaSalida = "S";
                    flujo.Importe = (decimal)venta.Cambio;
                    flujo.EstacionId = Ambiente.Estacion.EstacionId;
                    flujo.VentaOrigen = venta.VentaId;
                    flujo.Cortado = false;
                    flujo.ConceptoImporteId = venta.ConceptoPago1;
                    flujo.CreatedAt = DateTime.Now;
                    flujo.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                    flujoController.InsertOne(flujo);
                }
            }

            if (venta.ConceptoPago2 != null)
            {
                flujo = new Flujo();

                flujo.ConceptoIngresoId = "CLIEN";
                flujo.EntradaSalida = "E";
                flujo.Importe = venta.Pago2;
                flujo.EstacionId = Ambiente.Estacion.EstacionId;
                flujo.VentaOrigen = venta.VentaId;
                flujo.Cortado = false;
                flujo.ConceptoImporteId = venta.ConceptoPago2;
                flujo.CreatedAt = DateTime.Now;
                flujo.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                flujoController.InsertOne(flujo);
            }

            if (venta.ConceptoPago3 != null)
            {
                flujo = new Flujo();

                flujo.ConceptoIngresoId = "CLIEN";
                flujo.EntradaSalida = "E";
                flujo.Importe = venta.Pago3;
                flujo.EstacionId = Ambiente.Estacion.EstacionId;
                flujo.VentaOrigen = venta.VentaId;
                flujo.Cortado = false;
                flujo.ConceptoImporteId = venta.ConceptoPago3;
                flujo.CreatedAt = DateTime.Now;
                flujo.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                flujoController.InsertOne(flujo);
            }




        }
        private void EliminaVenta()
        {
            if (venta != null)
                ventaController.DeleteOne(venta);
        }
        private void EliminaPartida(int rowIndex, string descrip)
        {
            if (Ambiente.Pregunta("Realmente quiere borrar: " + descrip))
            {
                if (partidas.Count > 0 && rowIndex >= 0)
                {
                    partidas.RemoveAt(rowIndex);
                    SigPartida -= 1;
                    LimpiarFilaMalla(SigPartida);
                    CalculaTotales();
                }
            }

        }
        private void PendienteOdescarta()
        {
            if (partidas.Count > 0)
            {
                if (Ambiente.Pregunta("Quiere dejar la venta como pendiente"))
                    GuardaPartidas();
                else
                    EliminaVenta();
            }
            else
                EliminaVenta();
            Close();
        }
        private void InsertaPartida()
        {

            if (producto == null && TxtProductoId.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Producto no encontrado");
                return;
            }

            producto = productoController.SelectOne(TxtProductoId.Text.Trim());
            if (producto == null)
                return;

            if (venta.VentaId <= 0)
            {
                Ambiente.Mensaje("La venta no existe");
                return;
            }

            //partida a la lista
            var partida = new Ventap();
            partida.VentaId = venta.VentaId;
            partida.ProductoId = producto.ProductoId;
            partida.Descripcion = producto.Descripcion;
            partida.Descuento = 0;

            if (Ambiente.Estacion.VenderSinStock)
            {
                partida.Cantidad = 1;
            }
            else
            {
                if (HayStockSuficiente(producto, 1))
                {
                    partida.Cantidad = 1;
                }
                else
                {
                    Ambiente.Mensaje("Stock insuficiente");
                    return;
                }
            }


            partida.Precio = SeleccionaPrecio(producto, cliente);
            partida.Impuesto1 = Ambiente.GetTasaImpuesto(producto.Impuesto1Id);
            partida.Impuesto2 = Ambiente.GetTasaImpuesto(producto.Impuesto2Id);

            if (producto.TieneLote)
            {
                lote = loteController.GetLoteDisponibilidad(producto.ProductoId, 1);
                if (lote != null)
                {
                    partida.LoteId = lote.LoteId;
                    partida.NoLote = lote.NoLote;
                    partida.Caducidad = lote.Caducidad;
                }
                else
                    Ambiente.Mensaje("Este artículo tiene control de lote, pero no hay lotes registrados. No se imprimirá el lote del artículo");
            }
            else
            {

                partida.LoteId = null;
                partida.NoLote = null;
                partida.Caducidad = null;
            }
            partida.PrecioCaja = producto.PrecioCaja;
            partida.ClaveProdServ = producto.ClaveProdServId.Trim().Length == 0 ? "01010101" : producto.ClaveProdServId.Trim();
            partida.ClaveUnidad = producto.ClaveUnidadId.Trim().Length == 0 ? "H87" : producto.ClaveUnidadId.Trim();
            partida.Unidad = producto.UnidadMedidaId.Trim().Length == 0 ? "SYS" : producto.UnidadMedidaId.Trim();
            partida.ClaveImpuesto1 = SeleccionaClaveImpuesto(producto, 1);
            partida.ClaveImpuesto2 = SeleccionaClaveImpuesto(producto, 2);
            partida.TasaOcuota1 = "Tasa";
            partida.TasaOcuota2 = "Tasa";
            partida.SubTotal = partida.Cantidad * partida.Precio;
            partida.ImporteImpuesto1 = partida.SubTotal * partida.Impuesto1;
            partida.ImporteImpuesto2 = partida.SubTotal * partida.Impuesto2;
            partida.Total = partida.SubTotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
            partidas.Add(partida);

            //Calcular totales de partidas y venta();
            CalculaTotales();

            // partida al grid
            Malla.Rows[SigPartida].Cells[0].Value = partida.Descripcion;
            Malla.Rows[SigPartida].Cells[1].Value = producto.Stock;
            Malla.Rows[SigPartida].Cells[2].Value = partida.Cantidad;
            Malla.Rows[SigPartida].Cells[3].Value = Math.Round(partida.Precio, 2);
            Malla.Rows[SigPartida].Cells[4].Value = partida.SubTotal;
            Malla.Rows[SigPartida].Cells[5].Value = partida.Impuesto1;
            Malla.Rows[SigPartida].Cells[6].Value = partida.Impuesto2;
            Malla.Rows[SigPartida].Cells[7].Value = partida.Total;
            Malla.Rows[SigPartida].Cells[8].Value = partida.NoLote;
            Malla.Rows[SigPartida].Cells[9].Value = partida.ProductoId;


            ResetPartida();
        }
        private void GuardaPartidas()
        {
            foreach (var p in partidas)
            {
                if (ventapController.InsertOne(p))
                {
                    var prod = productoController.SelectOne(p.ProductoId);
                    if (prod != null)
                    {
                        //if (loteController.RestaLote(prod, p.Cantidad))
                        //{
                        //    if (!inventarioController.AfectaInventario(p.ProductoId, -p.Cantidad))
                        //        Ambiente.Mensaje("Algo salió mal al afectar el inventario");
                        //}
                        //else
                        // Ambiente.Mensaje("Algo salió mal al restar el lote");
                    }
                    else
                        Ambiente.Mensaje("Algo salió mal con la partida: " + p.Descripcion);
                }
                else
                {
                    Ambiente.Mensaje("Algo salió mal con la partida: " + p.Descripcion);
                }
            }
        }
        private bool HayStockSuficiente(Producto producto, decimal cant)
        {
            if (producto == null)
            {
                Ambiente.Mensaje("Advertencia el producto no fue encontrado");
                return false;
            }
            else
            {
                return producto.Stock >= cant;
            }
        }
        private bool HayStockSuficiente(string productoId, decimal cant)
        {
            var p = productoController.SelectOne(productoId);
            if (p == null)
            {
                Ambiente.Mensaje("Advertencia el producto no fue encontrado");
                return false;
            }
            else
            {
                return p.Stock >= cant;
            }
        }

        private void LanzaBusquedaClientes()
        {
            using (var form = new FrmBusqueda(TxtCliente.Text.Trim(), (int)Ambiente.TipoBusqueda.Clientes, ChkSoloConLicencia.Checked))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cliente = form.Cliente;
                    TxtCliente.Text = form.Cliente.RazonSocial;
                    TxtPrecioCliente.Text = cliente.PrecioDefault.ToString();
                    datosCliente = cliente.Negocio + " " + cliente.Direccion + " " + cliente.Colonia
                            + " " + cliente.Municipio + " " + cliente.Localidad + " " + cliente.Estado + " TEL." + cliente.Telefono;
                    CalculaTotales();
                    venta.ClienteId = cliente.ClienteId;
                    venta.DatosCliente = datosCliente;
                    if (!ventaController.UpdateOne(venta))
                        Ambiente.Mensaje("No se puedo actualizar el cliente en el objeto venta");

                }
            }
        }
        private decimal SeleccionaPrecio(Producto producto, Cliente cliente)
        {

            if (cliente == null)
                return producto.Precio1;

            else
            {
                if (cliente.PrecioDefault == 1)
                    return producto.Precio1;

                else if (cliente.PrecioDefault == 2)
                    return producto.Precio2;

                else if (cliente.PrecioDefault == 3)
                    return producto.Precio3;

                else if (cliente.PrecioDefault == 4)
                    return producto.Precio4;
                else
                    return 1;
            }
        }
        private string SeleccionaClaveImpuesto(Producto producto, int NoImpuesto = 1)
        {

            if (producto == null)
            {
                Ambiente.Mensaje("Imposible obtener el impuesto de un producto null");
                return "002";
            }
            else
            {
                Impuesto impuesto = null;
                if (NoImpuesto == 1)
                {

                    impuesto = ImpuestoController.SelectOne(producto.Impuesto1Id);
                    if (impuesto != null)
                    {
                        return impuesto.CImpuesto;
                    }
                    else
                        return "002";
                }
                else
                {
                    impuesto = ImpuestoController.SelectOne(producto.Impuesto2Id);
                    if (impuesto != null)
                    {
                        return impuesto.CImpuesto;
                    }
                    else
                        return "002";

                }
            }
        }

        //EVENTOS
        private void Malla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnCant_KeyPress);
            if (Malla.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnCant_KeyPress);
                }
            }
        }

        private void ColumnCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnBuscarProd_Click(object sender, EventArgs e)
        {
            using (var form = new FrmBuscaProducto())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                    producto = form.Producto;
                    if (producto == null)
                        return;
                    TxtProductoId.Text = producto.ProductoId;
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

        private void RestaLotes()
        {

            //Resta todos los lotes por partida, tenga en cuenta que si una partida tiene cantidad superior a la 
            //suma de las existencias de los lotes, este ultimo quedará en cero y la diferencia no genera error
            //es decir, se puede vender sin lotes, así cómo sin existencias.
            foreach (var p in partidas)
            {
                var Lvp = new LoteVentap();
                if (productoController.SelectOne(p.ProductoId).TieneLote)
                {
                    var lotes = loteController.GetLotesDisponibilidad(p.ProductoId, p.Cantidad);

                    var restante = p.Cantidad;

                    foreach (var l in lotes)
                    {
                        if (restante == 0)
                            break;


                        if (restante <= l.StockRestante)
                        {
                            Lvp.ProductoId = p.ProductoId;
                            Lvp.VentaId = venta.VentaId;
                            Lvp.NoLote = l.NoLote;

                            Lvp.Cantidad += restante;
                            l.StockRestante -= restante;
                            restante = 0;

                        }
                        else
                        {
                            Lvp.ProductoId = p.ProductoId;
                            Lvp.VentaId = venta.VentaId;
                            Lvp.NoLote = l.NoLote;

                            Lvp.Cantidad += restante;
                            restante -= l.StockRestante;
                            l.StockRestante = 0;
                        }
                    }
                    loteController.UpdateRange(lotes);
                }
            }
        }

        private void TxtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LanzaBusquedaClientes();
            }
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            LanzaBusquedaClientes();
        }

        private void BtnCobroPago_Click(object sender, EventArgs e)
        {
            if (venta.Total > 0)
            {

                using (var form = new FrmCobroRapido(venta.Total))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //Cierra venta
                        CierraVenta(form);
                    }
                }
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            PendienteOdescarta();
        }

        private void BtnRecalculaTotales_Click(object sender, EventArgs e)
        {
            CalculaTotales();
        }

        private void Malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizaCantidad(decimal.Parse(Malla.CurrentCell.Value.ToString()), e.RowIndex);
            CalculaTotales();
            TxtProductoId.Focus();
        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus)
                Incrementa(Malla.CurrentCell.RowIndex);
            else if (e.KeyCode == Keys.OemMinus)
                Decrementa(Malla.CurrentCell.RowIndex);
            else if (e.KeyCode == Keys.Delete)
            {
                if (Malla.Rows[Malla.CurrentCell.RowIndex].Cells[9].Value != null)
                    EliminaPartida(Malla.CurrentCell.RowIndex, Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void TxtProductoId_TextChanged(object sender, EventArgs e)
        {
            if (TxtProductoId.Text.Trim().Equals("*"))
            {
                TxtProductoId.Text = "";
                Malla.Focus();
                Malla.CurrentCell = Malla.Rows[SigPartida - 1].Cells[2];
            }
        }
        private void BtnBorrarPartida_Click(object sender, EventArgs e)
        {
            EliminaPartida(Malla.CurrentCell.RowIndex, Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }

        private void TimerPDV_Tick(object sender, EventArgs e)
        {
            TxtFecha.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm:ss");
        }

        private void BtnDirectoImp_Click(object sender, EventArgs e)
        {
            Ambiente.OpenDirectory(Ambiente.Empresa.DirectorioTickets);

        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
