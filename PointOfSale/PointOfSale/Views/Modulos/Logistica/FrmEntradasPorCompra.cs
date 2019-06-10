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

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmEntradasPorCompra : Form
    {
        ProductoController productoController;
        CompraController compraController;
        CxpController cxpController;
        CxppController cxppController;
        CambioPrecioController cambioPrecioController;
        private List<Impuesto> Impuestos;

        Producto producto;
        Proveedor proveedor;
        Compra compra;
        Comprap comprap;
        Cxp cxp;
        Cxpp cxpp;
        CambiosPrecio cambioPrecio;

        bool success;
        string productoId;
        string descripcion;
        string laboratorio;
        decimal stock;
        decimal cantidad;
        decimal precioCompra;
        decimal precioCaja;
        decimal descuento;
        decimal impuesto1;
        decimal impuesto2;
        decimal importeParcial;
        decimal impuestoParcial;
        decimal importeTotal;
        decimal impuestoTotal;
        int nImpuestos;
        string lote;
        DateTime caducidad;



        public FrmEntradasPorCompra()
        {
            InitializeComponent();
            productoController = new ProductoController();
            compraController = new CompraController();
            cxpController = new CxpController();
            cxppController = new CxppController();
            cambioPrecioController = new CambioPrecioController();
            Impuestos = new List<Impuesto>();
            success = false;
            ResetParcial();
        }

        private void ResetParcial()
        {
            productoId = "";
            descripcion = "";
            laboratorio = "";
            stock = 0;
            cantidad = 0;
            precioCompra = 0;
            precioCaja = 0;
            descuento = 0;
            impuesto1 = 0;
            impuesto2 = 0;
            importeParcial = 0;
            impuestoParcial = 0;
            nImpuestos = 0;
            lote = "";
            caducidad = DateTime.Now;
        }
        private void TxtDescuento_Leave(object sender, EventArgs e)
        {
            TxtU1.Focus();
        }



        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (producto == null || proveedor == null)
                return;

            if (producto.TieneLote)
                PideLotes();



            InsertaGrid();
            InsertaData();
            InsertaCambioPrecio();
            ActualizaPrecios();
            LimpiaData();
            TxtProductoId.Focus();
        }

        private void PideLotes()
        {
            using (var form = new FrmLotesCaducidad(producto, NCantidad.Value))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var loteController = new LoteController();
                    foreach (var l in form.lotes)
                    {
                        l.EstadoDocId = "CON";
                        lote = l.LoteId;
                        caducidad = (DateTime)l.Caducidad;
                        loteController.Update(l);
                    }
                }
            }

        }

        private void ActualizaPrecios()
        {

            if (producto == null)
                return;

            success = true;

            if (TxtPrecioCompra.Text.Trim().Length == 0)
                TxtPrecioCompra.Text = "1.000";

            if (TxtPrecioCaja.Text.Trim().Length == 0)
                TxtPrecioCaja.Text = "1.000";

            success = decimal.TryParse(TxtPrecioCompra.Text, out decimal nCosto);
            success = decimal.TryParse(TxtPrecioCaja.Text, out decimal nPrecioCaja);

            if (!success)
            {
                Ambiente.Mensaje("Precio de compra caja no válido. \n Proceso abortado.");
                return;
            }

            producto.PrecioCompra = nCosto;
            producto.PrecioCaja = nPrecioCaja;

            if (TxtPrecio1.Text.Trim().Length == 0)
                TxtPrecio1.Text = "1.000";

            if (TxtPrecio2.Text.Trim().Length == 0)
                TxtPrecio2.Text = "1.000";

            if (TxtPrecio3.Text.Trim().Length == 0)
                TxtPrecio3.Text = "1.000";

            if (TxtPrecio4.Text.Trim().Length == 0)
                TxtPrecio4.Text = "1.000";

            if (TxtU1.Text.Trim().Length == 0)
                TxtU1.Text = "1.000";

            if (TxtU2.Text.Trim().Length == 0)
                TxtU2.Text = "1.000";

            if (TxtU3.Text.Trim().Length == 0)
                TxtU3.Text = "1.000";

            if (TxtU4.Text.Trim().Length == 0)
                TxtU4.Text = "1.000";

            success = true;
            success = decimal.TryParse(TxtPrecio1.Text, out decimal nprecio1);
            success = decimal.TryParse(TxtPrecio2.Text, out decimal nprecio2);
            success = decimal.TryParse(TxtPrecio3.Text, out decimal nprecio3);
            success = decimal.TryParse(TxtPrecio4.Text, out decimal nprecio4);

            success = true;
            success = decimal.TryParse(TxtU1.Text, out decimal nMargen1);
            success = decimal.TryParse(TxtU2.Text, out decimal nMargen2);
            success = decimal.TryParse(TxtU3.Text, out decimal nMargen3);
            success = decimal.TryParse(TxtU4.Text, out decimal nMargen4);

            if (!success)
            {
                Ambiente.Mensaje("Precios o margenes no válidos. \n Proceso abortado.");
                return;
            }

            producto.Precio1 = nprecio1;
            producto.Precio2 = nprecio2;
            producto.Precio3 = nprecio3;
            producto.Precio4 = nprecio4;

            producto.Utilidad1 = nMargen1;
            producto.Utilidad2 = nMargen2;
            producto.Utilidad3 = nMargen3;
            producto.Utilidad4 = nMargen4;
            productoController.Update(producto);
        }

        private void InsertaCambioPrecio()
        {
            if (producto == null)
                return;

            if (producto.PrecioCompra != precioCompra)
            {
                cambioPrecio = new CambiosPrecio
                {
                    ProductoId = productoId,
                    PrecioCompraViejo = producto.PrecioCompra,
                    PrecioCompraNuevo = precioCompra,
                    Precio1Viejo = producto.Precio1,
                    Precio2Viejo = producto.Precio2,
                    Precio3Viejo = producto.Precio3,
                    Precio4Viejo = producto.Precio4,
                    Utilidad1Viejo = producto.Utilidad1,
                    Utilidad2Viejo = producto.Utilidad2,
                    Utilidad3Viejo = producto.Utilidad3,
                    Utilidad4Viejo = producto.Utilidad4,
                    CompraId = compra.CompraId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = Ambiente.LoggedUser.UsuarioId
                };

                success = true;
                success = decimal.TryParse(TxtPrecio1.Text, out decimal nprecio1);
                success = decimal.TryParse(TxtPrecio2.Text, out decimal nprecio2);
                success = decimal.TryParse(TxtPrecio3.Text, out decimal nprecio3);
                success = decimal.TryParse(TxtPrecio4.Text, out decimal nprecio4);

                success = true;
                success = decimal.TryParse(TxtU1.Text, out decimal nMargen1);
                success = decimal.TryParse(TxtU2.Text, out decimal nMargen2);
                success = decimal.TryParse(TxtU3.Text, out decimal nMargen3);
                success = decimal.TryParse(TxtU4.Text, out decimal nMargen4);

                if (!success)
                {
                    Ambiente.Mensaje("Precios o margenes no válidos. \n Proceso abortado.");
                    return;
                }

                cambioPrecio.Precio1Nuevo = nprecio1;
                cambioPrecio.Precio2Nuevo = nprecio2;
                cambioPrecio.Precio3Nuevo = nprecio3;
                cambioPrecio.Precio4Nuevo = nprecio4;

                cambioPrecio.Utilidad1Nuevo = nMargen1;
                cambioPrecio.Utilidad1Nuevo = nMargen2;
                cambioPrecio.Utilidad1Nuevo = nMargen3;
                cambioPrecio.Utilidad1Nuevo = nMargen4;


                cambioPrecioController.InsertOne(cambioPrecio);
            }
        }

        private void LimpiaData()
        {
            TxtProductoId.Text = string.Empty;
            TxtPrecioCompra.Text = string.Empty;
            TxtPrecioCaja.Text = string.Empty;
            TxtDescripcion.Text = string.Empty;
            TxtU1.Text = string.Empty;
            TxtU2.Text = string.Empty;
            TxtU3.Text = string.Empty;
            TxtU4.Text = string.Empty;
            TxtPrecio1.Text = string.Empty;
            TxtPrecio2.Text = string.Empty;
            TxtPrecio3.Text = string.Empty;
            TxtPrecio4.Text = string.Empty;
            GridImpuestos.Rows.Clear();
            GridImpuestos.Refresh();
            TxtPrecioS1.Text = string.Empty;
            TxtPrecioS2.Text = string.Empty;
            TxtPrecioS3.Text = string.Empty;
            TxtPrecioS4.Text = string.Empty;
            PbxImagen.Image = null;
            NDesc.Value = 0;
            NCantidad.Value = 1;
        }

        private void InsertaGrid()
        {
            try
            {
                if (TxtProductoId.Text.Trim().Length == 0)
                    return;
                ResetParcial();


                productoId = producto.ProductoId.Trim();
                descripcion = producto.Descripcion.Trim().Length == 0 ? "SYS" : producto.Descripcion.Trim();
                laboratorio = producto.LaboratorioId.Trim().Length == 0 ? "SYS" : producto.LaboratorioId.Trim();
                stock = producto.Stock;
                cantidad = NCantidad.Value;
                precioCompra = Ambiente.ToDecimal(TxtPrecioCompra.Text);
                if (precioCompra < producto.PrecioCompra)
                    if (!Ambiente.Pregunta("EL PRECIO DE COMMPRA ES INFERIOR QUE EL DE LA COMPRA ANTERIOR\n QUIERE CONTINUAR"))
                        return;
                precioCaja = producto.PrecioCaja;

                descuento = NDesc.Value / 100;

                int contador = 0;
                foreach (var i in Impuestos)
                {
                    if (contador == 0)
                        impuesto1 = i.Tasa;

                    else if (contador == 1)
                        impuesto1 = i.Tasa;

                }

                importeParcial = cantidad * precioCompra;
                if (descuento > 0)
                    importeParcial -= importeParcial * descuento;

                impuestoParcial = (importeParcial * impuesto1) + (importeParcial * impuesto2);
                nImpuestos = Impuestos.Count;

                //Acumular totales
                importeTotal += importeParcial;
                impuestoTotal += impuestoParcial;

                GridPartidas.Rows.Add();

                //productoId
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = productoId;
                //Descripcion
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[1].Value = descripcion;
                //LabId
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[2].Value = laboratorio;
                //Stock
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[3].Value = stock;
                //Cant
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[4].Value = cantidad;
                //PCompra
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[5].Value = precioCompra;
                //PCaja
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[6].Value = precioCaja;
                //Desc
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[7].Value = descuento;
                //Imp1
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[8].Value = impuesto1;
                //IMp2
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[9].Value = impuesto2;
                //Importe
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[10].Value = importeParcial;
                //Impuestos
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[11].Value = impuestoParcial;
                //ImporteNeto
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[12].Value = importeParcial + impuestoParcial;
                //CantImp
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[13].Value = nImpuestos;
                //Lote
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[14].Value = lote;
                //Caducidad
                if (lote.Trim().Length > 0)
                    GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[15].Value = caducidad;
                else
                    GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[15].Value = null;

                TxtSubtotal.Text = importeTotal.ToString();
                TxtImpuestos.Text = impuestoTotal.ToString();
                TxtTotal.Text = (importeTotal + impuestoTotal).ToString();

            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
        }


        private void InsertaData()
        {

            if (compra == null)
            {
                //Insertar la compra
                compra = new Compra();
                compra.AlmacenId = 1.ToString();
                compra.ProveedorId = TxtProvedorId.Text.Trim().Length == 0 ? "SYS" : TxtProvedorId.Text.Trim();
                compra.FacturaProveedor = TxtFacturaProveedor.Text.Trim().Length == 0 ? "SYS" : TxtFacturaProveedor.Text.Trim();
                compra.FechaDocumento = DpFechaDoc.Value;

                if (DpFechaVencimiento.Value.Date == DateTime.Now.Date)
                    compra.FechaVencimiento = DpFechaVencimiento.Value.AddDays(proveedor.DiasCredito);
                else
                    compra.FechaVencimiento = DpFechaVencimiento.Value;

                compra.EsCxp = ChkCXP.Checked;
                compra.Datos = TxtDatosProveedor.Text.Trim().Length == 0 ? "SYS" : TxtDatosProveedor.Text.Trim();
                compra.TipoDocId = "COM";
                compra.EstadoDocId = "PEN";
                compra.Importe = 0;
                compra.Impuesto = 0;
                compra.EstacionId = "SYS";
                compra.CreatedAt = DateTime.Now;
                compra.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                success = compraController.InsertOne(compra);

                //Insertat la primera partida
                if (success)
                {
                    if (compra == null)
                        return;

                    comprap = new Comprap
                    {
                        CompraId = compra.CompraId,
                        ProductoId = productoId,
                        Descripcion = descripcion,
                        LaboratorioId = laboratorio,
                        Stock = stock,
                        Cantidad = cantidad,
                        PrecioCompra = precioCompra,
                        PrecioCaja = precioCaja,
                        Descuento = descuento,
                        Impuesto1 = impuesto1,
                        Impuesto2 = impuesto2,
                        ImporteParcial = importeParcial,
                        ImpuestoParcial = impuestoParcial,
                        ImporteParcialNeto = importeParcial + impuestoParcial,
                        CantImpuestos = nImpuestos,
                        Lote = lote,
                        Caducidad = caducidad
                    };

                    success = compraController.InsertaPartida(comprap);
                    if (success)
                        GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[15].Value = comprap.ComprapId;
                }
                else
                    Ambiente.Mensaje("La compra no se guardó, No continue.");

            }
            else
            {
                //Inserta la n'esima partida
                if (success)
                {
                    if (compra == null)
                        return;

                    comprap = new Comprap
                    {
                        CompraId = compra.CompraId,
                        ProductoId = productoId,
                        Descripcion = descripcion,
                        LaboratorioId = laboratorio,
                        Stock = stock,
                        Cantidad = cantidad,
                        PrecioCompra = precioCompra,
                        PrecioCaja = precioCaja,
                        Descuento = descuento,
                        Impuesto1 = impuesto1,
                        Impuesto2 = impuesto2,
                        ImporteParcial = importeParcial,
                        ImpuestoParcial = impuestoParcial,
                        ImporteParcialNeto = importeParcial + impuestoParcial,
                        CantImpuestos = nImpuestos,
                        Lote = lote,
                        Caducidad = caducidad
                    };

                    success = compraController.InsertaPartida(comprap);
                    if (success)
                        GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[15].Value = comprap.ComprapId;
                }
                else
                    Ambiente.Mensaje("La parida anterior no se guardó, No continue.");
            }
        }

        private void TxtAlmacenId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtAlmacenId.Text, (int)Ambiente.TipoBusqueda.Almacenes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtAlmacenId.Text = form.Almacen.AlmacenId;
                    }
                }
            }
        }

        private void TxtProvedorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtProvedorId.Text, (int)Ambiente.TipoBusqueda.Proveedores))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        proveedor = form.Proveedor;
                        TxtProvedorId.Text = proveedor.ProveedorId;
                        TxtDatosProveedor.Text = proveedor.Negocio + " " + proveedor.Direccion + " " + proveedor.Colonia
                            + " " + proveedor.Municipio + " " + proveedor.Localidad + " " + proveedor.Estado + " TEL." + proveedor.Telefono;
                    }
                }
            }
        }

        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                producto = productoController.SelectOne(TxtProductoId.Text);
                if (producto != null)
                {
                    LlenaDatosProducto();
                    NCantidad.Focus();
                    return;
                }
                using (var form = new FrmBusqueda(TxtProductoId.Text, (int)Ambiente.TipoBusqueda.Productos))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TxtProductoId.Text = form.Producto.ProductoId;
                    }
                }
            }
        }

        private void LlenaDatosProducto()
        {

            TxtProductoId.Text = producto.ProductoId;
            TxtPrecioCompra.Text = producto.PrecioCompra.ToString();
            TxtPrecioCaja.Text = producto.PrecioCaja.ToString();
            TxtDescripcion.Text = producto.Descripcion;
            TxtU1.Text = producto.Utilidad1.ToString();
            TxtU2.Text = producto.Utilidad2.ToString();
            TxtU3.Text = producto.Utilidad3.ToString();
            TxtU4.Text = producto.Utilidad4.ToString();
            TxtPrecio1.Text = producto.Precio1.ToString();
            TxtPrecio2.Text = producto.Precio2.ToString();
            TxtPrecio3.Text = producto.Precio3.ToString();
            TxtPrecio4.Text = producto.Precio4.ToString();
            CargaListaImpuestos(producto);
            CargaGridImpuestos();
            TxtPrecioS1.Text = Ambiente.GetPrecioSalida(TxtPrecio1.Text, Impuestos);
            TxtPrecioS2.Text = Ambiente.GetPrecioSalida(TxtPrecio2.Text, Impuestos);
            TxtPrecioS3.Text = Ambiente.GetPrecioSalida(TxtPrecio3.Text, Impuestos);
            TxtPrecioS4.Text = Ambiente.GetPrecioSalida(TxtPrecio4.Text, Impuestos);
            PbxImagen.Image = GetImg(producto.RutaImg);
        }
        private void CargaGridImpuestos()
        {
            GridImpuestos.Rows.Clear();
            GridImpuestos.Refresh();
            foreach (var i in Impuestos)
            {
                GridImpuestos.Rows.Add();
                GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[0].Value = i.ImpuestoId;
                GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[1].Value = i.Tasa;
            }
        }
        private void CargaListaImpuestos(Producto producto)
        {

            Impuestos = new List<Impuesto>();

            ImpuestoController impuestoController = new ImpuestoController();

            if (!producto.Impuesto1Id.Equals("SYS"))
            {
                var impuesto1 = impuestoController.SelectOne(producto.Impuesto1Id);
                if (impuesto1 != null)
                    Impuestos.Add(impuesto1);
            }

            if (!producto.Impuesto2Id.Equals("SYS"))
            {
                var impuesto2 = impuestoController.SelectOne(producto.Impuesto2Id);
                if (impuesto2 != null)
                    Impuestos.Add(impuesto2);
            }
        }
        private Image GetImg(string ruta)
        {
            try
            {
                if (ruta == null)
                    return null;

                Image img = Image.FromFile(ruta);
                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }


        private void TxtU1_Leave(object sender, EventArgs e)
        {
            TxtU1.Text = Ambiente.FDinero(TxtU1.Text);
            TxtPrecio1.Text = Ambiente.GetPrecio(TxtPrecioCompra.Text, TxtU1.Text);

        }

        private void TxtU2_Leave(object sender, EventArgs e)
        {
            TxtU2.Text = Ambiente.FDinero(TxtU2.Text);
            TxtPrecio2.Text = Ambiente.GetPrecio(TxtPrecioCompra.Text, TxtU2.Text);
        }

        private void TxtU3_Leave(object sender, EventArgs e)
        {
            TxtU3.Text = Ambiente.FDinero(TxtU3.Text);
            TxtPrecio3.Text = Ambiente.GetPrecio(TxtPrecioCompra.Text, TxtU3.Text);
        }

        private void TxtU4_Leave(object sender, EventArgs e)
        {
            TxtU4.Text = Ambiente.FDinero(TxtU4.Text);
            TxtPrecio4.Text = Ambiente.GetPrecio(TxtPrecioCompra.Text, TxtU4.Text);
        }

        private void TxtPrecio1_Leave(object sender, EventArgs e)
        {
            TxtPrecio1.Text = Ambiente.FDinero(TxtPrecio1.Text);
            TxtU1.Text = Ambiente.GetMargen(TxtPrecioCompra.Text, TxtPrecio1.Text);
            TxtPrecioS1.Text = Ambiente.GetPrecioSalida(TxtPrecio1.Text, Impuestos);
        }

        private void TxtPrecio2_Leave(object sender, EventArgs e)
        {
            TxtPrecio2.Text = Ambiente.FDinero(TxtPrecio2.Text);
            TxtU2.Text = Ambiente.GetMargen(TxtPrecioCompra.Text, TxtPrecio2.Text);
            TxtPrecioS2.Text = Ambiente.GetPrecioSalida(TxtPrecio2.Text, Impuestos);
        }

        private void TxtPrecio3_Leave(object sender, EventArgs e)
        {
            TxtPrecio3.Text = Ambiente.FDinero(TxtPrecio3.Text);
            TxtU3.Text = Ambiente.GetMargen(TxtPrecioCompra.Text, TxtPrecio3.Text);
            TxtPrecioS3.Text = Ambiente.GetPrecioSalida(TxtPrecio3.Text, Impuestos);
        }

        private void TxtPrecio4_Leave(object sender, EventArgs e)
        {
            TxtPrecio4.Text = Ambiente.FDinero(TxtPrecio4.Text);
            TxtU4.Text = Ambiente.GetMargen(TxtPrecioCompra.Text, TxtPrecio4.Text);
            TxtPrecioS4.Text = Ambiente.GetPrecioSalida(TxtPrecio4.Text, Impuestos);
            BtnAgregar.Focus();
        }


        private void NCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Oemplus)
            //    NCantidad.Value++;
            //if (e.KeyCode == Keys.OemMinus)
            //    NCantidad.Value--;
        }

        private void NDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Oemplus)
            //    NCantidad.Value++;
            //if (e.KeyCode == Keys.OemMinus)
            //    NCantidad.Value--;
        }



        private void TxtProductoId_Leave(object sender, EventArgs e)
        {
            if (TxtProductoId.Text.Trim().Length > 0)
            {
                producto = productoController.SelectOne(TxtProductoId.Text);
                if (producto != null)
                {
                    LlenaDatosProducto();
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (compra == null)
                return;

            InsertaCxp();
            ActualizaEstadoCompra();
            ActualizaStock();
            LimpiaTodo();
        }

        private void LimpiaTodo()
        {
            ResetParcial();
            LimpiaData();
            TxtAlmacenId.Text = string.Empty;
            TxtProvedorId.Text = string.Empty;
            TxtFacturaProveedor.Text = string.Empty;
            TxtSubtotal.Text = string.Empty;
            TxtTotal.Text = string.Empty;
            TxtImpuestos.Text = string.Empty;
            DpFechaDoc.Value = DateTime.Now;
            ChkCXP.Checked = false;
            DpFechaVencimiento.Value = DateTime.Now;
            TxtDatosProveedor.Text = string.Empty;

            productoController = new ProductoController();
            compraController = new CompraController();
            cxpController = new CxpController();
            cxppController = new CxppController();
            cambioPrecioController = new CambioPrecioController();
            success = false;
            producto = null;
            proveedor = null;
            compra = null;
            comprap = null;
            cxp = null;
            cxpp = null;
            cambioPrecio = null;

            success = false;
            productoId = string.Empty;
            descripcion = string.Empty;
            cantidad = 0;
            precioCompra = 0;
            descuento = 0;
            impuesto1 = 0;
            impuesto2 = 0;

            impuestoParcial = 0;
            importeTotal = 0;
            impuestoTotal = 0;
            nImpuestos = 0;
            GridPartidas.Rows.Clear();

        }

        private void ActualizaStock()
        {

            var partidas = cxppController.TraePartidas(compra.CompraId);
            InventarioController inventarioController = new InventarioController();
            foreach (var p in partidas)
                inventarioController.AfectaInventario(p.ProductoId, (decimal)p.Cantidad);
        }

        private void ActualizaEstadoCompra()
        {
            if (success)
            {
                if (cxp != null)
                    compra.CxpId = cxp.CxpId;
                else
                    compra.CxpId = null;

                compra.Importe = importeTotal;
                compra.Impuesto = impuestoTotal;
                compra.EstadoDocId = "CON";

                success = false;
                success = compraController.Update(compra);

                if (true)
                {
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[1]);
                }
            }
            else

                Ambiente.Mensaje("Algo salío mal con la insercion de cxp o al cerrar la compra");
        }

        private void InsertaCxp()
        {
            if (ChkCXP.Checked)
            {
                cxp = new Cxp();
                cxp.CompraId = compra.CompraId;
                cxp.TipoDocId = "CXP";
                cxp.NoReferencia = Ambiente.TraeSiguiente("NO_REFEREN_CXP");
                cxp.ProveedorId = TxtProvedorId.Text.Trim().Length == 0 ? "SYS" : TxtProvedorId.Text.Trim();
                cxp.FechaDocumento = DateTime.Now;
                cxp.FechaVencimiento = compra.FechaVencimiento;
                cxp.FacturaProveedor = TxtFacturaProveedor.Text.Trim().Length == 0 ? "SYS" : TxtFacturaProveedor.Text.Trim();
                cxp.Importe = importeTotal + impuestoTotal;
                cxp.Saldo = importeTotal + impuestoTotal;
                cxp.EstadoDocId = "PEN";
                cxp.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                cxp.CreatedAt = DateTime.Now;

                success = false;
                success = cxpController.InsertOne(cxp);

                if (success)
                {
                    Ambiente.UpdateSiguiente("NO_REFEREN_CXP");
                    cxpp = new Cxpp();
                    cxpp.CxpId = cxp.CxpId;
                    cxpp.CompraId = compra.CompraId;
                    cxpp.ProveedorId = proveedor.ProveedorId;
                    cxpp.CargoAbono = "C";
                    cxpp.Importe = importeTotal + impuestoTotal;
                    cxpp.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                    cxpp.CreatedAt = DateTime.Now;

                    success = false;
                    success = cxppController.InsertOne(cxpp);

                    if (success)
                    {
                        cxp.EstadoDocId = "CON";
                        cxp.Importe = importeTotal + impuestoTotal;
                        cxp.Saldo = importeTotal + impuestoTotal;

                        success = false;
                        success = cxpController.Update(cxp);
                    }
                }




            }
        }

        private void NDesc_Leave(object sender, EventArgs e)
        {
            TxtU1.Focus();
        }

        private void TxtPrecioCompra_Leave(object sender, EventArgs e)
        {
            TxtPrecioCompra.Text = Ambiente.FDinero(TxtPrecioCompra.Text);
        }

        private void TxtPrecioCaja_Leave(object sender, EventArgs e)
        {
            TxtPrecioCaja.Text = Ambiente.FDinero(TxtPrecioCaja.Text);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GridPartidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && GridPartidas.RowCount > 0)
            {
                if (Ambiente.Pregunta("REALMENTE QUIERE BORRAR " + GridPartidas.Rows[GridPartidas.CurrentCell.RowIndex].Cells[1].Value))
                    BorrarPartida((int)GridPartidas.Rows[GridPartidas.CurrentCell.RowIndex].Cells[15].Value);
            }
        }

        private void BorrarPartida(int comprapId)
        {

            var comprap = compraController.SelectPartida(comprapId);
            if (comprap != null)
            {
                importeTotal -= (decimal)comprap.ImporteParcial;
                impuestoTotal -= (decimal)comprap.ImpuestoParcial;
                if (compraController.DeletePartida(comprapId))
                {
                    TxtSubtotal.Text = importeTotal.ToString();
                    TxtImpuestos.Text = impuestoTotal.ToString();
                    TxtTotal.Text = (importeTotal + impuestoTotal).ToString();
                    GridPartidas.Rows.RemoveAt(GridPartidas.CurrentCell.RowIndex);
                }
            }


        }
    }
}
