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
        decimal cantidad;
        decimal precioCompra;
        decimal descuento;
        decimal impuesto1;
        decimal impuesto2;
        decimal impuesto3;
        decimal importeParcial;
        decimal impuestoParcial;
        decimal importeTotal;
        decimal impuestoTotal;
        int cantImpuestos;



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
            Reset();
        }

        private void Reset()
        {
            productoId = string.Empty;
            descripcion = string.Empty;
            cantidad = 0;
            precioCompra = 0;
            descuento = 0;
            impuesto1 = 0;
            impuesto2 = 0;
            impuesto3 = 0;
            importeParcial = 0;
            impuestoParcial = 0;
            cantImpuestos = 0;
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
            {
                PideLotes();
            }


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
                    Ambiente.Mensaje("LOTES ASIGNADOS CON ÉXITO");
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
            TxtRutaImg.Text = string.Empty;
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
                Reset();
                productoId = TxtProductoId.Text.Trim();
                descripcion = TxtDescripcion.Text.Trim();
                cantidad = NCantidad.Value;
                precioCompra = Ambiente.ToDecimal(TxtPrecioCompra.Text);

                if (precioCompra < producto.PrecioCompra)
                    if (!Ambiente.Pregunta("EL PRECIO DE COMMPRA ES INFERIOR QUE EL DE LA COMPRA ANTERIOR\n QUIERE CONTINUAR"))
                        return;

                descuento = NDesc.Value;
                cantImpuestos = GridImpuestos.RowCount;

                importeParcial = cantidad * precioCompra;
                importeTotal += importeParcial;


                if (NDesc.Value > 0)
                    importeParcial -= importeParcial * (descuento / 100);

                if (GridImpuestos.RowCount == 1)
                {
                    impuesto1 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[0].Cells[0].Value.ToString());
                    impuestoParcial += importeParcial * impuesto1;
                    impuestoTotal += impuestoParcial;
                }
                else if (GridImpuestos.RowCount == 2)
                {
                    impuesto1 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[0].Cells[0].Value.ToString());
                    impuesto2 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[1].Cells[0].Value.ToString());

                    impuestoParcial += importeParcial * impuesto1;
                    impuestoParcial += importeParcial * impuesto2;
                    impuestoTotal += impuestoParcial;
                }
                else if (GridImpuestos.RowCount == 3)
                {
                    impuesto1 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[0].Cells[0].Value.ToString());
                    impuesto2 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[1].Cells[0].Value.ToString());
                    impuesto3 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[2].Cells[0].Value.ToString());
                    impuestoParcial += importeParcial * impuesto1;
                    impuestoParcial += importeParcial * impuesto2;
                    impuestoParcial += importeParcial * impuesto3;
                    impuestoTotal += impuestoParcial;
                }

                GridPartidas.Rows.Add();

                //productoId
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[0].Value = productoId;
                //Descripcion
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[1].Value = descripcion;
                //Cantidad
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[2].Value = cantidad;
                //PrecioCompra
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[3].Value = precioCompra;
                //Descuento
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[4].Value = descuento;
                //Impuesto 1
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[5].Value = impuesto1;
                //Impuesto 2
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[6].Value = impuesto2;
                //Impuesto 3
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[7].Value = impuesto3;
                //Importe
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[8].Value = importeParcial;
                //Impuestos
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[9].Value = impuestoParcial;
                //CantImp
                GridPartidas.Rows[GridPartidas.RowCount - 1].Cells[10].Value = cantImpuestos;

                TxtSubtotal.Text = importeParcial.ToString();
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
                compra.AlmacenId = TxtAlmacenId.Text.Trim().Length == 0 ? "SYS" : TxtAlmacenId.Text.Trim();
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
                        Cantidad = cantidad,
                        Descuento = descuento,
                        CantImpuestos = cantImpuestos,
                        PrecioCompra = precioCompra,
                        Importe = importeParcial,
                        Impuesto1 = impuesto1,
                        Impuesto2 = impuesto2,
                        Impuesto3 = impuesto3,
                        Impuestos = impuestoParcial,

                    };

                    success = compraController.InsertaPartida(comprap);
                }
                else
                    Ambiente.Mensaje("La compra no se guardó, No continue.");

            }
            else
            {
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
                        Cantidad = cantidad,
                        Descuento = descuento,
                        CantImpuestos = cantImpuestos,
                        PrecioCompra = precioCompra,
                        Importe = importeParcial,
                        Impuesto1 = impuesto1,
                        Impuesto2 = impuesto2,
                        Impuesto3 = impuesto3,
                        Impuestos = impuestoParcial,

                    };

                    success = compraController.InsertaPartida(comprap);
                }
                else
                    Ambiente.Mensaje("La compra no se guardó, No continue.");
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
            TxtRutaImg.Text = producto.RutaImg;
            //GridExistencias.DataSource = producto.ProductoAlmacen.Select(x => new { x.AlmacenId, x.ExistenciaId }).ToList();
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
                //GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[1].Value = i.Tasa;
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

            if (!producto.Impuesto3Id.Equals("SYS"))
            {
                var impuesto3 = impuestoController.SelectOne(producto.Impuesto3Id);
                if (impuesto3 != null)
                    Impuestos.Add(impuesto3);
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
        private void LlenaGridImpuestos(ICollection<ProductoImpuesto> impuestoParcial)
        {
            GridImpuestos.Rows.Clear();
            GridImpuestos.Refresh();
            foreach (var productoImpuesto in impuestoParcial)
            {
                GridImpuestos.Rows.Add();
                GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[0].Value = productoImpuesto.ImpuestoId;
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
            Reset();
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
            impuesto3 = 0;
            importeParcial = 0;
            impuestoParcial = 0;
            importeTotal = 0;
            impuestoTotal = 0;
            cantImpuestos = 0;
            GridPartidas.Rows.Clear();

        }

        private void ActualizaStock()
        {

            var partidas = cxppController.TraePartidas(compra.CompraId);
            InventarioController inventarioController = new InventarioController();
            foreach (var p in partidas)
                inventarioController.AfectaInventario(p.ProductoId, p.Cantidad);
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

        private void TxtBuscarImpuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtBuscarImpuesto.Text, (int)Ambiente.TipoBusqueda.Impuestos))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        //InsertaImpuesto(impuesto);
                    }
                }
            }
        }

        private void InsertaImpuesto(Impuesto impuesto)
        {
            for (int i = 0; i < GridImpuestos.RowCount; i++)
            {
                if (true)
                {

                }
            }
        }
    }
}
