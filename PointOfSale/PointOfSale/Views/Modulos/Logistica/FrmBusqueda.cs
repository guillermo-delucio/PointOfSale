using Microsoft.EntityFrameworkCore;
using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DYM.Views
{
    public partial class FrmBusqueda : Form
    {

        private string SearchText;
        private int Catalogo;

        public Cliente Cliente;
        public Proveedor Proveedor;
        public Producto Producto;
        public Categoria Categoria;
        public Laboratorio Laboratorio;
        public Impuesto Impuesto;
        public Sustancia Sustancia;
        public Almacen Almacen;
        public Estacion Estacion;
        public ClaveSat ClaveSat;
        public Presentacion Presentacion;
        public UnidadMedida UnidadMedida;
        public Usuario Usuario;


        public FrmBusqueda()
        {
            InitializeComponent();
        }
        public FrmBusqueda(string searchText, int tipoBuscqueda)
        {

            InitializeComponent();
            SearchText = searchText;
            Catalogo = tipoBuscqueda;
        }

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            CargaGrid();
        }

        private void CargaGrid()
        {
            switch (Catalogo)
            {
                case (int)Ambiente.TipoBusqueda.Clientes:

                    using (var db = new DymContext())
                    {
                        Grid1.DataSource = db.Cliente.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.ClienteId, x.Nombre }).ToList();
                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }


                    break;

                case (int)Ambiente.TipoBusqueda.Proveedores:
                    using (var db = new DymContext())
                    {
                        db.Proveedor.AsNoTracking().Where(x => x.RazonSocial.Contains(SearchText)).OrderBy(x => x.RazonSocial).
                            Select(x => new { x.ProveedorId, x.RazonSocial }).ToList();
                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Productos:

                    using (var db = new DymContext())
                    {
                        db.Producto.AsNoTracking().Where(
                       x => x.Descripcion.Contains(SearchText)).Select(x => new
                       {
                           x.ProductoId,
                           x.Descripcion
                       }).OrderBy(x => x.Descripcion).ToList();
                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Categorias:
                    using (var db = new DymContext())
                    {
                        db.Categoria.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.CategoriaId, x.Nombre }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Laboratorios:
                    using (var db = new DymContext())
                    {
                        db.Laboratorio.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.LaboratorioId, x.Nombre }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Impuestos:
                    using (var db = new DymContext())
                    {
                        db.Impuesto.AsNoTracking().Where(x => x.ImpuestoId.Contains(SearchText)).OrderBy(x => x.ImpuestoId).
                            Select(x => new { x.ImpuestoId, x.Tasa }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }

                    break;

                case (int)Ambiente.TipoBusqueda.Sustancias:
                    using (var db = new DymContext())
                    {
                        db.Sustancia.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).
                            Select(x => new { x.SustanciaId, x.Nombre }).OrderBy(x => x.Nombre).ToList();
                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }

                    break;

                case (int)Ambiente.TipoBusqueda.Almacenes:
                    using (var db = new DymContext())
                    {
                        db.Almacen.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.AlmacenId, x.Nombre }).ToList();
                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Estaciones:
                    using (var db = new DymContext())
                    {
                        db.Estacion.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.EstacionId, x.Nombre }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.ClavesSat:
                    using (var db = new DymContext())
                    {
                        db.ClaveSat.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                        Select(x => new { x.ClaveSatId, x.Nombre }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Presentaciones:

                    using (var db = new DymContext())
                    {
                        db.Presentacion.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.PresentacionId, x.Nombre }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.UnidadesMedida:
                    using (var db = new DymContext())
                    {
                        db.UnidadMedida.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.UnidadMedidaId, x.Nombre }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;

                case (int)Ambiente.TipoBusqueda.Usuarios:
                    using (var db = new DymContext())
                    {
                        db.Usuario.AsNoTracking().Where(x => x.Nombre.Contains(SearchText)).OrderBy(x => x.Nombre).
                            Select(x => new { x.UsuarioId, x.Nombre }).ToList();

                        Ambiente.AdditionalSettingsDataGridView(Grid1);
                    }
                    break;
                default:
                    MessageBox.Show("Error, no hay enumerador para catalogo");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grid1.Rows.Count <= 0)
            {
                DialogResult = DialogResult.Abort;
                Dispose();
                return;
            }


            CargaGrid();
            DialogResult = DialogResult.OK;
            this.Dispose();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Dispose();
        }



        private void Grid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Grid1.Rows.Count <= 0)
                {
                    DialogResult = DialogResult.Abort;
                    Dispose();
                    return;
                }


                switch (Catalogo)
                {
                    case (int)Ambiente.TipoBusqueda.Clientes:

                        using (var db = new DymContext())
                        {
                            Cliente = db.Cliente.AsNoTracking().Where(x => x.ClienteId ==
                            Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }

                        break;

                    case (int)Ambiente.TipoBusqueda.Proveedores:
                        using (var db = new DymContext())
                        {
                            Proveedor = db.Proveedor.AsNoTracking().Where(x => x.ProveedorId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.Productos:
                        using (var db = new DymContext())
                        {
                            Producto = db.Producto.AsNoTracking().Where(x => x.ProductoId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.Categorias:
                        using (var db = new DymContext())
                        {
                            Categoria = db.Categoria.AsNoTracking().Where(x => x.CategoriaId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.Laboratorios:
                        using (var db = new DymContext())
                        {
                            Laboratorio = db.Laboratorio.AsNoTracking().Where(x => x.LaboratorioId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.Impuestos:
                        using (var db = new DymContext())
                        {
                            Impuesto = db.Impuesto.AsNoTracking().Where(x => x.ImpuestoId ==
                         Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.Sustancias:
                        using (var db = new DymContext())
                        {
                            Sustancia = db.Sustancia.AsNoTracking().Where(x => x.SustanciaId ==
                          Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }

                        break;

                    case (int)Ambiente.TipoBusqueda.Almacenes:
                        using (var db = new DymContext())
                        {
                            Almacen = db.Almacen.AsNoTracking().Where(x => x.AlmacenId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.Estaciones:
                        using (var db = new DymContext())
                        {
                            Estacion = db.Estacion.AsNoTracking().Where(x => x.EstacionId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.ClavesSat:
                        using (var db = new DymContext())
                        {
                            ClaveSat = db.ClaveSat.AsNoTracking().Where(x => x.ClaveSatId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.Presentaciones:

                        using (var db = new DymContext())
                        {
                            Presentacion = db.Presentacion.AsNoTracking().Where(x => x.PresentacionId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;

                    case (int)Ambiente.TipoBusqueda.UnidadesMedida:
                        using (var db = new DymContext())
                        {
                            UnidadMedida = db.UnidadMedida.AsNoTracking().Where(x => x.UnidadMedidaId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;
                    case (int)Ambiente.TipoBusqueda.Usuarios:
                        using (var db = new DymContext())
                        {
                            Usuario = db.Usuario.AsNoTracking().Where(x => x.UsuarioId ==
                        Grid1.Rows[Grid1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()).FirstOrDefault();
                        }
                        break;
                    default:
                        MessageBox.Show("Error, no hay enumerador para catalogo");
                        break;
                }

                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Abort;
                this.Dispose();
            }
        }

        private void Grid1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
