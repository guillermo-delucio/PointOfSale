using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmProductos : Form
    {
        private dynamic objeto;
        private ProductoController productoController;
        bool ModoCreate;
        bool ModoUpdate;

        public FrmProductos()
        {
            InitializeComponent();
            productoController = new ProductoController();
            ModoCreate = true;
            ModoUpdate = false;
        }

        public FrmProductos(dynamic objeto)
        {
            InitializeComponent();
            productoController = new ProductoController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Producto)this.objeto;
                TxtProductoId.Text = objeto.ProductoId;
                ModoUpdate = true;
            }

        }





        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void InsertOrUpdate()
        {
            if (ModoCreate)
            {
                if (TxtProductoId.Text.Trim().Length == 0)
                    return;

                objeto = new Producto();
                objeto.ProductoId = TxtProductoId.Text.Trim();
                objeto.Descripcion = TxtDescripcion.Text.Length == 0 ? null : TxtDescripcion.Text;
                objeto.Contenido = TxtContenido.Text.Length == 0 ? null : TxtContenido.Text;
                objeto.PresentacionId = TxtPresentacion.Text.Trim().Length == 0 ? null : TxtPresentacion.Text.Trim();
                objeto.UnidadMedidaId = TxtUnidadMedida.Text.Trim().Length == 0 ? null : TxtUnidadMedida.Text.Trim();
                objeto.Unidades = TxtUnidades.Text.Trim().Length == 0 ? null : TxtUnidades.Text.Trim();
                objeto.LaboratorioId = TxtLaboratorio.Text.Trim().Length == 0 ? null : TxtLaboratorio.Text.Trim();
                objeto.CategoriaId = TxtCategoria.Text.Trim().Length == 0 ? null : TxtCategoria.Text.Trim();
                objeto.UnidadCfdi = TxtUnidadCFDI.Text.Trim().Length == 0 ? null : TxtUnidadCFDI.Text.Trim();
                objeto.ClaveCfdiId = TxtClaveCFDI.Text.Trim().Length == 0 ? null : TxtClaveCFDI.Text.Trim();


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

                objeto.PrecioCompra = nCosto;
                objeto.PrecioCaja = nPrecioCaja;
                objeto.IsDeleted = !ChkEnCatalogo.Checked;
                objeto.TieneLote = ChkLote.Checked;


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

                objeto.Precio1 = nprecio1;
                objeto.Precio2 = nprecio2;
                objeto.Precio3 = nprecio3;
                objeto.Precio4 = nprecio4;

                objeto.Utilidad1 = nMargen1;
                objeto.Utilidad2 = nMargen2;
                objeto.Utilidad3 = nMargen3;
                objeto.Utilidad4 = nMargen4;


                //Limiar la coleeccion de impuetos y agregar los nuevos
                objeto.ProductoImpuesto.Clear();
                for (int i = 0; i < GridImpuestos.RowCount - 1; i++)
                {
                    objeto.ProductoImpuesto.Add(
                        new ProductoImpuesto()
                        {
                            ProductoId = objeto.ProductoId,
                            ImpuestoId = GridImpuestos.Rows[i].Cells[1].Value.ToString().Trim()

                        });
                }


                //Limiar la coleccion de sustancias y agregar los nuevos
                objeto.ProductoSustancia.Clear();
                for (int i = 0; i < GridSustancias.RowCount - 1; i++)
                {
                    objeto.ProductoSustancia.Add(
                        new ProductoSustancia()
                        {
                            ProductoId = objeto.ProductoId,
                            SustanciaId = GridSustancias.Rows[i].Cells[0].Value.ToString().Trim(),
                            Contenido = GridSustancias.Rows[i].Cells[1].Value.ToString().Trim()
                        });
                }

                objeto.RutaImg = TxtRutaImg.Text.Trim().Length == 0 ? null : TxtRutaImg.Text.Trim();


                if (productoController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                objeto = null;
            }
            else
            {
                objeto.Descripcion = TxtDescripcion.Text.Length == 0 ? null : TxtDescripcion.Text;
                objeto.Contenido = TxtContenido.Text.Length == 0 ? null : TxtContenido.Text;
                objeto.PresentacionId = TxtPresentacion.Text.Trim().Length == 0 ? null : TxtPresentacion.Text.Trim();
                objeto.UnidadMedidaId = TxtUnidadMedida.Text.Trim().Length == 0 ? null : TxtUnidadMedida.Text.Trim();
                objeto.Unidades = TxtUnidades.Text.Trim().Length == 0 ? null : TxtUnidades.Text.Trim();
                objeto.LaboratorioId = TxtLaboratorio.Text.Trim().Length == 0 ? null : TxtLaboratorio.Text.Trim();
                objeto.CategoriaId = TxtCategoria.Text.Trim().Length == 0 ? null : TxtCategoria.Text.Trim();
                objeto.UnidadCfdi = TxtUnidadCFDI.Text.Trim().Length == 0 ? null : TxtUnidadCFDI.Text.Trim();
                objeto.ClaveCfdiId = TxtClaveCFDI.Text.Trim().Length == 0 ? null : TxtClaveCFDI.Text.Trim();


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

                objeto.PrecioCompra = nCosto;
                objeto.PrecioCaja = nPrecioCaja;
                objeto.IsDeleted = !ChkEnCatalogo.Checked;
                objeto.TieneLote = ChkLote.Checked;


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

                objeto.Precio1 = nprecio1;
                objeto.Precio2 = nprecio2;
                objeto.Precio3 = nprecio3;
                objeto.Precio4 = nprecio4;

                objeto.Utilidad1 = nMargen1;
                objeto.Utilidad2 = nMargen2;
                objeto.Utilidad3 = nMargen3;
                objeto.Utilidad4 = nMargen4;


                //Limiar la coleeccion de impuetos y agregar los nuevos
                objeto.ProductoImpuesto.Clear();
                for (int i = 0; i < GridImpuestos.RowCount; i++)
                {
                    objeto.ProductoImpuesto.Add(
                        new ProductoImpuesto()
                        {
                            ProductoId = objeto.ProductoId,
                            ImpuestoId = GridImpuestos.Rows[i].Cells[1].Value.ToString().Trim()

                        });
                }


                //Limiar la coleccion de sustancias y agregar los nuevos
                objeto.ProductoSustancia.Clear();
                for (int i = 0; i < GridSustancias.RowCount; i++)
                {
                    objeto.ProductoSustancia.Add(
                        new ProductoSustancia()
                        {
                            ProductoId = objeto.ProductoId,
                            SustanciaId = GridSustancias.Rows[i].Cells[0].Value.ToString().Trim(),
                            Contenido = GridSustancias.Rows[i].Cells[1].Value.ToString().Trim()
                        });
                }

                objeto.RutaImg = TxtRutaImg.Text.Trim().Length == 0 ? null : TxtRutaImg.Text.Trim();

                if (productoController.Update(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                objeto = null;
            }
        }
        private void LlenaGridImpuestos(ICollection<ProductoImpuesto> productoImpuestos)
        {

            GridImpuestos.Rows.Clear();
            GridImpuestos.Refresh();
            foreach (var productoImpuesto in productoImpuestos)
            {
                GridImpuestos.Rows.Add();
                GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[0].Value = productoImpuesto.ProductoId;
                GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[1].Value = productoImpuesto.ImpuestoId;
            }


        }
        private bool ExisteImpuesto(string impuestoId)
        {
            for (int i = 0; i < GridImpuestos.RowCount; i++)
            {
                if (GridImpuestos.Rows[i].Cells[1].Value.ToString().Trim().Equals(impuestoId))
                    return true;
            }
            return false;
        }
        private void AgregaImpuesto(string impuestoId)
        {
            if (!ExisteImpuesto(impuestoId))
            {
                if (TxtProductoId.Text.Trim().Length > 0)
                {
                    GridImpuestos.Rows.Add();
                    GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[0].Value = TxtProductoId.Text;
                    GridImpuestos.Rows[GridImpuestos.RowCount - 1].Cells[1].Value = impuestoId;

                }
            }
        }

        private bool ExisteSustancia(string sustanciaId)
        {
            for (int i = 0; i < GridSustancias.RowCount; i++)
            {
                if (GridSustancias.Rows[i].Cells[0].Value.ToString().Trim().Equals(sustanciaId))
                    return true;
            }

            return false;
        }
        private void AgregaSustancia(string sustanciaId, string contenido)
        {
            if (!ExisteSustancia(sustanciaId))
            {
                if (TxtProductoId.Text.Trim().Length > 0)
                {
                    GridSustancias.Rows.Add();
                    GridSustancias.Rows[GridSustancias.RowCount - 1].Cells[0].Value = sustanciaId;
                    GridSustancias.Rows[GridSustancias.RowCount - 1].Cells[1].Value = contenido;

                }
            }
        }

        private void LlenaGridSustancias(ICollection<ProductoSustancia> productoSustancias)
        {
            GridSustancias.Rows.Clear();
            GridSustancias.Refresh();
            foreach (var productoSustancia in productoSustancias)
            {
                GridSustancias.Rows.Add();
                GridSustancias.Rows[GridSustancias.RowCount - 1].Cells[0].Value = productoSustancia.SustanciaId;
                GridSustancias.Rows[GridSustancias.RowCount - 1].Cells[1].Value = productoSustancia.Contenido;

            }


        }
        private void LlenaGridProductos(ICollection<Producto> productos)
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

            GridProductos.Focus();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LlenaCampos()
        {
            if (objeto == null)
                ModoCreate = true;
            else
            {
                ModoCreate = false;
                TxtProductoId.Text = objeto.ProductoId;
                TxtDescripcion.Text = objeto.Descripcion;
                TxtContenido.Text = objeto.Contenido;
                TxtPresentacion.Text = objeto.PresentacionId;
                TxtUnidadMedida.Text = objeto.UnidadMedidaId;
                TxtUnidades.Text = objeto.Unidades;
                TxtLaboratorio.Text = objeto.LaboratorioId;
                TxtCategoria.Text = objeto.CategoriaId;
                TxtUnidadCFDI.Text = objeto.UnidadCfdi;
                TxtClaveCFDI.Text = objeto.ClaveCfdiId;
                TxtPrecioCompra.Text = objeto.PrecioCompra.ToString();
                TxtPrecioCaja.Text = objeto.PrecioCaja.ToString();
                ChkEnCatalogo.Checked = !objeto.IsDeleted;
                ChkLote.Checked = objeto.TieneLote;
                LlenaGridImpuestos(objeto.ProductoImpuesto);
                LlenaGridSustancias(objeto.ProductoSustancia);



                TxtPrecio1.Text = objeto.Precio1.ToString();
                TxtPrecio2.Text = objeto.Precio2.ToString();
                TxtPrecio3.Text = objeto.Precio3.ToString();
                TxtPrecio4.Text = objeto.Precio4.ToString();
                TxtU1.Text = objeto.Utilidad1.ToString();
                TxtU2.Text = objeto.Utilidad2.ToString();
                TxtU3.Text = objeto.Utilidad3.ToString();
                TxtU4.Text = objeto.Utilidad4.ToString();
                TxtPrecioS1.Text = Ambiente.GetPrecioSstring(objeto.Precio1.ToString(), objeto.ProductoImpuesto);
                TxtPrecioS2.Text = Ambiente.GetPrecioSstring(objeto.Precio2.ToString(), objeto.ProductoImpuesto);
                TxtPrecioS3.Text = Ambiente.GetPrecioSstring(objeto.Precio3.ToString(), objeto.ProductoImpuesto);
                TxtPrecioS4.Text = Ambiente.GetPrecioSstring(objeto.Precio4.ToString(), objeto.ProductoImpuesto);
                TxtRutaImg.Text = objeto.RutaImg;
                //GridExistencias.DataSource = objeto.ProductoAlmacen.Select(x => new { x.Almacen, x.Existencia }).ToList();
                PbxImagen.Image = GetImg(objeto.RutaImg);
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
            catch (Exception ex)
            {
                return null;
            }
        }
        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                #region Operaciones desde el modulo de logistica 

                var SearchText = TxtProductoId.Text.Trim();
                if (productoController.SelectOne(SearchText) != null)
                {
                    //Encontrado por clave
                    GridProductos.Rows.Clear();
                    LlenaGridProductos(productoController.SelectOneOverList(SearchText));
                    Text = "MODO VER / ACTUALIZAR";
                }
                else
                {
                    if (SearchText.Length == 0)
                    {
                        Text = "MODO VER / ACTUALIZAR";
                        GridProductos.Rows.Clear();
                        LlenaGridProductos(productoController.SelectMany(100));
                    }
                    else
                    {
                        if (productoController.FiltrarVsDescrip(SearchText).Count > 0)
                        {
                            //Filtro por descripcion
                            Text = "MODO VER / ACTUALIZAR";
                            GridProductos.Rows.Clear();
                            LlenaGridProductos(productoController.FiltrarVsDescrip(SearchText));
                        }
                        else
                        {
                            Text = "MODO CREAR PRODUCTO";
                            GridProductos.Rows.Clear();
                            TxtDescripcion.Focus();

                        }

                    }


                }



                #endregion

                GridProductos.Focus();
            }
        }

        private void GridProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (GridProductos.Rows[GridProductos.CurrentCell.RowIndex].Cells[0].Value != null)
            {
                var productoId = GridProductos.Rows[GridProductos.CurrentCell.RowIndex].Cells[0].Value.ToString();
                objeto = productoController.SelectOne(productoId);
                LlenaCampos();
            }
        }

        private void TxtPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtPresentacion.Text.Trim(), (int)Ambiente.TipoBusqueda.Presentaciones))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtPresentacion.Text = form.Presentacion.PresentacionId;
                    }
                }
            }
        }

        private void TxtUnidadMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtUnidadMedida.Text.Trim(), (int)Ambiente.TipoBusqueda.UnidadesMedida))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtUnidadMedida.Text = form.UnidadMedida.UnidadMedidaId;
                        TxtUnidadCFDI.Text = form.UnidadMedida.UnidadSat;
                    }
                }
            }
        }

        private void TxtLaboratorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtLaboratorio.Text.Trim(), (int)Ambiente.TipoBusqueda.Laboratorios))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtLaboratorio.Text = form.Laboratorio.LaboratorioId;
                    }
                }
            }
        }

        private void TxtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtCategoria.Text.Trim(), (int)Ambiente.TipoBusqueda.Categorias))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtCategoria.Text = form.Categoria.CategoriaId;
                    }
                }
            }
        }

        private void TxtClaveCFDI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtClaveCFDI.Text.Trim(), (int)Ambiente.TipoBusqueda.ClavesSat))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        TxtClaveCFDI.Text = form.ClaveSat.ClaveSatId;
                    }
                }
            }
        }

        private void TxtBuscarImpuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtBuscarImpuestos.Text.Trim(), (int)Ambiente.TipoBusqueda.Impuestos))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        AgregaImpuesto(form.Impuesto.ImpuestoId);
                    }
                }
            }
        }

        private void TxtBuscarSustancias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtBuscarSustancias.Text.Trim(), (int)Ambiente.TipoBusqueda.Sustancias))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string s = "";
                        Ambiente.InputBox("SOLICITUD DE CONTENIDO", "DAME GRAMAJE PARA:" + form.Sustancia.SustanciaId, ref s);
                        AgregaSustancia(form.Sustancia.SustanciaId, s);
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

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            var imgdata = Ambiente.GetRuta();


            EstableceImgen(imgdata);

        }

        private void TxtRutaImg_TextChanged(object sender, EventArgs e)
        {

            EstableceImgen(Ambiente.GetRuta());
        }

        private bool EstableceImgen(Tuple<string, string> imgdata)
        {
            try
            {
                if (imgdata == null)
                    return false;

                var name = imgdata.Item2;
                var origen = imgdata.Item1;
                var destino = Path.Combine(Ambiente.RutaImgs, name);

                if (!File.Exists(destino))
                    File.Copy(origen, destino);

                Image img = Image.FromFile(destino);
                PbxImagen.Image = img;
                TxtRutaImg.Text = destino;
                return true;
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.ToString());
                return false;
            }
        }
    }
}
