using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Catalogos;
using PointOfSale.Views.Modulos.Importaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Controllers
{
    public class BMController
    {
        ImportaExcelController ImportaExcelController;

        #region Llena Nodos
        private void LlenaNodoClientes(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Cliente.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.ClienteId,
                    x.Nombre
                }).ToList();
            }

            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoProveedores(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Proveedor.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.ProveedorId,
                    x.RazonSocial
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoProductos(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Producto.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.ProductoId,
                    x.Stock,
                    x.Descripcion
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoCategorias(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {

                Grid1.DataSource = db.Categoria.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.CategoriaId,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoLaboratorios(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Laboratorio.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.LaboratorioId,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoImpuestos(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Impuesto.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.ImpuestoId,
                    x.Tasa
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoNodoSustancias(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Sustancia.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.SustanciaId,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoNodoAlmacenes(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Almacen.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.AlmacenId,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoEstaciones(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Estacion.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.EstacionId,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoClavesat(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.ClaveSat.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.ClaveSatId,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoPresentaciones(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Presentacion.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.PresentacionId,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoUnidadMedida(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.UnidadMedida.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.UnidadMedidaId,
                    x.UnidadSat,
                    x.Nombre
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }

        private void LlenaNodoUsuarios(DataGridView Grid1)
        {
            using (var db = new DymContext())
            {
                Grid1.DataSource = db.Usuario.Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.UsuarioId,
                    x.Nombre,
                    x.Area
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }
        #endregion



        #region Switch Nodos

        public void LlenaNodo(string NodoName, DataGridView Grid1)
        {
            if (NodoName.Length == 0)
                return;

            switch (NodoName)
            {
                case "NodoClientes":
                    LlenaNodoClientes(Grid1);
                    break;
                case "NodoProveedores":
                    LlenaNodoProveedores(Grid1);

                    break;


                case "NodoProductos":
                    LlenaNodoProductos(Grid1);
                    break;


                case "NodoCategorias":
                    LlenaNodoCategorias(Grid1);
                    break;


                case "NodoLaboratorios":
                    LlenaNodoLaboratorios(Grid1);
                    break;


                case "NodoImpuestos":
                    LlenaNodoImpuestos(Grid1);

                    break;

                case "NodoSustancias":
                    LlenaNodoNodoSustancias(Grid1);

                    break;


                case "NodoAlmacenes":
                    LlenaNodoNodoAlmacenes(Grid1);

                    break;

                case "NodoEstaciones":
                    LlenaNodoEstaciones(Grid1);

                    break;


                case "NodoClavesSat":
                    LlenaNodoClavesat(Grid1);


                    break;

                case "NodoPresentaciones":
                    LlenaNodoPresentaciones(Grid1);

                    break;

                case "NodoUnidadesMedida":

                    LlenaNodoUnidadMedida(Grid1);

                    break;
                case "NodoUsuarios":

                    LlenaNodoUsuarios(Grid1);

                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Switch Importaciones

        public void Importa(string NodoName, DataGridView Grid1)
        {
            switch (NodoName)
            {
                case "NodoClientes":

                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Clientes);
                    LlenaNodoClientes(Grid1);

                    break;
                case "NodoProveedores":

                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Proveedores);
                    LlenaNodoProveedores(Grid1);
                    break;


                case "NodoProductos":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Productos);
                    LlenaNodoProductos(Grid1);
                    break;


                case "NodoCategorias":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Categorias);
                    LlenaNodoCategorias(Grid1);
                    break;


                case "NodoLaboratorios":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Laboratorios);
                    LlenaNodoLaboratorios(Grid1);
                    break;


                case "NodoImpuestos":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Impuestos);
                    LlenaNodoImpuestos(Grid1);

                    break;

                case "NodoSustancias":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Sustancias);
                    LlenaNodoNodoSustancias(Grid1);

                    break;


                case "NodoAlmacenes":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Almacenes);
                    LlenaNodoNodoAlmacenes(Grid1);

                    break;

                case "NodoEstaciones":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Estaciones);
                    LlenaNodoEstaciones(Grid1);

                    break;


                case "NodoClavesSat":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.ClavesSat);
                    LlenaNodoClavesat(Grid1);


                    break;

                case "NodoPresentaciones":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Presentaciones);
                    LlenaNodoPresentaciones(Grid1);

                    break;

                case "NodoUnidadesMedida":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.UnidadesMedida);
                    LlenaNodoUnidadMedida(Grid1);

                    break;
                case "NodoUsuarios":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.Usuarios);
                    LlenaNodoUsuarios(Grid1);

                    break;
                case "NodoProdSus":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.ProductoSustancia);


                    break;
                case "NodoProdImp":
                    ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.ProductoImpuesto);

                    break;
                case "NodoProductosCompleto":
                    if (Ambiente.Pregunta("Esto puede tardar varios munitos\n Quiere continuar"))
                    {
                        //ImportaExcelController = new ImportaExcelController((int)Ambiente.TipoBusqueda.ProductosCompleto);
                        var form = new FrmImportaProds();
                        form.Show();
                    }
                    else
                        return;
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region SelectionChaged Grid
        public dynamic GetSelectedObject(string NodoName, DataGridView Grid1)
        {

            switch (NodoName)
            {
                case "NodoClientes":

                    using (var db = new DymContext())
                    {
                        return db.Cliente.FirstOrDefault(x => x.ClienteId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }
                case "NodoProveedores":

                    using (var db = new DymContext())
                    {
                        return db.Proveedor.FirstOrDefault(x => x.ProveedorId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }


                case "NodoProductos":

                    using (var db = new DymContext())
                    {
                        return db.Producto.FirstOrDefault(x => x.ProductoId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }


                case "NodoCategorias":

                    using (var db = new DymContext())
                    {
                        return db.Categoria.FirstOrDefault(x => x.CategoriaId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }


                case "NodoLaboratorios":

                    using (var db = new DymContext())
                    {
                        return db.Laboratorio.FirstOrDefault(x => x.LaboratorioId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }


                case "NodoImpuestos":


                    using (var db = new DymContext())
                    {
                        return db.Impuesto.FirstOrDefault(x => x.ImpuestoId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }

                case "NodoSustancias":


                    using (var db = new DymContext())
                    {
                        return db.Sustancia.FirstOrDefault(x => x.SustanciaId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }


                case "NodoAlmacenes":


                    using (var db = new DymContext())
                    {
                        return db.Almacen.FirstOrDefault(x => x.AlmacenId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }

                case "NodoEstaciones":

                    using (var db = new DymContext())
                    {
                        return db.Estacion.FirstOrDefault(x => x.EstacionId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }


                case "NodoClavesSat":
                    using (var db = new DymContext())
                    {
                        return db.ClaveSat.FirstOrDefault(x => x.ClaveSatId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }

                case "NodoPresentaciones":

                    using (var db = new DymContext())
                    {
                        return db.Presentacion.FirstOrDefault(x => x.PresentacionId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }

                case "NodoUnidadesMedida":
                    using (var db = new DymContext())
                    {
                        return db.UnidadMedida.FirstOrDefault(x => x.UnidadMedidaId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }

                case "NodoUsuarios":

                    using (var db = new DymContext())
                    {
                        return db.Usuario.FirstOrDefault(x => x.UsuarioId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }

                default:
                    return null;
            }
        }
        #endregion

        #region SwitchUpdate
        public void LanzaFormaUpdate(string NodoName, dynamic objeto, dynamic Mdi)
        {
            dynamic form;
            switch (NodoName)
            {
                case "NodoClientes":

                    form = new FrmClientes(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoProveedores":

                    form = new FrmProveedores(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoProductos":

                    form = new FrmProductos(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoCategorias":

                    form = new FrmCategorias(objeto);

                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoLaboratorios":

                    form = new FrmLaboratorios(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoImpuestos":

                    form = new FrmImpuestos(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoSustancias":

                    form = new FrmSustancias(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoAlmacenes":

                    form = new FrmAlmacenes(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoEstaciones":

                    form = new FrmEstaciones(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoClavesSat":

                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
                    break;

                case "NodoPresentaciones":

                    form = new FrmPresentaciones(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoUnidadesMedida":

                    form = new FrmUnidadMedida(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoUsuarios":

                    form = new FrmUsuarios(objeto);
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                default:
                    Ambiente.Mensaje("No se encontró Forma Update");
                    return;
            }
        }
        #endregion

        #region SwitchInsert
        public void LanzaFormaInsert(string NodoName, dynamic Mdi)
        {

            dynamic form;

            switch (NodoName)
            {
                case "NodoClientes":

                    form = new FrmClientes();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoProveedores":

                    form = new FrmProveedores();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoProductos":

                    form = new FrmProductos();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoCategorias":

                    form = new FrmCategorias();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoLaboratorios":

                    form = new FrmLaboratorios();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoImpuestos":

                    form = new FrmImpuestos();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoSustancias":

                    form = new FrmSustancias();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoAlmacenes":

                    form = new FrmAlmacenes();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoEstaciones":

                    form = new FrmEstaciones();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoClavesSat":

                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
                    break;

                case "NodoPresentaciones":

                    form = new FrmPresentaciones();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoUnidadesMedida":

                    form = new FrmUnidadMedida();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                case "NodoUsuarios":

                    form = new FrmUsuarios();
                    form.MdiParent = Mdi.MdiParent;
                    form.Show();
                    break;

                default:
                    Ambiente.Mensaje("No se encontró Forma Update");
                    return;
            }
        }
        #endregion

        #region SwitchDelete
        public void LanzaFormaDelete(string NodoName, dynamic objeto, dynamic Mdi)
        {
            if (objeto == null)
                return;

            switch (NodoName)
            {
                case "NodoClientes":
                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new ClienteController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);

                    break;

                case "NodoProveedores":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new ProveedorController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoProductos":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Descripcion))
                    {
                        if (new ProductoController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoCategorias":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new CategoriaController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);

                    break;

                case "NodoLaboratorios":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new LaboratorioController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoImpuestos":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.ImpuestoId))
                    {
                        if (new ImpuestoController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoSustancias":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new SustanciaController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoAlmacenes":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new AlmacenController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoEstaciones":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new EstacionController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoClavesSat":

                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
                    break;

                case "NodoPresentaciones":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new PresentacionController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoUnidadesMedida":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new UnidadMedidaController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                case "NodoUsuarios":

                    if (Ambiente.Pregunta("QUIERE BORRAR: " + objeto.Nombre))
                    {
                        if (new UsuarioController().Delete(objeto))
                            MessageBox.Show(Ambiente.CatalgoMensajes[2]);
                    }
                    else
                        MessageBox.Show(Ambiente.CatalgoMensajes[-2]);
                    break;

                default:
                    Ambiente.Mensaje("No se encontró Forma Update");
                    return;
            }
        }
        #endregion
    }
}