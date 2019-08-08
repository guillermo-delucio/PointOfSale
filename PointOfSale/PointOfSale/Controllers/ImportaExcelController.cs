using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PointOfSale.Controllers.TablasIntermedia;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Controllers
{
    public class ImportaExcelController
    {
        public string Ruta { get; set; }

        private int Catalogo;
        private int Fila;
        private int Columna;
        private string tipo_per;
        private FileInfo fi;
        private List<string> Errores;
        private List<Producto> Productos;
        private List<Cliente> Clientes;
        private List<Proveedor> Proveedores;
        private List<CClaveProdServ> ClavesSat;
        private List<Sustancia> Sustancias;
        private List<Laboratorio> Laboratorios;
        private List<UnidadMedida> UnidadMedidas;
        private List<Presentacion> Presentaciones;
        private List<Categoria> Categorias;
        private List<ProductoSustancia> ProductoSustancias;
        private List<ProductoImpuesto> ProductoImpuestos;





        public ImportaExcelController(int catalogo)
        {
            Fila = 0;
            Columna = 0;
            Catalogo = catalogo;
            Ruta = string.Empty;
            tipo_per = string.Empty;
            Errores = new List<string>();
            ClavesSat = new List<CClaveProdServ>();
            Productos = new List<Producto>();
            Sustancias = new List<Sustancia>();
            Laboratorios = new List<Laboratorio>();
            UnidadMedidas = new List<UnidadMedida>();
            Presentaciones = new List<Presentacion>();
            Categorias = new List<Categoria>();
            Clientes = new List<Cliente>();
            Proveedores = new List<Proveedor>();
            ProductoSustancias = new List<ProductoSustancia>();
            ProductoImpuestos = new List<ProductoImpuesto>();



            GetRuta();
            Importa();
        }

        public void GetRuta()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Excel Files|*.XLSX";
                //openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    Ruta = openFileDialog.FileName.Trim();
                }
            }
        }

        public void Importa()
        {

            switch (Catalogo)
            {
                case (int)Ambiente.TipoBusqueda.Clientes:
                    ImportaClientes();
                    break;

                case (int)Ambiente.TipoBusqueda.Proveedores:
                    ImportaProveedores();
                    break;

                case (int)Ambiente.TipoBusqueda.Productos:
                    ImportaProductos();
                    break;

                case (int)Ambiente.TipoBusqueda.Categorias:
                    ImportaCategorias();
                    break;

                case (int)Ambiente.TipoBusqueda.Laboratorios:
                    ImportaLaboratorios();
                    break;

                case (int)Ambiente.TipoBusqueda.Impuestos:
                    ImportaImpuestos();
                    break;

                case (int)Ambiente.TipoBusqueda.Sustancias:
                    ImportaSustancias();
                    break;

                case (int)Ambiente.TipoBusqueda.Almacenes:
                    ImportaAlmacenes();
                    break;

                case (int)Ambiente.TipoBusqueda.Estaciones:
                    ImportaEstaciones();
                    break;

                case (int)Ambiente.TipoBusqueda.ClavesSat:
                    ImportaClavesSat();
                    break;

                case (int)Ambiente.TipoBusqueda.Presentaciones:
                    ImportaPresentaciones();
                    break;

                case (int)Ambiente.TipoBusqueda.UnidadesMedida:
                    ImportaUnidadMedida();
                    break;

                case (int)Ambiente.TipoBusqueda.Usuarios:
                    ImportaUsuarios();
                    break;
                case (int)Ambiente.TipoBusqueda.ProductoImpuesto:
                    ImportaProductoImpuesto();
                    break;
                case (int)Ambiente.TipoBusqueda.ProductoSustancia:
                    ImportaProductoSustancia();
                    break;
                case (int)Ambiente.TipoBusqueda.ProductosCompleto:
                    ImportaProductosCompleto();
                    break;
                default:
                    MessageBox.Show("Error, no hay importacion para catalogo");
                    break;
            }
        }

        private void ImportaProductoSustancia()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var productoSustancia = new ProductoSustancia();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    productoSustancia.ProductoId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    productoSustancia.SustanciaId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 3:
                                    productoSustancia.Contenido = workSheet.Cells[row, col].Text.Trim();
                                    ProductoSustancias.Add(productoSustancia);

                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var productoSustanciaController = new ProductoSustanciaController();
                    Ambiente.Mensaje(productoSustanciaController.InsertRange(ProductoSustancias));

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaProductoImpuesto()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];
                    ProductoController productoController = new ProductoController();
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        Producto p = null;
                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    p = productoController.SelectOne(workSheet.Cells[row, col].Text.Trim());
                                    break;
                                case 2:
                                    p.Impuesto1Id = workSheet.Cells[row, col].Text.Trim().Length == 0 ? "SYS" : workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 3:
                                    p.Impuesto2Id = workSheet.Cells[row, col].Text.Trim().Length == 0 ? "SYS" : workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 4:
                                    p.Impuesto3Id = workSheet.Cells[row, col].Text.Trim().Length == 0 ? "SYS" : workSheet.Cells[row, col].Text.Trim();

                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }
                        productoController.Update(p);

                    }
                    Ambiente.Mensaje("PROCESO CONCLUIDO");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaUsuarios()
        {
            Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
        }

        private void ImportaUnidadMedida()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var unidadMedida = new UnidadMedida();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    unidadMedida.UnidadMedidaId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    unidadMedida.Nombre = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 3:
                                    unidadMedida.UnidadSat = workSheet.Cells[row, col].Text.Trim();
                                    UnidadMedidas.Add(unidadMedida);
                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var unidadMedidaController = new UnidadMedidaController();

                    if (unidadMedidaController.InsertRange(UnidadMedidas))
                        Ambiente.Mensaje(end.Row + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaPresentaciones()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var presentacion = new Presentacion();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    presentacion.PresentacionId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    presentacion.Nombre = workSheet.Cells[row, col].Text.Trim();
                                    Presentaciones.Add(presentacion);
                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var presentacionController = new PresentacionController();

                    if (presentacionController.InsertRange(Presentaciones))
                        Ambiente.Mensaje(end.Row + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaClavesSat()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var claveSat = new CClaveProdServ();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    claveSat.ClaveProdServId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    claveSat.Nombre = workSheet.Cells[row, col].Text.Trim().ToUpper();
                                    ClavesSat.Add(claveSat);
                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var claveSatController = new ClaveSatController();

                    if (claveSatController.InsertRange(ClavesSat))
                        Ambiente.Mensaje(end.Row + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaEstaciones()
        {
            Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
        }

        private void ImportaAlmacenes()
        {
            Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
        }

        private void ImportaSustancias()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var sustancia = new Sustancia();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    sustancia.SustanciaId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    sustancia.Nombre = workSheet.Cells[row, col].Text.Trim();
                                    Sustancias.Add(sustancia);
                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ, " + sustancia.SustanciaId + ", A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var sustanciaController = new SustanciaController();

                    if (sustanciaController.InsertRange(Sustancias))
                        Ambiente.Mensaje(end.Row + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaImpuestos()
        {
            Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
        }

        private void ImportaLaboratorios()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var laboratorio = new Laboratorio();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    laboratorio.LaboratorioId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    laboratorio.Nombre = workSheet.Cells[row, col].Text.Trim();
                                    Laboratorios.Add(laboratorio);
                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var laboratorioController = new LaboratorioController();

                    if (laboratorioController.InsertRange(Laboratorios))
                        Ambiente.Mensaje(end.Row + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaCategorias()
        {
            Ambiente.Mensaje(Ambiente.CatalgoMensajes[-5]);
        }

        private void ImportaProductos()
        {
            try
            {
                //GetRuta();
                //Opening an existing Excel file
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    //Get a WorkSheet by index. Note that EPPlus indexes are base 1, not base 0!
                    //Get a WorkSheet by name. If the worksheet doesn't exist, throw an exeption

                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    { // Row by row...
                        object cellValue = workSheet.Cells[row, 2].Text; // This got me the actual value I needed.
                        Fila = row;
                        var producto = new Producto();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion, 3Stock
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    producto.ProductoId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    producto.Descripcion = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 3:
                                    bool succes = int.TryParse(workSheet.Cells[row, col].Text.Trim(), out int nStock);
                                    if (succes)
                                    {
                                        producto.CratedAt = DateTime.Now;
                                        producto.UpdatedAt = DateTime.Now;
                                        producto.CratedBy = Ambiente.LoggedUser.UsuarioId;
                                        producto.Stock = nStock;
                                        Productos.Add(producto);
                                    }
                                    else
                                        Errores.Add("SE OMITIÓ, " + producto.ProductoId + ", A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;

                                default:
                                    MessageBox.Show("Columna no encontrada");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    ProductoController productoController = new ProductoController();
                    if (productoController.InsertRange(Productos))
                        Ambiente.Mensaje(end.Row + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }
        private void ImportaProductosCompleto()
        {
            try
            {

                using (var db = new DymContext())
                {
                    ClavesSat = db.CClaveProdServ.AsNoTracking().ToList();
                    Sustancias = db.Sustancia.AsNoTracking().ToList();
                    Laboratorios = db.Laboratorio.AsNoTracking().ToList();
                    UnidadMedidas = db.UnidadMedida.AsNoTracking().ToList();
                    Presentaciones = db.Presentacion.AsNoTracking().ToList();
                    Categorias = db.Categoria.AsNoTracking().ToList();
                }

                //Opening an existing Excel file
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    //Get a WorkSheet by index. Note that EPPlus indexes are base 1, not base 0!
                    //Get a WorkSheet by name. If the worksheet doesn't exist, throw an exeption

                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    bool succes = false;
                    int nIntValue = 0;
                    decimal nDecValue = 1m;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    { // Row by row...
                        object cellValue = workSheet.Cells[row, 2].Text; // This got me the actual value I needed.
                        Fila = row;
                        var producto = new Producto();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            // ... Cell by cell: 1Clave, 2Descripcion, 3Stock
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    //ProductoId
                                    producto.ProductoId = workSheet.Cells[row, col].Text.Trim();
                                    producto.Impuesto1Id = "SYS";
                                    producto.Impuesto2Id = "SYS";
                                    producto.Impuesto3Id = "SYS";
                                    break;
                                case 2:
                                    //Descripcion
                                    producto.Descripcion = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 3:
                                    //Stock
                                    succes = false;
                                    succes = int.TryParse(workSheet.Cells[row, col].Text.Trim(), out nIntValue);
                                    if (succes)
                                        producto.Stock = nIntValue;
                                    else
                                        producto.Stock = 0;
                                    break;
                                case 4:
                                    //Contenido
                                    producto.Contenido = workSheet.Cells[row, col].Text.Trim().Length == 0 ? "" : workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 5:
                                    //CategoriaId
                                    var Categoria = Categorias.FirstOrDefault(x => x.CategoriaId == workSheet.Cells[row, col].Text.Trim());
                                    if (Categoria != null)
                                        producto.CategoriaId = Categoria.CategoriaId;
                                    else
                                        producto.CategoriaId = "SYS";


                                    break;
                                case 6:
                                    //PresentacionId
                                    var Presentacion = Presentaciones.FirstOrDefault(x => x.PresentacionId == workSheet.Cells[row, col].Text.Trim());
                                    if (Presentacion != null)
                                        producto.PresentacionId = Presentacion.PresentacionId;
                                    else
                                        producto.PresentacionId = "SYS";

                                    break;
                                case 7:
                                    //LaboratorioId
                                    var Laboratorio = Laboratorios.FirstOrDefault(x => x.LaboratorioId == workSheet.Cells[row, col].Text.Trim());
                                    if (Laboratorio != null)
                                        producto.LaboratorioId = Laboratorio.LaboratorioId;
                                    else
                                        producto.LaboratorioId = "SYS";

                                    break;
                                case 8:
                                    //Unidades
                                    producto.Unidades = workSheet.Cells[row, col].Text.Trim().Length == 0 ? "" : workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 9:
                                    //PrecioCompra
                                    succes = false;
                                    succes = decimal.TryParse(workSheet.Cells[row, col].Text.Trim(), out nDecValue);
                                    if (succes)
                                        producto.PrecioCompra = nDecValue;
                                    else
                                        producto.PrecioCompra = 1M;

                                    break;
                                case 10:
                                    //PrecioCaja
                                    succes = false;
                                    succes = decimal.TryParse(workSheet.Cells[row, col].Text.Trim(), out nDecValue);
                                    if (succes)
                                        producto.PrecioCaja = nDecValue;
                                    else
                                        producto.PrecioCaja = 1M;

                                    break;
                                case 11:
                                    //Precio1
                                    succes = false;
                                    succes = decimal.TryParse(workSheet.Cells[row, col].Text.Trim(), out nDecValue);
                                    if (succes)
                                        producto.Precio1 = nDecValue;
                                    else
                                        producto.Precio1 = 1M;

                                    break;
                                case 12:
                                    //Precio2
                                    succes = false;
                                    succes = decimal.TryParse(workSheet.Cells[row, col].Text.Trim(), out nDecValue);
                                    if (succes)
                                        producto.Precio2 = nDecValue;
                                    else
                                        producto.Precio2 = 1M;

                                    break;
                                case 13:
                                    //Utilidad1
                                    succes = false;
                                    succes = decimal.TryParse(workSheet.Cells[row, col].Text.Trim(), out nDecValue);
                                    if (succes)
                                        producto.Utilidad1 = nDecValue;
                                    else
                                        producto.Utilidad1 = 1M;

                                    break;
                                case 14:
                                    //Utilidad2
                                    succes = false;
                                    succes = decimal.TryParse(workSheet.Cells[row, col].Text.Trim(), out nDecValue);
                                    if (succes)
                                        producto.Utilidad2 = nDecValue;
                                    else
                                        producto.Utilidad2 = 1M;

                                    break;
                                case 15:
                                    //TieneLote
                                    if (workSheet.Cells[row, col].Text.Trim().Equals("VERDADERO"))
                                        producto.TieneLote = true;
                                    else
                                        producto.TieneLote = false;

                                    break;
                                case 16:
                                    //UnidadMedidaId
                                    var UnidadMedida = UnidadMedidas.FirstOrDefault(x => x.UnidadMedidaId == workSheet.Cells[row, col].Text.Trim());
                                    if (UnidadMedida != null)
                                        producto.UnidadMedidaId = UnidadMedida.UnidadMedidaId;
                                    else
                                        producto.UnidadMedidaId = "SYS";

                                    break;
                                case 17:
                                    //ClaveCfdiId

                                    var ClaveProdServ = ClavesSat.FirstOrDefault(x => x.ClaveProdServId == workSheet.Cells[row, col].Text.Trim());
                                    if (ClaveProdServ != null)
                                        producto.ClaveProdServId = ClaveProdServ.ClaveProdServId;
                                    else
                                        producto.ClaveProdServId = "01010101";

                                    break;
                                case 18:
                                    //UnidadCfdi
                                    producto.ClaveUnidadId = workSheet.Cells[row, col].Text.Trim().Length == 0 ? "H87" : workSheet.Cells[row, col].Text.Trim();

                                    break;
                                case 19:
                                    //RutaImg

                                    producto.RutaImg = workSheet.Cells[row, col].Text.Trim().Length == 0 ? null : (@"C:\Dympos\Compartido\" + workSheet.Cells[row, col].Text.Trim());
                                    producto.CratedAt = DateTime.Now;
                                    producto.UpdatedAt = DateTime.Now;
                                    producto.CratedBy = Ambiente.LoggedUser.UsuarioId;

                                    if (producto.ProductoId == null || producto.ProductoId.Length == 0)
                                        Errores.Add("SE OMITIÓ, " + producto.ProductoId + ", A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    else
                                        Productos.Add(producto);

                                    break;
                                default:
                                    MessageBox.Show("Columna no encontrada");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    ProductoController productoController = new ProductoController();
                    if (productoController.InsertRange(Productos))
                        Ambiente.Mensaje(end.Row + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }
        private void ImportaProveedores()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var proveedor = new Proveedor();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    //tp_per
                                    tipo_per = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    //ClienteId
                                    proveedor.ProveedorId = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 3:
                                    //RFC
                                    proveedor.Rfc = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 4:
                                    //Licencia
                                    //if (workSheet.Cells[row, col].Text.Trim().Equals("VERDADERO"))
                                    //    proveedor.TieneLicencia = true;
                                    //else
                                    //    proveedor.TieneLicencia = false;

                                    break;
                                case 5:
                                    //Negocio
                                    proveedor.Negocio = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 6:
                                    //RazonSocial
                                    proveedor.RazonSocial = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 7:
                                    //Contancto
                                    proveedor.Contancto = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 8:
                                    //Direccion
                                    proveedor.Direccion = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 9:
                                    //CP
                                    proveedor.Cp = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 10:
                                    //Municipio
                                    proveedor.Municipio = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 11:
                                    //Localidad
                                    proveedor.Localidad = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 12:
                                    //Estado
                                    proveedor.Estado = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 13:
                                    //Pais
                                    proveedor.Pais = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 14:
                                    //Telefono
                                    proveedor.Telefono = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 15:
                                    //Celular
                                    proveedor.Celular = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 16:
                                    //Colonia
                                    proveedor.Colonia = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 17:
                                    //Correo
                                    proveedor.Correo = workSheet.Cells[row, col].Text.Trim();
                                    proveedor.LimiteCredito = 0;
                                    proveedor.DiasCredito = 0;
                                    proveedor.IsDeleted = false;
                                    proveedor.Saldo = 0;

                                    if (tipo_per.Equals("P"))
                                        Proveedores.Add(proveedor);
                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var proveedorController = new ProveedorController();

                    if (proveedorController.InsertRange(Proveedores))
                        Ambiente.Mensaje(Proveedores.Count + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }

        private void ImportaClientes()
        {
            try
            {
                if (Ruta.Length == 0)
                {
                    Ambiente.Mensaje("Archivo invalido. \nProceso abortado");
                    return;
                }

                fi = new FileInfo(Ruta);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];

                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        Fila = row;
                        var cliente = new Cliente();

                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            Columna = col;
                            switch (col)
                            {
                                case 1:
                                    //tp_per
                                    tipo_per = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 2:
                                    //ClienteId
                                    cliente.ClienteId = workSheet.Cells[row, col].Text.Trim();
                                    cliente.LimiteCredito = 0;
                                    cliente.DiasCredito = 0;
                                    cliente.IsDeleted = false;
                                    cliente.FormaPagoId = "01";
                                    cliente.MetodoPagoId = "PUE";
                                    cliente.UsoCfdiid = "G01";
                                    cliente.PrecioDefault = 1;
                                    cliente.Saldo = 0;
                                    cliente.DineroElectronico = 0;
                                    break;
                                case 3:
                                    //RFC
                                    cliente.Rfc = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 4:
                                    //Licencia
                                    if (workSheet.Cells[row, col].Text.Trim().Equals("VERDADERO"))
                                        cliente.TieneLicencia = true;
                                    else
                                        cliente.TieneLicencia = false;

                                    break;
                                case 5:
                                    //Negocio
                                    cliente.Negocio = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 6:
                                    //RazonSocial
                                    cliente.RazonSocial = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 7:
                                    //Contancto
                                    cliente.Contancto = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 8:
                                    //Direccion
                                    cliente.Direccion = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 9:
                                    //CP
                                    cliente.Cp = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 10:
                                    //Municipio
                                    cliente.Municipio = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 11:
                                    //Localidad
                                    cliente.Localidad = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 12:
                                    //Estado
                                    cliente.Estado = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 13:
                                    //Pais
                                    cliente.Pais = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 14:
                                    //Telefono
                                    cliente.Telefono = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 15:
                                    //Celular
                                    cliente.Celular = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 16:
                                    //Colonia
                                    cliente.Colonia = workSheet.Cells[row, col].Text.Trim();
                                    break;
                                case 17:
                                    //Correo
                                    cliente.Correo = workSheet.Cells[row, col].Text.Trim();


                                    if (tipo_per.Equals("C"))
                                        Clientes.Add(cliente);
                                    break;
                                default:
                                    Errores.Add("SE OMITIÓ REGISTRO A CAUSA DE FILA: " + Fila + " COLUMNA: " + Columna + "\n");
                                    break;
                            }
                        }

                        Application.DoEvents();

                    }

                    var clienteController = new ClienteController();

                    if (clienteController.InsertRange(Clientes))
                        Ambiente.Mensaje(Clientes.Count + " Registros importados");
                    else
                        Ambiente.Mensaje("Algo salio mal :(");

                    if (Errores.Count > 0)
                        Ambiente.Mensaje(Errores.ToString());

                    excelPackage.Save();
                }

            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + Fila + " COLUMNA: " + Columna + "\n" + ex.ToString());
            }
        }
    }
}
