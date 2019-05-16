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

        Producto Producto;
        Compra Compra;
        Comprap PartidaCompra;
        Cxp Cxp;
        Cxpp PartidasCXP;
        CambiosPrecio CambioPrecio;
        bool Success;

        public FrmEntradasPorCompra()
        {
            InitializeComponent();
            productoController = new ProductoController();
            compraController = new CompraController();
            cxpController = new CxpController();

            Success = false;
            Producto = null;
            Compra = null;
            PartidaCompra = new Comprap();
            Cxp = null;
            PartidasCXP = new Cxpp();
            CambioPrecio = null;
        }

        private void TxtDescuento_Leave(object sender, EventArgs e)
        {
            TxtU1.Focus();
        }



        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            InsertaData();
            TxtProductoId.Focus();
        }

        private void InsertaData()
        {

            if (Compra == null)
            {
                //Insertar la compra
                Compra = new Compra();
                Compra.AlmacenId = TxtAlmacenId.Text.Trim().Length == 0 ? "SYS" : TxtAlmacenId.Text.Trim();
                Compra.ProveedorId = TxtProvedorId.Text.Trim().Length == 0 ? "SYS" : TxtProvedorId.Text.Trim();
                Compra.FacturaProveedor = TxtFacturaProveedor.Text.Trim().Length == 0 ? "SYS" : TxtFacturaProveedor.Text.Trim();
                Compra.FechaDocumento = DpFechaDoc.Value;
                Compra.FechaVencimiento = DpFechaVencimiento.Value;
                Compra.EsCxp = ChkCXP.Checked;
                Compra.Datos = TxtDatosProveedor.Text.Trim().Length == 0 ? "SYS" : TxtDatosProveedor.Text.Trim();
                Compra.TipoDocId = "COM";
                Compra.EstadoDocId = "PEN";
                Compra.Importe = 0;
                Compra.Impuesto = 0;
                Compra.EstacionId = "SYS";
                Compra.CreatedAt = DateTime.Now;
                Compra.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                Success = compraController.InsertOne(Compra);
            }
            else
            {
                //Inserar las partidas
                if (Success)
                {
                    if (Compra == null)
                        return;

                    PartidaCompra = new Comprap();
                    PartidaCompra.CompraId = Compra.CompraId;
                    PartidaCompra.ProductoId = TxtProductoId.Text.Trim().Length == 0 ? "SYS" : TxtProductoId.Text.Trim();


                }
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
                Producto = productoController.SelectOne(TxtProductoId.Text);
                if (Producto != null)
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
            TxtProductoId.Text = Producto.ProductoId;
            TxtPrecioCompra.Text = Producto.PrecioCompra.ToString();
            TxtPrecioCaja.Text = Producto.PrecioCaja.ToString();
            TxtU1.Text = Producto.Utilidad1.ToString();
            TxtU2.Text = Producto.Utilidad2.ToString();
            TxtU3.Text = Producto.Utilidad3.ToString();
            TxtU4.Text = Producto.Utilidad4.ToString();
            TxtPrecio1.Text = Producto.Precio1.ToString();
            TxtPrecio2.Text = Producto.Precio2.ToString();
            TxtPrecio3.Text = Producto.Precio3.ToString();
            TxtPrecio4.Text = Producto.Precio4.ToString();
            LlenaGridImpuestos(Producto.ProductoImpuesto);
            TxtPrecioS1.Text = Ambiente.GetPrecioSstring(Producto.Precio1.ToString(), Producto.ProductoImpuesto);
            TxtPrecioS2.Text = Ambiente.GetPrecioSstring(Producto.Precio2.ToString(), Producto.ProductoImpuesto);
            TxtPrecioS3.Text = Ambiente.GetPrecioSstring(Producto.Precio3.ToString(), Producto.ProductoImpuesto);
            TxtPrecioS4.Text = Ambiente.GetPrecioSstring(Producto.Precio4.ToString(), Producto.ProductoImpuesto);
            TxtRutaImg.Text = Producto.RutaImg;
            //GridExistencias.DataSource = objeto.ProductoAlmacen.Select(x => new { x.AlmacenId, x.ExistenciaId }).ToList();
            PbxImagen.Image = GetImg(Producto.RutaImg);
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
        private void LlenaGridImpuestos(ICollection<ProductoImpuesto> impuestos)
        {
            GridImpuestos.Rows.Clear();
            GridImpuestos.Refresh();
            foreach (var productoImpuesto in impuestos)
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

        private void NDescuento_Leave(object sender, EventArgs e)
        {
            TxtU1.Focus();
        }

        private void TxtProductoId_Leave(object sender, EventArgs e)
        {
            if (TxtProductoId.Text.Trim().Length > 0)
            {
                Producto = productoController.SelectOne(TxtProductoId.Text);
                if (Producto != null)
                {
                    LlenaDatosProducto();
                }
            }
        }


    }
}
