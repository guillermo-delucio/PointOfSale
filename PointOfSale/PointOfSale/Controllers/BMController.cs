using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
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
                Grid1.DataSource = db.Cliente.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Proveedor.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Producto.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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

                Grid1.DataSource = db.Categoria.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Laboratorio.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Impuesto.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Sustancia.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Almacen.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Estacion.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.ClaveSat.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Presentacion.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.UnidadMedida.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
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
                Grid1.DataSource = db.Usuario.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new
                {
                    x.UsuarioId,
                    x.Nombre,
                    x.Area
                }).ToList();
            }
            Ambiente.AdditionalSettingsDataGridView(Grid1);
        }
        #endregion

        #region Inserciones
        private void InsertaCliente(Cliente cliente)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaProveedor(Proveedor proveedor)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaProducto(Producto producto)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaCategoria(Categoria categoria)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaLaboratorio(Laboratorio laboratorio)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaImpuesto(Impuesto impuesto)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaSustancia(Sustancia sustancia)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaAlmacen(Almacen almacen)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaEstacion(Estacion estacion)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaClaveSat()
        {
            Ambiente.Mensaje("No Implementado :( \n");
        }

        private void InsertaPresentacion(Presentacion presentacion)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaUnidadMedida(UnidadMedida unidadMedida)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void InsertaUsuario(Usuario usuariok)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }
        #endregion

        #region Actualizacione
        private void ActualizaCliente(Cliente cliente)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaProveedor(Proveedor proveedor)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaProducto(Producto producto)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaCategoria(Categoria categoria)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaLaboratorio(Laboratorio laboratorio)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaImpuesto(Impuesto impuesto)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaSustancia(Sustancia sustancia)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaAlmacen(Almacen almacen)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }
        private void ActualizaEstacion(Estacion estacion)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaClaveSat()
        {
            Ambiente.Mensaje("No Implementado :( \n");
        }

        private void ActualizaPresentacion(Presentacion presentacion)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaUnidadMedida(UnidadMedida unidadMedida)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void ActualizaUsuario(Usuario usuariok)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }
        #endregion

        #region Borrados
        private void BorraCliente(Cliente cliente)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraProveedor(Proveedor proveedor)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraProducto(Producto producto)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraCategoria(Categoria categoria)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraLaboratorio(Laboratorio laboratorio)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraImpuesto(Impuesto impuesto)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraSustancia(Sustancia sustancia)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraAlmacen(Almacen almacen)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraEstacion(Estacion estacion)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraClaveSat()
        {
            Ambiente.Mensaje("No Implementado :( \n");
        }

        private void BorraPresentacion(Presentacion presentacion)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraUnidadMedida(UnidadMedida unidadMedida)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }

        private void BorraUsuario(Usuario usuario)
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("Algo salió mal :( \n" + ex.ToString());
            }
        }
        #endregion

        #region Switch Nodos

        public void LlenaNodo(string NodoName, DataGridView Grid1)
        {
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

                default:
                    break;
            }
        }

        #endregion
    }
}