using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmProducto : Form
    {

        #region Variables de clase
        ProductoController ProductoController;
        ICollection<ProductoImpuesto> ProductoImpuesto;
        ICollection<ProductoSustancia> ProductoSustancia;
        bool ModoCreate;
        private dynamic objeto;
        #endregion

        #region Contructores
        public FrmProducto()
        {
            InitializeComponent();
            ProductoController = new ProductoController();
            ProductoImpuesto = new HashSet<ProductoImpuesto>();
            ProductoSustancia = new HashSet<ProductoSustancia>();
            ModoCreate = false;
        }

        public FrmProducto(dynamic objeto)
        {
            this.objeto = objeto;
        }

        #endregion

        #region Busquedas
        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarCoincidencias(TxtProductoId.Text);

        }




        private void TxtPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtPresentacion.Text, (int)Ambiente.TipoBusqueda.Presentaciones))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        TxtPresentacion.Text = form.Presentacion.PresentacionId;
                }
            }
        }

        private void TxtUnidadMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtUnidadMedida.Text, (int)Ambiente.TipoBusqueda.UnidadesMedida))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        TxtUnidadMedida.Text = form.UnidadMedida.UnidadMedidaId;
                }
            }
        }

        private void TxtLaboratorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtLaboratorio.Text, (int)Ambiente.TipoBusqueda.Laboratorios))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        TxtLaboratorio.Text = form.Laboratorio.LaboratorioId;
                }
            }
        }

        private void TxtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtCategoria.Text, (int)Ambiente.TipoBusqueda.Categorias))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        TxtCategoria.Text = form.Categoria.CategoriaId;
                }
            }
        }

        private void TxtClaveSat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtClaveCFDI.Text, (int)Ambiente.TipoBusqueda.ClavesSat))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        TxtClaveCFDI.Text = form.ClaveSat.ClaveSatId;
                }
            }
        }

        private void TxtBuscarImpuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtBuscarImpuestos.Text, (int)Ambiente.TipoBusqueda.Impuestos))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (ProductoImpuesto.FirstOrDefault(x => x.ImpuestoId == form.Impuesto.ImpuestoId) == null)
                        {
                            ProductoImpuesto.Add(new ProductoImpuesto()
                            {
                                ProductoId = TxtProductoId.Text.Trim(),
                                ImpuestoId = form.Impuesto.ImpuestoId
                            });
                        }
                    }
                }
            }
        }

        private void TxtBuscarExistencias_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TxtBuscarSustancias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtBuscarSustancias.Text, (int)Ambiente.TipoBusqueda.Sustancias))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (ProductoSustancia.FirstOrDefault(x => x.SustanciaId == form.Sustancia.SustanciaId) == null)
                        {

                            var contenido = string.Empty;
                            Ambiente.InputBox("SOLICITUD DE CONTENIDO", "DAME CONTENIDO PARA:" + form.Sustancia.Nombre, ref contenido);

                            ProductoSustancia.Add(new ProductoSustancia()
                            {
                                ProductoId = TxtProductoId.Text.Trim(),
                                SustanciaId = form.Sustancia.SustanciaId,
                                Contenido = contenido
                            });
                        }
                    }
                }
            }
        }

        #endregion

        #region Cambios de precio
        private void TxtU1_Leave(object sender, EventArgs e)
        {

        }

        private void TxtPrecio1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void TxtU2_Leave(object sender, EventArgs e)
        {

        }

        private void TxtPrecio2_Leave(object sender, EventArgs e)
        {

        }

        private void TxtU3_Leave(object sender, EventArgs e)
        {

        }

        private void TxtPrecio3_Leave(object sender, EventArgs e)
        {

        }

        private void TxtU4_Leave(object sender, EventArgs e)
        {

        }

        private void TxtPrecio4_Leave(object sender, EventArgs e)
        {

        }

        #endregion

        #region Borrar impuestos y sustancias
        private void Gridmpuestos_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GridSustancias_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #region Lena Grids a partir de una lista
        private void LlenaGridProductos(List<Producto> productos)
        {
            GridProductos.Rows.Clear();

            foreach (var producto in productos)
            {
                GridProductos.Rows.Add();
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[0].Value = producto.ProductoId;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[1].Value = producto.Descripcion;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[2].Value = producto.Precio1;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[3].Value = producto.Stock;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[4].Value = producto.PresentacionId;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[5].Value = producto.CategoriaId;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[6].Value = producto.LaboratorioId;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[7].Value = producto.Unidades;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[8].Value = producto.IsDeleted;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[9].Value = producto.UpdatedBy;
                GridProductos.Rows[GridProductos.Rows.Count - 1].Cells[10].Value = producto.UpdatedAt;
            }

        }

        private void LlenaGridImpuestos(ICollection<ProductoImpuesto> productoImpuestos)
        {
            GridImpuestos.Rows.Clear();
            foreach (var impuesto in productoImpuestos)
            {
                GridImpuestos.Rows.Add();
                GridImpuestos.Rows[GridImpuestos.Rows.Count - 1].Cells[0].Value = impuesto.ProductoId;
                GridImpuestos.Rows[GridImpuestos.Rows.Count - 1].Cells[1].Value = impuesto.ImpuestoId;
            }
        }

        private void LlenaGridSustancias(ICollection<ProductoSustancia> productoSustancias)
        {

            GridSustancias.Rows.Clear();
            foreach (var sustancia in productoSustancias)
            {
                GridSustancias.Rows.Add();
                GridSustancias.Rows[GridSustancias.Rows.Count - 1].Cells[0].Value = sustancia.SustanciaId;
                GridSustancias.Rows[GridSustancias.Rows.Count - 1].Cells[1].Value = sustancia.Contenido;
            }
        }
        #endregion

        #region Metodo BuscarCoincidencias y habilitacion de modo de operacion

        private void BuscarCoincidencias(string text)
        {
            if (ChkFiltroSustancia.Checked)
            {
                #region Busqueda por sustancias

                Text = "MODO VER / ACTUALIZAR PRODUCTO";
                ModoCreate = false;
                LlenaGridProductos(ProductoController.FiltrarVsSustancia(text));
                GridProductos.Focus();

                #endregion

            }
            else
            {
                #region Si no hay criterio de busqueda, devuelte los primeros 100
                if (text.Trim().Length == 0)
                {
                    LlenaGridProductos(ProductoController.SelectMany(100));
                    ModoCreate = false;
                    GridProductos.Focus();
                    return;
                }
                #endregion

                #region Busca por coicidencias aproximadas

                if (ProductoController.SelectOneOverList(text).Count > 0)
                {
                    //Entrotrado por clave
                    Text = "MODO VER / ACTUALIZAR PRODUCTO";
                    LlenaGridProductos(ProductoController.SelectOneOverList(text));
                    GridProductos.Focus();
                    ModoCreate = false;
                    return;
                }
                else
                {
                    #region Buscar por coicidencias aproximadas

                    if (ProductoController.FiltrarVsDescrip(text).Count > 0)
                    {
                        //Encontrado por descripcion
                        Text = "MODO VER / ACTUALIZAR PRODUCTO";
                        LlenaGridProductos(ProductoController.FiltrarVsDescrip(text));
                        ModoCreate = false;
                        GridProductos.Focus();
                    }
                    else
                    {

                        #region Nuevo producto
                        Text = "MODO CREAR PRODUCTO";
                        TxtProductoId.Text = text;
                        TxtDescripcion.Focus();
                        ModoCreate = true;
                        #endregion

                    }
                    #endregion
                }
                #endregion

            }
        }
        #endregion

        #region Guardar y salir
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void InsertOrUpdate()
        {
            Producto producto;

            if (ModoCreate)
            {
                producto = new Producto();
                producto.ProductoId = TxtProductoId.Text.Trim();
            }
            else
                producto = ProductoController.SelectOne(TxtProductoId.Text);


            producto.Descripcion = TxtDescripcion.Text.Length == 0 ? null : TxtDescripcion.Text;
            producto.Contenido = TxtContenido.Text.Length == 0 ? null : TxtContenido.Text;
            producto.PresentacionId = TxtPresentacion.Text.Trim().Length == 0 ? null : TxtPresentacion.Text.Trim();
            producto.UnidadMedidaId = TxtUnidadMedida.Text.Trim().Length == 0 ? null : TxtUnidadMedida.Text.Trim();
            producto.Unidades = TxtUnidades.Text.Trim().Length == 0 ? null : TxtUnidades.Text.Trim();
            producto.LaboratorioId = TxtLaboratorio.Text.Trim().Length == 0 ? null : TxtLaboratorio.Text.Trim();
            producto.CategoriaId = TxtCategoria.Text.Trim().Length == 0 ? null : TxtCategoria.Text.Trim();
            producto.UnidadCfdi = TxtUnidadCFDI.Text.Trim().Length == 0 ? null : TxtUnidadCFDI.Text.Trim();
            producto.ClaveCfdiId = TxtClaveCFDI.Text.Trim().Length == 0 ? null : TxtClaveCFDI.Text.Trim();


            bool success = true;

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
            producto.IsDeleted = !ChkEnCatalogo.Checked;
            producto.TieneLote = ChkLote.Checked;


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


            //Limiar la coleeccion de impuetos y agregar los nuevos
            producto.ProductoImpuesto.Clear();
            for (int i = 0; i < GridImpuestos.RowCount - 1; i++)
            {
                producto.ProductoImpuesto.Add(
                    new ProductoImpuesto()
                    {
                        ProductoId = GridImpuestos.Rows[i].Cells[0].Value.ToString().Trim(),
                        ImpuestoId = GridImpuestos.Rows[i].Cells[1].Value.ToString().Trim()

                    });
            }


            //Limiar la coleccion de sustancias y agregar los nuevos
            producto.ProductoSustancia.Clear();
            for (int i = 0; i < GridSustancias.RowCount - 1; i++)
            {
                producto.ProductoSustancia.Add(
                    new ProductoSustancia()
                    {
                        ProductoId = producto.ProductoId,
                        SustanciaId = GridSustancias.Rows[i].Cells[0].Value.ToString().Trim(),
                        Contenido = GridSustancias.Rows[i].Cells[1].Value.ToString().Trim()
                    });
            }

            producto.RutaImg = TxtRutaImg.Text.Trim().Length == 0 ? null : TxtRutaImg.Text.Trim();

            if (ModoCreate)
            {
                if (ProductoController.InsertOne(producto))
                    Ambiente.Mensaje("Cambios guardasos");
                else
                    Ambiente.Mensaje("Algo salió mal :( ");
            }
            else
            {

                if (ProductoController.Update(producto))
                    Ambiente.Mensaje("Cambios guardasos");
                else
                    Ambiente.Mensaje("Algo salió mal :( ");
            }



        }


        #endregion

        #region Al cambiar la seleccion en el Grid de productos

        private void GridProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (GridProductos.Rows[GridProductos.CurrentCell.RowIndex].Cells[0].Value != null)
            {
                var IdProducto = GridProductos.Rows[GridProductos.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
                using (var db = new DymContext())
                {
                    var producto = db.Producto.Where(x => x.ProductoId == IdProducto).FirstOrDefault();
                    if (producto != null)
                    {
                        LimpiaCampos();
                        LlenaCampos(producto);
                    }
                }

            }



        }
        private void GridProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TxtDescripcion.Focus();
            }
        }
        private void LimpiaCampos()
        {
            TxtDescripcion.Text = string.Empty;
            TxtContenido.Text = string.Empty;
            TxtPresentacion.Text = string.Empty;
            TxtUnidadMedida.Text = string.Empty;
            TxtUnidades.Text = string.Empty;
            TxtLaboratorio.Text = string.Empty;
            TxtCategoria.Text = string.Empty;
            TxtClaveCFDI.Text = string.Empty;
            TxtUnidadCFDI.Text = string.Empty;
            TxtPrecioCompra.Text = string.Empty;
            TxtPrecioCaja.Text = string.Empty;
            ChkEnCatalogo.Checked = false;
            ChkLote.Checked = false;
            TxtBuscarImpuestos.Text = string.Empty;
            TxtBuscarSustancias.Text = string.Empty;
            TxtBuscarExistencias.Text = string.Empty;
            ProductoImpuesto = new HashSet<ProductoImpuesto>();
            ProductoSustancia = new HashSet<ProductoSustancia>();
            GridImpuestos.Rows.Clear();
            GridSustancias.Rows.Clear();

            TxtU1.Text = string.Empty;
            TxtU2.Text = string.Empty;
            TxtU3.Text = string.Empty;
            TxtU4.Text = string.Empty;
            TxtPrecio1.Text = string.Empty;
            TxtPrecio2.Text = string.Empty;
            TxtPrecio3.Text = string.Empty;
            TxtPrecio4.Text = string.Empty;
            TxtPrecioS1.Text = string.Empty;
            TxtPrecioS2.Text = string.Empty;
            TxtPrecioS3.Text = string.Empty;
            TxtPrecioS4.Text = string.Empty;
            TxtRutaImg.Text = string.Empty;
        }
        private void LlenaCampos(Producto producto)
        {
            TxtProductoId.Text = producto.ProductoId;
            TxtDescripcion.Text = producto.Descripcion;
            TxtContenido.Text = producto.Contenido;
            TxtPresentacion.Text = producto.PresentacionId;
            TxtUnidadMedida.Text = producto.UnidadMedidaId;
            TxtUnidades.Text = producto.Unidades;
            TxtLaboratorio.Text = producto.LaboratorioId;
            TxtCategoria.Text = producto.CategoriaId;
            TxtUnidadCFDI.Text = producto.UnidadCfdi;
            TxtClaveCFDI.Text = producto.ClaveCfdiId;
            TxtPrecioCompra.Text = Ambiente.FDinero(producto.PrecioCompra.ToString());
            TxtPrecioCaja.Text = Ambiente.FDinero(producto.PrecioCaja.ToString());
            ChkEnCatalogo.Checked = !producto.IsDeleted;
            ChkLote.Checked = producto.TieneLote;
            LlenaGridImpuestos(producto.ProductoImpuesto);
            LlenaGridSustancias(producto.ProductoSustancia);



            TxtPrecio1.Text = producto.Precio1.ToString();
            TxtPrecio2.Text = producto.Precio2.ToString();
            TxtPrecio3.Text = producto.Precio3.ToString();
            TxtPrecio4.Text = producto.Precio4.ToString();
            TxtU1.Text = producto.Utilidad1.ToString();
            TxtU2.Text = producto.Utilidad2.ToString();
            TxtU3.Text = producto.Utilidad3.ToString();
            TxtU4.Text = producto.Utilidad4.ToString();
            TxtPrecioS1.Text = Ambiente.GetPrecioSstring(producto.Precio1.ToString(), producto.ProductoImpuesto);
            TxtPrecioS2.Text = Ambiente.GetPrecioSstring(producto.Precio2.ToString(), producto.ProductoImpuesto);
            TxtPrecioS3.Text = Ambiente.GetPrecioSstring(producto.Precio3.ToString(), producto.ProductoImpuesto);
            TxtPrecioS4.Text = Ambiente.GetPrecioSstring(producto.Precio4.ToString(), producto.ProductoImpuesto);
            TxtRutaImg.Text = producto.RutaImg;
            GridExistencias.DataSource = producto.ProductoAlmacen.Select(x => new { x.Almacen, x.Existencia }).ToList();

        }



        #endregion

        private void TxtRutaImg_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {

        }
    }
}