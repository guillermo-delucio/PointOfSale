using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Importaciones
{
    public partial class FrmImportaProds : Form
    {
        public List<string> Errores { get; private set; }
        public List<CClaveProdServ> ClavesSat { get; private set; }
        public List<Producto> Productos { get; private set; }
        public List<Laboratorio> Laboratorios { get; private set; }
        public List<UnidadMedida> UnidadMedidas { get; private set; }
        public List<Presentacion> Presentaciones { get; private set; }
        public List<Categoria> Categorias { get; private set; }
        public string Ruta { get; private set; }
        public int row { get; private set; }
        public int col { get; private set; }
        public ExcelWorksheet workSheet;






        private FileInfo fi;
        private bool exito;

        public FrmImportaProds()
        {
            InitializeComponent();
            Productos = new List<Producto>();
            Errores = new List<string>();
            exito = false;

        }



        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Bgw.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                try
                {

                    using (var db = new DymContext())
                    {
                        ClavesSat = db.CClaveProdServ.AsNoTracking().ToList();
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

                        workSheet = excelPackage.Workbook.Worksheets[1];

                        var start = workSheet.Dimension.Start;
                        var end = workSheet.Dimension.End;



                        bool succes = false;
                        int nIntValue = 0;
                        decimal nDecValue = 1m;

                        for (row = start.Row + 1; row <= end.Row; row++)
                        { // Row by row...


                            var producto = new Producto();

                            for (col = start.Column; col <= end.Column; col++)
                            {
                                switch (col)
                                {
                                    case 1:
                                        //ProductoId
                                        producto.ProductoId = workSheet.Cells[row, col].Text.Trim();
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
                                            producto.ClaveUnidadId = "01010101";

                                        break;
                                    case 18:
                                        //UnidadCfdi
                                        producto.ClaveUnidadId = workSheet.Cells[row, col].Text.Trim().Length == 0 ? "H87" : workSheet.Cells[row, col].Text.Trim();

                                        break;
                                    case 19:
                                        //RutaImg
                                        producto.RutaImg = workSheet.Cells[row, col].Text.Trim().Length == 0 ? null : (Ambiente.Empresa.DirectorioImg + workSheet.Cells[row, col].Text.Trim());
                                        producto.CratedAt = DateTime.Now;
                                        producto.UpdatedAt = DateTime.Now;
                                        producto.CratedBy = Ambiente.LoggedUser.UsuarioId;

                                        if (producto.ProductoId == null || producto.ProductoId.Length == 0)
                                            Errores.Add("SE OMITIÓ, " + producto.ProductoId + ", A CAUSA DE FILA: " + row + " COLUMNA: " + col + "\n");
                                        else
                                            Productos.Add(producto);

                                        break;
                                    default:
                                        MessageBox.Show("Columna no encontrada");
                                        break;
                                }
                                Bgw.ReportProgress(row);
                            }
                        }
                        excelPackage.Save();
                    }
                    if (new ProductoController().InsertRange(Productos))
                        exito = true;

                }
                catch (Exception ex)
                {
                    Ambiente.Mensaje(" ALGO SALIO MAL EN FILA: " + row + " COLUMNA: " + col + "\n" + ex.ToString());
                }
            }
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = workSheet.Dimension.End.Row;
            lblProgreso.Text = e.ProgressPercentage + " REGISTROS PREPARADOS";
            progressBar1.Value = e.ProgressPercentage;
            if (progressBar1.Maximum == e.ProgressPercentage)
                lblProgreso.Text = "TENGA PACIENCIA, LE AVISARÉMOS CUANDO TEMINE";
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (exito)
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[1]);
            else
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Bgw.RunWorkerAsync();
        }

        private void BtnOpenDialog_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Ruta = openFileDialog1.FileName;
                TxtRuta.Text = openFileDialog1.FileName;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Bgw.CancelAsync();
            Close();
        }
    }
}
