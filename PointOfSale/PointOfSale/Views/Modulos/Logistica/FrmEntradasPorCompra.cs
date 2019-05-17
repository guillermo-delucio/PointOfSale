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

        Producto producto;
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
        int cantImpuestos;



        public FrmEntradasPorCompra()
        {
            InitializeComponent();
            productoController = new ProductoController();
            compraController = new CompraController();
            cxpController = new CxpController();
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
            InsertaGrid();
            InsertaData();
            LimpiaData();
            TxtProductoId.Focus();
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
            TxtRutaImg.Text = producto.RutaImg;
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

                if (NDesc.Value > 0)
                    importeParcial -= importeParcial * (descuento / 100);

                if (GridImpuestos.RowCount == 1)
                {
                    impuesto1 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[0].Cells[0].Value.ToString());
                    impuestoParcial += importeParcial * impuesto1;
                }
                else if (GridImpuestos.RowCount == 2)
                {
                    impuesto1 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[0].Cells[0].Value.ToString());
                    impuesto2 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[1].Cells[0].Value.ToString());
                    impuestoParcial += importeParcial * impuesto1;
                    impuestoParcial += importeParcial * impuesto2;
                }
                else if (GridImpuestos.RowCount == 3)
                {
                    impuesto1 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[0].Cells[0].Value.ToString());
                    impuesto2 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[1].Cells[0].Value.ToString());
                    impuesto3 = Ambiente.GetTasaImpuesto(GridImpuestos.Rows[2].Cells[0].Value.ToString());
                    impuestoParcial += importeParcial * impuesto1;
                    impuestoParcial += importeParcial * impuesto2;
                    impuestoParcial += importeParcial * impuesto3;
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
                TxtImpuestos.Text = impuestoParcial.ToString();
                TxtTotal.Text = (importeParcial + impuestoParcial).ToString();

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
                        TxtProvedorId.Text = form.Proveedor.ProveedorId;
                        TxtDatosProveedor.Text = form.Proveedor.Negocio + " " + form.Proveedor.Direccion + " " + form.Proveedor.Colonia
                            + " " + form.Proveedor.Municipio + " " + form.Proveedor.Localidad + " " + form.Proveedor.Estado + " TEL." + form.Proveedor.Telefono;
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
            LlenaGridImpuestos(producto.ProductoImpuesto);
            TxtPrecioS1.Text = Ambiente.GetPrecioSstring(producto.Precio1.ToString(), producto.ProductoImpuesto);
            TxtPrecioS2.Text = Ambiente.GetPrecioSstring(producto.Precio2.ToString(), producto.ProductoImpuesto);
            TxtPrecioS3.Text = Ambiente.GetPrecioSstring(producto.Precio3.ToString(), producto.ProductoImpuesto);
            TxtPrecioS4.Text = Ambiente.GetPrecioSstring(producto.Precio4.ToString(), producto.ProductoImpuesto);
            TxtRutaImg.Text = producto.RutaImg;
            //GridExistencias.DataSource = objeto.ProductoAlmacen.Select(x => new { x.AlmacenId, x.ExistenciaId }).ToList();
            PbxImagen.Image = GetImg(producto.RutaImg);
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
            TxtPrecio1.Text = Ambiente.GetPrecioString(TxtPrecioCompra.Text, TxtU1.Text);

        }

        private void TxtU2_Leave(object sender, EventArgs e)
        {
            TxtU2.Text = Ambiente.FDinero(TxtU2.Text);
            TxtPrecio2.Text = Ambiente.GetPrecioString(TxtPrecioCompra.Text, TxtU2.Text);
        }

        private void TxtU3_Leave(object sender, EventArgs e)
        {
            TxtU3.Text = Ambiente.FDinero(TxtU3.Text);
            TxtPrecio3.Text = Ambiente.GetPrecioString(TxtPrecioCompra.Text, TxtU3.Text);
        }

        private void TxtU4_Leave(object sender, EventArgs e)
        {
            TxtU4.Text = Ambiente.FDinero(TxtU4.Text);
            TxtPrecio4.Text = Ambiente.GetPrecioString(TxtPrecioCompra.Text, TxtU4.Text);
        }

        private void TxtPrecio1_Leave(object sender, EventArgs e)
        {
            TxtPrecio1.Text = Ambiente.FDinero(TxtPrecio1.Text);
            TxtU1.Text = Ambiente.GetMargenString(TxtPrecioCompra.Text, TxtPrecio1.Text);
            TxtPrecioS1.Text = Ambiente.GetPrecioSstring(TxtPrecio1.Text, GridImpuestos, 0);
        }

        private void TxtPrecio2_Leave(object sender, EventArgs e)
        {
            TxtPrecio2.Text = Ambiente.FDinero(TxtPrecio2.Text);
            TxtU2.Text = Ambiente.GetMargenString(TxtPrecioCompra.Text, TxtPrecio2.Text);
            TxtPrecioS2.Text = Ambiente.GetPrecioSstring(TxtPrecio2.Text, GridImpuestos, 0);
        }

        private void TxtPrecio3_Leave(object sender, EventArgs e)
        {
            TxtPrecio3.Text = Ambiente.FDinero(TxtPrecio3.Text);
            TxtU3.Text = Ambiente.GetMargenString(TxtPrecioCompra.Text, TxtPrecio3.Text);
            TxtPrecioS3.Text = Ambiente.GetPrecioSstring(TxtPrecio3.Text, GridImpuestos, 0);
        }

        private void TxtPrecio4_Leave(object sender, EventArgs e)
        {
            TxtPrecio4.Text = Ambiente.FDinero(TxtPrecio4.Text);
            TxtU4.Text = Ambiente.GetMargenString(TxtPrecioCompra.Text, TxtPrecio4.Text);
            TxtPrecioS4.Text = Ambiente.GetPrecioSstring(TxtPrecio4.Text, GridImpuestos, 0);
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
            //if (Success)
            //{
            //    if (ChkCXP.Checked)
            //    {
            //        if (Cxp == null)
            //        {
            //            Cxp = new Cxp();
            //        }
            //        else
            //        {

            //        }
            //    }
            //}
        }

        private void NDesc_Leave(object sender, EventArgs e)
        {
            TxtU1.Focus();
        }
    }
}
