using OfficeOpenXml;
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
        private FileInfo fi;
        private List<string> Errores;
        private List<Producto> Productos;

        public ImportaExcelController(int catalogo)
        {
            Fila = 0;
            Columna = 0;
            Catalogo = catalogo;
            Ruta = string.Empty;
            Errores = new List<string>();
            Productos = new List<Producto>();

            GetRuta();
            Importa();
        }

        public void GetRuta()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Excel Files|*.XLSX";
                openFileDialog.FilterIndex = 2;
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
                default:
                    MessageBox.Show("Error, no hay importacion para catalogo");
                    break;
            }
        }

        private void ImportaUsuarios()
        {
            throw new NotImplementedException();
        }

        private void ImportaUnidadMedida()
        {
            throw new NotImplementedException();
        }

        private void ImportaPresentaciones()
        {
            throw new NotImplementedException();
        }

        private void ImportaClavesSat()
        {
            throw new NotImplementedException();
        }

        private void ImportaEstaciones()
        {
            throw new NotImplementedException();
        }

        private void ImportaAlmacenes()
        {
            throw new NotImplementedException();
        }

        private void ImportaSustancias()
        {
            throw new NotImplementedException();
        }

        private void ImportaImpuestos()
        {
            throw new NotImplementedException();
        }

        private void ImportaLaboratorios()
        {
            throw new NotImplementedException();
        }

        private void ImportaCategorias()
        {
            throw new NotImplementedException();
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
                                    producto.CratedAt = DateTime.Now;
                                    producto.UpdatedAt = DateTime.Now;
                                    producto.CratedBy = Ambiente.LoggedUser.UsuarioId;

                                    if (succes)
                                    {
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

        private void ImportaProveedores()
        {
            throw new NotImplementedException();
        }

        private void ImportaClientes()
        {
            throw new NotImplementedException();
        }
    }
}
