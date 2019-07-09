using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmProductos : Form
    {
        private dynamic objeto;
        private List<Impuesto> Impuestos;
        private ProductoController productoController;
        bool ModoCreate;
        bool ModoUpdate;

        public FrmProductos()
        {
            InitializeComponent();
            productoController = new ProductoController();
            Impuestos = new List<Impuesto>();
            ModoCreate = true;
            ModoUpdate = false;
        }

        public FrmProductos(dynamic objeto)
        {
            InitializeComponent();
            productoController = new ProductoController();
            Impuestos = new List<Impuesto>();
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
                objeto.Descripcion = TxtDescripcion.Text.Length == 0 ? "SYS" : TxtDescripcion.Text;
                objeto.Contenido = TxtContenido.Text.Length == 0 ? null : TxtContenido.Text;
                objeto.PresentacionId = TxtPresentacion.Text.Trim().Length == 0 ? "SYS" : TxtPresentacion.Text.Trim();
                objeto.UnidadMedidaId = TxtUnidadMedida.Text.Trim().Length == 0 ? "SYS" : TxtUnidadMedida.Text.Trim();
                objeto.Unidades = TxtUnidades.Text.Trim().Length == 0 ? null : TxtUnidades.Text.Trim();
                objeto.LaboratorioId = TxtLaboratorio.Text.Trim().Length == 0 ? "SYS" : TxtLaboratorio.Text.Trim();
                objeto.CategoriaId = TxtCategoria.Text.Trim().Length == 0 ? "SYS" : TxtCategoria.Text.Trim();
                objeto.ClaveUnidadId = TxtUnidadCFDI.Text.Trim().Length == 0 ? "H87" : TxtUnidadCFDI.Text.Trim();
                objeto.ClaveProdServId = TxtClaveCFDI.Text.Trim().Length == 0 ? "01010101" : TxtClaveCFDI.Text.Trim();


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

                //Reset Impuestos
                objeto.Impuesto1Id = "SYS";
                objeto.Impuesto2Id = "SYS";
                objeto.Impuesto3Id = "SYS";
                for (int i = 0; i < Impuestos.Count; i++)
                {
                    if (i == 0)
                        objeto.Impuesto1Id = Impuestos[i].ImpuestoId;

                    if (i == 1)
                        objeto.Impuesto2Id = Impuestos[i].ImpuestoId;

                    if (i == 2)
                        objeto.Impuesto3Id = Impuestos[i].ImpuestoId;
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
                if (objeto == null)
                    objeto = productoController.SelectOne(TxtProductoId.Text);

                if (objeto == null)
                {
                    if (TxtProductoId.Text.Trim().Length == 0)
                        return;

                    objeto = new Producto();
                    objeto.ProductoId = TxtProductoId.Text.Trim();
                }


                objeto.Descripcion = TxtDescripcion.Text.Length == 0 ? "SYS" : TxtDescripcion.Text;
                objeto.Contenido = TxtContenido.Text.Length == 0 ? null : TxtContenido.Text;
                objeto.PresentacionId = TxtPresentacion.Text.Trim().Length == 0 ? "SYS" : TxtPresentacion.Text.Trim();
                objeto.UnidadMedidaId = TxtUnidadMedida.Text.Trim().Length == 0 ? "SYS" : TxtUnidadMedida.Text.Trim();
                objeto.Unidades = TxtUnidades.Text.Trim().Length == 0 ? null : TxtUnidades.Text.Trim();
                objeto.LaboratorioId = TxtLaboratorio.Text.Trim().Length == 0 ? "SYS" : TxtLaboratorio.Text.Trim();
                objeto.CategoriaId = TxtCategoria.Text.Trim().Length == 0 ? "SYS" : TxtCategoria.Text.Trim();
                objeto.ClaveUnidadId = TxtUnidadCFDI.Text.Trim().Length == 0 ? "H87" : TxtUnidadCFDI.Text.Trim();
                objeto.ClaveProdServId = TxtClaveCFDI.Text.Trim().Length == 0 ? "01010101" : TxtClaveCFDI.Text.Trim();

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


                //Reset Impuestos
                objeto.Impuesto1Id = "SYS";
                objeto.Impuesto2Id = "SYS";
                objeto.Impuesto3Id = "SYS";
                for (int i = 0; i < Impuestos.Count; i++)
                {
                    if (i == 0)
                        objeto.Impuesto1Id = Impuestos[i].ImpuestoId;

                    if (i == 1)
                        objeto.Impuesto2Id = Impuestos[i].ImpuestoId;

                    if (i == 2)
                        objeto.Impuesto3Id = Impuestos[i].ImpuestoId;
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





        private bool ExisteImpuesto(Impuesto impuesto)
        {
            foreach (var i in Impuestos)
            {
                if (i.ImpuestoId.Equals(impuesto.ImpuestoId))
                    return true;
            }
            return false;
        }
        private void AgregaImpuesto(Impuesto impuesto)
        {
            if (!ExisteImpuesto(impuesto) && Impuestos.Count < 3)
            {
                if (TxtProductoId.Text.Trim().Length > 0)
                {
                    Impuestos.Add(impuesto);
                    CargaGridImpuestos();
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
            if (GridProductos.RowCount > 0)
            {
                GridProductos.Rows[0].Selected = true;
                GridProductos.Focus();
            }
            LblCoincidencias.Text = productos.Count + " Coincidencias";

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
                TxtUnidadCFDI.Text = objeto.ClaveUnidadId;
                TxtClaveCFDI.Text = objeto.ClaveProdServId;
                TxtPrecioCompra.Text = objeto.PrecioCompra.ToString();
                TxtPrecioCaja.Text = objeto.PrecioCaja.ToString();
                ChkEnCatalogo.Checked = !objeto.IsDeleted;
                ChkLote.Checked = objeto.TieneLote;
                CargaListaImpuestos(objeto);
                CargaGridImpuestos();
                LlenaGridSustancias(objeto.ProductoSustancia);
                CargaGridExitencia(objeto.Stock);

                TxtPrecio1.Text = objeto.Precio1.ToString();
                TxtPrecio2.Text = objeto.Precio2.ToString();
                TxtPrecio3.Text = objeto.Precio3.ToString();
                TxtPrecio4.Text = objeto.Precio4.ToString();
                TxtU1.Text = objeto.Utilidad1.ToString();
                TxtU2.Text = objeto.Utilidad2.ToString();
                TxtU3.Text = objeto.Utilidad3.ToString();
                TxtU4.Text = objeto.Utilidad4.ToString();
                //TxtPrecioS1.Text = Ambiente.GetPrecioSalida(objeto.Precio1.ToString(), objeto.ProductoImpuesto);
                //TxtPrecioS2.Text = Ambiente.GetPrecioSalida(objeto.Precio2.ToString(), objeto.ProductoImpuesto);
                //TxtPrecioS3.Text = Ambiente.GetPrecioSalida(objeto.Precio3.ToString(), objeto.ProductoImpuesto);
                //TxtPrecioS4.Text = Ambiente.GetPrecioSalida(objeto.Precio4.ToString(), objeto.ProductoImpuesto);
                TxtRutaImg.Text = objeto.RutaImg;
                //GridExistencias.DataSource = objeto.ProductoAlmacen.Select(x => new { x.AlmacenId, x.ExistenciaId }).ToList();
                PbxImagen.Image = GetImg(objeto.RutaImg);
            }
        }

        private void CargaGridExitencia(decimal stock)
        {
            GridExistencias.Rows.Clear();
            GridExistencias.Refresh();
            GridExistencias.Rows.Add();
            GridExistencias.Rows[GridExistencias.RowCount - 1].Cells[0].Value = "ALMACEN1";
            GridExistencias.Rows[GridExistencias.RowCount - 1].Cells[1].Value = stock;
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
        private void TxtProductoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var SearchText = TxtProductoId.Text.Trim();

                #region Operaciones desde el modulo de logistica 
                if (ChkFiltroSustancia.Checked)
                {
                    //Encontrado por clave
                    GridProductos.Rows.Clear();
                    LlenaGridProductos(productoController.FiltrarVsSustancia(SearchText));
                    Text = "MODO VER / ACTUALIZAR";
                }
                else
                {
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
                                LblCoincidencias.Text = "0 Coincidencias";
                                GridProductos.Rows.Clear();
                                LimpiaCampos();

                                TxtDescripcion.Focus();
                                TxtProductoId.Text = SearchText;

                            }

                        }


                    }
                }



                #endregion

            }
        }
        private void LimpiaCampos()
        {
            TxtDescripcion.Text = string.Empty;
            TxtPresentacion.Text = string.Empty;
            TxtUnidadMedida.Text = string.Empty;
            TxtUnidades.Text = string.Empty;
            TxtLaboratorio.Text = string.Empty;
            TxtCategoria.Text = string.Empty;
            TxtClaveCFDI.Text = string.Empty;
            TxtUnidadCFDI.Text = string.Empty;
            TxtPrecioCompra.Text = string.Empty;
            ChkEnCatalogo.Checked = false;
            ChkLote.Checked = false;
            TxtBuscarImpuestos.Text = string.Empty;
            GridImpuestos.Rows.Clear();
            GridSustancias.Rows.Clear();
            GridExistencias.Rows.Clear();


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
            TxtBuscarSustancias.Text = string.Empty;
            TxtPrecioCaja.Text = string.Empty;
            TxtContenido.Text = string.Empty;
            TxtRutaImg.Text = string.Empty;
            PbxImagen.Image = null;




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
                        TxtClaveCFDI.Text = form.CClaveProdServ.ClaveProdServId;
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
                        AgregaImpuesto(form.Impuesto);
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
            var imgdata = Ambiente.GetFilePath();


            EstableceImgen(imgdata);

        }

        private void TxtRutaImg_TextChanged(object sender, EventArgs e)
        {

            EstableceImgen(Ambiente.GetFilePath());
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

        private void TxtProductoId_TextChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(e.ToString());
        }

        private void ChkLote_Leave(object sender, EventArgs e)
        {
            TxtBuscarImpuestos.Focus();
        }

        private void BtnImagen_Leave(object sender, EventArgs e)
        {
            BtnAceptar.Focus();
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
        }

        private void GridImpuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                BorraImpuestoEnLista(GridImpuestos.Rows[GridImpuestos.CurrentCell.RowIndex].Cells[0].Value.ToString());
                CargaGridImpuestos();
            }
        }

        private void BorraImpuestoEnLista(string impuestoId)
        {
            for (int i = 0; i < Impuestos.Count; i++)
            {
                if (Impuestos[i].ImpuestoId.Equals(impuestoId))
                    Impuestos.RemoveAt(i);
            }
        }

        private void GridSustancias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                BorraFilaDgv(GridSustancias.CurrentCell.RowIndex, GridSustancias);
        }

        private void BorraFilaDgv(int rowIndex, DataGridView gridSustancias)
        {
            if (rowIndex >= 0 && gridSustancias.RowCount > 0)
            {
                gridSustancias.Rows.RemoveAt(rowIndex);
            }
        }

        private void TxtPrecioCompra_Leave(object sender, EventArgs e)
        {
            TxtPrecioCompra.Text = Ambiente.FDinero(TxtPrecioCompra.Text);
        }

        private void TxtPrecioCaja_Leave(object sender, EventArgs e)
        {
            TxtPrecioCaja.Text = Ambiente.FDinero(TxtPrecioCaja.Text);
        }

        private void TxtProductoId_Leave(object sender, EventArgs e)
        {


        }
    }
}
