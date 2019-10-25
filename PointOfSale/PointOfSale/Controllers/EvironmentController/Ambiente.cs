using DYM.Views;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PointOfSale.Models;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Controllers
{
    public static class Ambiente
    {
        public static Dictionary<int, string> CatalgoMensajes { get; set; }

        public static Usuario LoggedUser { get; set; }
        public static Estacion Estacion { get; set; }
        public static Empresa Empresa { get; set; }
        public static string RutaImgs { get; set; }
        public static string PrefijoRutaImg { get; set; }
        public static string FormatoTicket { get; set; }

        #region Enums
        public enum TipoBusqueda
        {
            Clientes, Proveedores, Productos,
            Categorias, Laboratorios, Impuestos,
            Sustancias, Almacenes, Estaciones,
            ClavesSat, Presentaciones, UnidadesMedida,
            Usuarios, ProductoImpuesto, ProductoSustancia,
            ProductosCompleto, MetodoPago, FormaPago, UsoCDFI,
            Tickets, Empresas, RegimenFiscal, Sucursal, Lotes

        };

        #endregion

        #region Cuadros de mensajes

        public static void Mensaje(string s)
        {
            var m = new Mensaje(s);
            m.ShowDialog();
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }



        public static Traspaso SerializaPH(string path)
        {
            Traspaso traspaso = new Traspaso();
            try
            {
                if (path.Length == 0)
                {
                    Mensaje("Archivo invalido. Proceso abortado");
                    return null;
                }

                var fi = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;

                    //								


                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            switch (col)
                            {
                                //TraspasoId
                                case 1:
                                    break;

                                //Documento
                                case 2:
                                    traspaso.Documento = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //FechaDocumento
                                case 3:
                                    traspaso.FechaDocumento = DateTime.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //SucursalOrigenId
                                case 4:
                                    traspaso.SucursalOrigenId = int.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //SucursalOrigenName
                                case 5:
                                    traspaso.SucursalOrigenName = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //SerieOrigen
                                case 6:
                                    traspaso.SerieOrigen = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //SucursalDestinoId
                                case 7:
                                    traspaso.SucursalDestinoId = int.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //SucursalDestinoName
                                case 8:
                                    traspaso.SucursalDestinoName = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //SerieDestino
                                case 9:
                                    traspaso.SerieDestino = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //Enviado
                                case 10:
                                    traspaso.Enviado = workSheet.Cells[row, col].Text.Trim().Equals("FALSO") ? false : true;
                                    break;

                                //Aplicado
                                case 11:
                                    traspaso.Aplicado = workSheet.Cells[row, col].Text.Trim().Equals("FALSO") ? false : true;
                                    break;

                                //CreatedAt
                                case 12:
                                    traspaso.CreatedAt = DateTime.Now;
                                    break;

                                //CreatedBy
                                case 13:
                                    traspaso.CreatedBy = LoggedUser.UsuarioId;
                                    break;

                                //SentBy
                                case 14:
                                    traspaso.SentBy = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //TipoDocId
                                case 15:
                                    traspaso.TipoDocId = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //EstadoDocId
                                case 16:
                                    traspaso.EstadoDocId = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //Impuesto
                                case 17:
                                    traspaso.Impuesto = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //Subtotal
                                case 18:
                                    traspaso.Subtotal = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //Total
                                case 19:
                                    traspaso.Total = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;
                            }
                        }
                    }
                    excelPackage.Save();
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString());
            }

            return traspaso;
        }



        public static List<Traspasop> SerializaPD(string path)
        {
            List<Traspasop> partidas = new List<Traspasop>();
            try
            {
                if (path.Length == 0)
                {
                    Mensaje("Archivo invalido. Proceso abortado");
                    return null;
                }

                var fi = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(fi))
                {
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[1];
                    var start = workSheet.Dimension.Start;
                    var end = workSheet.Dimension.End;


                    for (int row = start.Row + 1; row <= end.Row; row++)
                    {
                        var partida = new Traspasop();
                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            switch (col)
                            {
                                //TraspasopId
                                case 1:
                                    break;

                                //TraspasoId
                                case 2:
                                    break;

                                //ProductoId
                                case 3:
                                    partida.ProductoId = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //Descripcion
                                case 4:
                                    partida.Descripcion = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //Cantidad
                                case 5:
                                    partida.Cantidad = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //Stock
                                case 6:
                                    partida.Stock = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //Precio
                                case 7:
                                    partida.Precio = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //LoteId
                                case 8:
                                    if (workSheet.Cells[row, col].Text.Trim().Length == 0)
                                        partida.LoteId = null;
                                    else
                                        partida.LoteId = int.Parse(workSheet.Cells[row, col].Text.Trim());

                                    break;

                                //NoLote
                                case 9:
                                    if (partida.LoteId == null)
                                        partida.NoLote = null;
                                    else
                                        partida.NoLote = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //Caducidad
                                case 10:

                                    if (partida.LoteId == null)
                                        partida.Caducidad = null;
                                    else
                                        partida.Caducidad = DateTime.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //ImpuestoId1
                                case 11:
                                    partida.ImpuestoId1 = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //ImpuestoId2
                                case 12:
                                    partida.ImpuestoId2 = workSheet.Cells[row, col].Text.Trim();
                                    break;

                                //Impuesto1
                                case 13:
                                    partida.Impuesto1 = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //Impuesto2
                                case 14:
                                    partida.Impuesto2 = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //ImporteImpuesto1
                                case 15:
                                    partida.ImporteImpuesto1 = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //ImporteImpuesto2
                                case 16:
                                    partida.ImporteImpuesto2 = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //Subtotal
                                case 17:
                                    partida.Subtotal = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;

                                //Total
                                case 18:
                                    partida.Total = decimal.Parse(workSheet.Cells[row, col].Text.Trim());
                                    break;
                            }
                        }
                        partidas.Add(partida);
                    }
                    excelPackage.Save();
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString());
            }

            return partidas;
        }
        public static bool Pregunta(string s)
        {

            using (var p = new Pregunta(s))
            {

                if (p.ShowDialog() == DialogResult.Yes)
                    return true;
                else
                    return false;

            }
        }

        #endregion

        #region Configuración Grids

        #endregion

        #region Miselaneos
        //Valida un correo
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                e.ToString();
                return false;
            }
            catch (ArgumentException e)
            {
                e.ToString();
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        /// Encripta una cadena
        public static string Encrypt(this string _cadenaAencriptar)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar.Trim());
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {

                Mensaje(CatalgoMensajes[-1] + ex.ToString());
            }
            return null;
        }
        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string Decrypt(this string _cadenaAdesencriptar)
        {

            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            catch (Exception ex)
            {

                Mensaje(CatalgoMensajes[-1] + ex.ToString());
            }
            return null;
        }
        public static string FechaSQL(DateTime dateTime)
        {
            return dateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string FDinero(string valor)
        {

            if (valor == null)
                return string.Format("{0:0.00}", "1");


            bool successv = decimal.TryParse(valor.Trim(), out decimal nValor);
            if (!successv)
                return "1.00";
            return string.Format("{0:0.00}", nValor);
        }
        public static Tuple<string, string> GetFilePath()
        {
            try
            {
                var filePath = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;
                        if (filePath.Length == 0 || openFileDialog.SafeFileName.Length == 0)
                            return new Tuple<string, string>("", "");

                        return new Tuple<string, string>(filePath, openFileDialog.SafeFileName);
                    }
                }

                return new Tuple<string, string>("", "");
            }
            catch (Exception)
            {
                return new Tuple<string, string>("", "");
            }


        }
        public static string GetFolderPath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = @"C:\";

            using (dialog)
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                    return dialog.SelectedPath + @"\";
                else
                    return "";
            }
        }
        public static void OpenDirectory(string RutaDirectorio)
        {
            Process.Start(RutaDirectorio);
        }
        public static bool RFCvalido(string rfc)
        {
            string expresion;
            expresion = @"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))((-)?([A-Z\d]{3}))?$";
            Regex automata = new Regex(expresion);
            return automata.IsMatch(rfc.Trim());
        }
        public static int TraeSiguiente(string consecutivoId)
        {

            try
            {
                using (var db = new DymContext())
                {
                    var consecutivo = db.Consecutivo.FirstOrDefault(x => x.ConsecutivoId == consecutivoId.Trim());
                    if (consecutivo != null)
                    {
                        return ++consecutivo.Folio;
                    }
                    else
                    {
                        consecutivo = new Consecutivo();
                        consecutivo.ConsecutivoId = consecutivoId;
                        consecutivo.Folio++;
                        db.Add(consecutivo);
                        db.SaveChanges();
                        return consecutivo.Folio;
                    }
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@ TraeSiguiente \n" + ex.ToString());
            }
            return -1;

        }
        public static int UpdateSiguiente(string consecutivoId)
        {

            try
            {
                using (var db = new DymContext())
                {
                    var consecutivo = db.Consecutivo.FirstOrDefault(x => x.ConsecutivoId == consecutivoId.Trim());
                    if (consecutivo != null)
                    {
                        consecutivo.Folio++;
                        db.Update(consecutivo);
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@ UpdateSiguiente \n" + ex.ToString());
            }
            return -1;

        }
        public static string Z(int valor)
        {
            return string.Format("{0:00000}", valor);
        }
        #endregion

        #region Precios y margenes

        public static string GetPrecio(string Costo, string Margen)
        {
            try
            {
                bool successc = decimal.TryParse(Costo, out decimal nCosto);
                bool successm = decimal.TryParse(Margen, out decimal nMargen);

                if (!successc || !successm)
                    return "1.000";

                //decimal nPrecio = nCosto / (1 - (nMargen / 100));
                decimal nPrecio = nCosto + (nCosto * (nMargen / 100));
                return string.Format("{0:0.000}", nPrecio);
            }
            catch (Exception)
            {

                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + " precio y/o margen invalidos");
            }

            return string.Format("{0:0.000}", 1);

        }

        public static string GetMargen(string Costo, string Precio)
        {
            try
            {
                bool successc = decimal.TryParse(Costo, out decimal nCosto);
                bool successp = decimal.TryParse(Precio, out decimal nPrecio);

                if (!successc || !successp)
                    return "1.000";

                //decimal nMargen = (1 - (nCosto / nPrecio)) * 100;
                decimal nMargen = ((nPrecio / nCosto) - 1) * 100;
                return string.Format("{0:0.000}", nMargen);
            }
            catch (Exception)
            {

                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + " precio y/o margen invalidos");
            }

            return string.Format("{0:0.000}", 1);

        }

        public static string GetPrecioSalida(string nPrecio, ICollection<Impuesto> impuestos)
        {
            decimal precio = 0M, acumulado = 0M;
            try
            {
                if (decimal.TryParse(nPrecio, out precio))
                {
                    acumulado = precio;
                    foreach (var i in impuestos)
                        acumulado += precio * i.Tasa;
                }
                else
                    return "1.000";
            }
            catch (Exception)
            {

                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + " precio y/o margen invalidos");
            }
            return FDinero((acumulado).ToString());
        }

        public static decimal GetPrecioSalida(Producto producto, int listaPrecio = 1)
        {
            decimal precio = 0;
            try
            {

                if (producto == null)
                    return 0;

                decimal tasa1 = GetTasaImpuesto(producto.Impuesto1Id);
                decimal tasa2 = GetTasaImpuesto(producto.Impuesto2Id);
                if (listaPrecio == 1)
                {
                    precio = producto.Precio1;

                    if (tasa1 > 0)
                        precio += precio * tasa1;

                    if (tasa2 > 0)
                        precio += precio * tasa2;

                }
                else if (listaPrecio == 2)
                {
                    precio = producto.Precio2;

                    if (tasa1 > 0)
                        precio += precio * tasa1;

                    if (tasa2 > 0)
                        precio += precio * tasa2;
                }
                else if (listaPrecio == 3)
                {
                    precio = producto.Precio3;

                    if (tasa1 > 0)
                        precio += precio * tasa1;

                    if (tasa2 > 0)
                        precio += precio * tasa2;
                }
                else if (listaPrecio == 4)
                {
                    precio = producto.Precio4;

                    if (tasa1 > 0)
                        precio += precio * tasa1;

                    if (tasa2 > 0)
                        precio += precio * tasa2;
                }


            }
            catch (Exception)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + " AL CACULAR EL PRECIO DE SALIDA");
            }
            return precio;
        }


        public static decimal ToDecimal(string precio)
        {

            try
            {
                bool successp = decimal.TryParse(precio.Trim(), out decimal nPrecio);


                if (!successp)
                    return 0;

                return nPrecio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal. \n Ambiente ToDecimal\n " + ex.Message);
            }

            return 1m;
        }
        public static int ToInt(string precio)
        {

            try
            {
                bool successp = int.TryParse(precio.Trim(), out int nPrecio);


                if (!successp)
                    return 0;

                return nPrecio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal. \n Ambiente ToDecimal\n " + ex.Message);
            }

            return 0;
        }
        public static string ToString(decimal precio)
        {

            try
            {
                return precio.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal. \n Ambiente ToDecimal\n " + ex.Message);
            }

            return "1.000";
        }

        public static decimal GetTasaImpuesto(string impuestoId)
        {
            if (string.IsNullOrEmpty(impuestoId.Trim()))
            {
                return 1;
            }
            if (impuestoId == null)
            {
                return 1;
            }

            try
            {
                using (var db = new DymContext())
                {
                    var impuesto = db.Impuesto.FirstOrDefault(x => x.ImpuestoId == impuestoId.Trim());
                    if (impuesto != null)
                        return impuesto.Tasa;
                    else
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@ GetTasaImpuesto \n" + ex.ToString());
            }
            return 1;

        }



        #endregion

        //Generador de reportes
        public static DataTable DT(string Query, string nombre)
        {
            using (var db = new DymContext())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, db.Database.GetDbConnection() as SqlConnection);
                DataTable dataTable = new DataTable(nombre.Trim());
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public static void Export(string RutaFormato, string DirectorioOut, string NombreArchivo, StiExportFormat FileFormat, bool abrir, string Q1, string Q2 = "", string Q3 = "", string Q4 = "", string Q5 = "", string Q6 = "")
        {
            //Exportar
            var report = new StiReport();
            var ds = new DataSet("DS");
            report.Load(@RutaFormato);


            if (Q1.Trim().Length > 0)
                ds.Tables.Add(DT(Q1, "Q1"));

            if (Q2.Trim().Length > 0)
                ds.Tables.Add(DT(Q2, "Q2"));

            if (Q3.Trim().Length > 0)
                ds.Tables.Add(DT(Q3, "Q3"));

            if (Q4.Trim().Length > 0)
                ds.Tables.Add(DT(Q4, "Q4"));

            if (Q5.Trim().Length > 0)
                ds.Tables.Add(DT(Q5, "Q5"));

            if (Q6.Trim().Length > 0)
                ds.Tables.Add(DT(Q6, "Q6"));

            report.RegData(ds);
            report.Render(true);
            var file = DirectorioOut + NombreArchivo;
            report.ExportDocument(FileFormat, file);
            if (abrir)
                Process.Start(file);
            report.Print(false);
        }
        public static void Desing(string RutaFormato, string Q1, string Q2 = "", string Q3 = "", string Q4 = "", string Q5 = "", string Q6 = "")
        {
            //Ver
            var report = new StiReport();
            var ds = new DataSet("DS");
            report.Load(@RutaFormato);

            if (Q1.Trim().Length > 0)
                ds.Tables.Add(DT(Q1, "Q1"));

            if (Q2.Trim().Length > 0)
                ds.Tables.Add(DT(Q2, "Q2"));

            if (Q3.Trim().Length > 0)
                ds.Tables.Add(DT(Q3, "Q3"));

            if (Q4.Trim().Length > 0)
                ds.Tables.Add(DT(Q4, "Q4"));

            if (Q5.Trim().Length > 0)
                ds.Tables.Add(DT(Q5, "Q5"));

            if (Q6.Trim().Length > 0)
                ds.Tables.Add(DT(Q6, "Q6"));


            //Diseñar
            report.Load(@RutaFormato);
            report.RegData(ds);
            report.Dictionary.Synchronize();
            report.Design();
            report.Save(@RutaFormato);
        }
        public static void Preview(string RutaFormato, string Q1, string Q2 = "", string Q3 = "", string Q4 = "", string Q5 = "", string Q6 = "")
        {
            //Ver
            var report = new StiReport();
            report.Load(@RutaFormato);
            var ds = new DataSet("DS");

            if (Q1.Trim().Length > 0)
                ds.Tables.Add(DT(Q1, "Q1"));

            if (Q2.Trim().Length > 0)
                ds.Tables.Add(DT(Q2, "Q2"));

            if (Q3.Trim().Length > 0)
                ds.Tables.Add(DT(Q3, "Q3"));

            if (Q4.Trim().Length > 0)
                ds.Tables.Add(DT(Q4, "Q4"));

            if (Q5.Trim().Length > 0)
                ds.Tables.Add(DT(Q5, "Q5"));

            if (Q6.Trim().Length > 0)
                ds.Tables.Add(DT(Q6, "Q6"));

            report.RegData(ds);
            report.Show();

        }
        public static void Print(string RutaFormato, PrinterSettings printerSettings, string Q1, string Q2 = "", string Q3 = "", string Q4 = "", string Q5 = "", string Q6 = "")
        {
            //Ver
            var report = new StiReport();
            report.Load(@RutaFormato);
            var ds = new DataSet("DS");

            if (Q1.Trim().Length > 0)
                ds.Tables.Add(DT(Q1, "Q1"));

            if (Q2.Trim().Length > 0)
                ds.Tables.Add(DT(Q2, "Q2"));

            if (Q3.Trim().Length > 0)
                ds.Tables.Add(DT(Q3, "Q3"));

            if (Q4.Trim().Length > 0)
                ds.Tables.Add(DT(Q4, "Q4"));

            if (Q5.Trim().Length > 0)
                ds.Tables.Add(DT(Q5, "Q5"));

            if (Q6.Trim().Length > 0)
                ds.Tables.Add(DT(Q6, "Q6"));

            report.RegData(ds);
            report.Print(false, printerSettings);
        }
        public static void ExportAndPrint(string RutaFormato, string DirectorioOut, string NombreArchivo, StiExportFormat FileFormat, PrinterSettings printerSettings, bool abrir, string Q1, string Q2 = "", string Q3 = "", string Q4 = "", string Q5 = "", string Q6 = "")
        {
            //Exportar
            var report = new StiReport();
            var ds = new DataSet("DS");
            report.Load(@RutaFormato);


            if (Q1.Trim().Length > 0)
                ds.Tables.Add(DT(Q1, "Q1"));

            if (Q2.Trim().Length > 0)
                ds.Tables.Add(DT(Q2, "Q2"));

            if (Q3.Trim().Length > 0)
                ds.Tables.Add(DT(Q3, "Q3"));

            if (Q4.Trim().Length > 0)
                ds.Tables.Add(DT(Q4, "Q4"));

            if (Q5.Trim().Length > 0)
                ds.Tables.Add(DT(Q5, "Q5"));

            if (Q6.Trim().Length > 0)
                ds.Tables.Add(DT(Q6, "Q6"));

            report.RegData(ds);
            report.Render(false);
            var file = DirectorioOut + NombreArchivo;
            report.ExportDocument(FileFormat, file);
            if (abrir)
                Process.Start(file);
            report.Print(false, printerSettings);
        }
        public static void SaveAndPrintTicket(Venta venta)
        {
            if (venta != null)
            {
                var empresa = new EmpresaController().SelectTopOne();
                var estacion = new EstacionController().SelectOne(venta.EstacionId);
                if (estacion != null && empresa != null)
                {
                    if (empresa.DirectorioTickets.Trim().Length == 0 || empresa.RutaFormatoTicket.Trim().Length == 0 || estacion.ImpresoraT.Trim().Length == 0)
                    {
                        Mensaje("DirectorioTickets|| RutaFormatoTicket || ImpresoraT, No configurado.");
                        return;
                    }

                    var report = new StiReport();
                    var ds = new DataSet("DS");
                    var settings = new PrinterSettings();
                    var file = empresa.DirectorioTickets + "TICKET " + venta.NoRef.ToString() + "_" + venta.CreatedBy + "_" + Ambiente.TimeText((DateTime)venta.CreatedAt) + ".PDF"; ;

                    report.Load(empresa.RutaFormatoTicket);
                    settings.PrinterName = estacion.ImpresoraT;
                    settings.Copies = (short)estacion.TantosT;

                    ds.Tables.Add(DT("select * from venta where ventaid=" + venta.VentaId, "Q1"));
                    ds.Tables.Add(DT("select * from ventap where ventaid = " + venta.VentaId, "Q2"));
                    ds.Tables.Add(DT("select * from cliente where clienteid='" + venta.ClienteId + "'", "Q3"));

                    report.RegData(ds);
                    report.Render(false);
                    report.Design();
                    report.ExportDocument(StiExportFormat.Pdf, file);
                    report.Print(false, settings);
                   report.Save(@"C:\Dympos\Formatos\Ticket.mrt");

                }
                else
                    Mensaje("Imposible imprimir, la empresa o estación carece de información.");
            }
            else
                Mensaje("Imposible imprimir, el documento llegó null");
        }
        public static void SaveAndPrintFactura(Venta venta, bool OpenDoc = false, bool PrintDoc = false)
        {
            if (venta != null)
            {
                var empresa = new EmpresaController().SelectTopOne();
                var estacion = new EstacionController().SelectOne(venta.EstacionId);
                if (estacion != null && empresa != null)
                {
                    if (empresa.DirectorioComprobantes.Trim().Length == 0 || empresa.RutaFormatoFactura.Trim().Length == 0 || estacion.ImpresoraF.Trim().Length == 0)
                    {
                        Mensaje("DirectorioComprobantes|| RutaFormatoFactura || ImpresoraF, No configurado.");
                        return;
                    }

                    var report = new StiReport();
                    var ds = new DataSet("DS");
                    var settings = new PrinterSettings();
                    var file = empresa.DirectorioComprobantes + "FACTURA " + venta.NoRef.ToString() + "_" + venta.CreatedBy + "_" + Ambiente.TimeText((DateTime)venta.CreatedAt) + ".PDF"; ;

                    report.Load(empresa.RutaFormatoFactura);
                    settings.PrinterName = estacion.ImpresoraF;
                    settings.Copies = (short)estacion.TantosF;

                    ds.Tables.Add(DT("select * from venta where ventaid=" + venta.VentaId, "v"));
                    ds.Tables.Add(DT("select * from ventap where ventaid = " + venta.VentaId, "vp"));
                    ds.Tables.Add(DT("select * from cliente where clienteid='" + venta.ClienteId + "'", "c"));
                    ds.Tables.Add(DT("select top 1 * from Empresa", "e"));

                    report.RegData(ds);
                    report.Render(false);
                    report.ExportDocument(StiExportFormat.Pdf, file);
                    if (OpenDoc)
                        Process.Start(file);

                    if (PrintDoc)
                        report.Print(false, settings);
                }
                else
                    Mensaje("Imposible imprimir, la empresa o estación carece de información.");
            }
            else
                Mensaje("Imposible imprimir, el documento llegó null");
        }

        public static void SaveAndCorte()
        {
            StiReport report = new StiReport();

            List<Venta> ventas;
            decimal importe = 0;
            using (var db = new DymContext())
            {
                ventas = db.Venta.Where(x => x.Cortada == false).OrderBy(x => x.CreatedAt).ToList();
                importe = db.Venta.Where(x => x.Cortada == false).Sum(x => x.Total);
            }

            if (ventas.Count > 0)
            {
                var empresaController = new EmpresaController();
                var empresa = empresaController.SelectTopOne();


                report.Load(empresa.RutaFormatoCorte);
                report.Compile();
                var ds = new DataSet("DS");
                report["userId"] = LoggedUser.UsuarioId;
                report["hinicial"] = ventas.FirstOrDefault().CreatedAt.ToString("dd/MM/yyyy h:mm tt").ToUpper();
                report["hfinal"] = ventas.Last().CreatedAt.ToString("dd/MM/yyyy h:mm tt").ToUpper();


                ds.Tables.Add(Ambiente.DT("select  v.CreatedAt, c.RazonSocial,v.Unidades, v.EstadoDocId, v.SubTotal, v.Impuesto, v.Total from Venta v join Cliente c on v.ClienteId = c.ClienteId where v.Cortada = 0 and v.EstadoDocId = 'CON'", "v"));
                report.RegData(ds);

                report.Render(false);
                var file = empresa.DirectorioCortes + "CORTE " + LoggedUser.UsuarioId + "_" + TimeText((DateTime)ventas.Last().CreatedAt) + ".PDF"; ;
                report.ExportDocument(StiExportFormat.Pdf, file);

                var corte = new Corte();
                corte.EstacionId = Ambiente.Estacion.EstacionId;
                corte.FechaInicial = ventas.FirstOrDefault().CreatedAt;
                corte.FechaFinal = ventas.Last().CreatedAt;
                corte.Importe = importe;
                corte.RutaArchivo = file;
                corte.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                corte.CreatedAt = DateTime.Now;



                foreach (var v in ventas)
                    v.Cortada = true;
                if (new VentaController().UpdateRange(ventas))
                {
                    var corteController = new CorteController();
                    corteController.InsertOne(corte);
                    Process.Start(file);

                }
            }
            else
            {
                Ambiente.Mensaje("No hay nada que cortar");
                return;

            }

        }
        public static string TimeText(DateTime date)
        {
            return date.ToString("dd.MM.yyyy_hh.mm.ss");
        }
        public static string JustNow()
        {
            return DateTime.Now.ToString("ddMMyyyyHHmmss");
        }
        public static bool ComprimirDirectorio(String DirectorioOrigen, string RutaZipDestino)
        {

            try
            {
                ZipFile.CreateFromDirectory(DirectorioOrigen, RutaZipDestino);
                return true;
            }
            catch (Exception e)
            {

                Mensaje(e.ToString());
            }

            return false;
        }
        public static bool ExtraerFile(string RutaZipOrigen, string DirectorioDestino)
        {

            try
            {
                ZipFile.ExtractToDirectory(RutaZipOrigen, DirectorioDestino);
                return true;
            }
            catch (Exception e)
            {

                Mensaje(e.Message);
            }

            return false;
        }
        public static bool CopiarFile(string sourceFile, string destFile, bool remplazar = true)
        {

            try
            {
                File.Copy(sourceFile, destFile, remplazar);
                return true;
            }
            catch (Exception e)
            {

                Mensaje(e.ToString());
            }

            return false;
        }

        public static bool BorrarFile(string RutaArchivo)
        {

            // Delete a file by using File class static method...
            if (File.Exists(@RutaArchivo))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    File.Delete(@RutaArchivo);
                    return true;
                }
                catch (IOException e)
                {
                    Mensaje(e.Message);
                    return false;
                }
            }
            return false;
        }
        public static bool VaciarDirectorio(string RutaDirectorio)
        {
            // Delete a directory and all subdirectories with Directory static method...
            if (Directory.Exists(@RutaDirectorio))
            {
                try
                {
                    foreach (var f in GetDirectoryFiles(RutaDirectorio))
                    {
                        File.Delete(RutaDirectorio + f);
                    }
                }
                catch (IOException e)
                {
                    Mensaje(e.Message);
                }
            }
            return false;
        }
        public static bool CrearDirectorio(string RutaDirectorio)
        {

            //Create a new target folder.
            // If the directory already exists, this method does not create a new directory

            try
            {
                Directory.CreateDirectory(@RutaDirectorio);
                return true;
            }

            catch (IOException e)
            {
                Mensaje(e.Message);
            }

            return false;
        }
        public static List<string> GetDirectoryFiles(string directorio)
        {
            List<string> filesList = new List<string>();
            DirectoryInfo d = new DirectoryInfo(@directorio);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.zip"); //Getting Text files

            foreach (FileInfo file in Files)
            {
                filesList.Add(file.Name);
            }
            return filesList;

        }

        public static bool MoverFile(string sourceFile, string NewNameDestFile)
        {

            try
            {
                File.Move(sourceFile, NewNameDestFile);
                return true;
            }
            catch (Exception e)
            {

                Mensaje(e.ToString());
            }

            return false;
        }

        public static bool CrearTraspasoExcel(string outputDir, string fileName, Traspaso traspaso)
        {
            // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);
            if (traspaso == null)
            {
                Mensaje("Proceso abortado, no se empacó el traspaso porque llegó vacío.");
                return false;
            }

            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("ENCABEZADO");

                // Start adding the header
                worksheet.Cells[1, 1].Value = "TraspasoId";
                worksheet.Cells[1, 2].Value = "Documento";
                worksheet.Cells[1, 3].Value = "FechaDocumento";
                worksheet.Cells[1, 4].Value = "SucursalOrigenId";
                worksheet.Cells[1, 5].Value = "SucursalOrigenName";
                worksheet.Cells[1, 6].Value = "SerieOrigen";
                worksheet.Cells[1, 7].Value = "SucursalDestinoId";
                worksheet.Cells[1, 8].Value = "SucursalDestinoName";
                worksheet.Cells[1, 9].Value = "SerieDestino";
                worksheet.Cells[1, 10].Value = "Enviado";
                worksheet.Cells[1, 11].Value = "Aplicado";
                worksheet.Cells[1, 12].Value = "CreatedAt";
                worksheet.Cells[1, 13].Value = "CreatedBy";
                worksheet.Cells[1, 14].Value = "SentBy";
                worksheet.Cells[1, 15].Value = "TipoDocId";
                worksheet.Cells[1, 16].Value = "EstadoDocId";
                worksheet.Cells[1, 17].Value = "Impuesto";
                worksheet.Cells[1, 18].Value = "Subtotal";
                worksheet.Cells[1, 19].Value = "Total";

                // Loop data
                worksheet.Cells[2, 1].Value = traspaso.TraspasoId;
                worksheet.Cells[2, 2].Value = traspaso.Documento;
                worksheet.Cells[2, 3].Value = traspaso.FechaDocumento.ToString("yyyy-MM-dd HH:mm:ss");
                worksheet.Cells[2, 4].Value = traspaso.SucursalOrigenId;
                worksheet.Cells[2, 5].Value = traspaso.SucursalOrigenName;
                worksheet.Cells[2, 6].Value = traspaso.SerieOrigen;
                worksheet.Cells[2, 7].Value = traspaso.SucursalDestinoId;
                worksheet.Cells[2, 8].Value = traspaso.SucursalDestinoName;
                worksheet.Cells[2, 9].Value = traspaso.SerieDestino;
                worksheet.Cells[2, 10].Value = traspaso.Enviado;
                worksheet.Cells[2, 11].Value = traspaso.Aplicado;
                worksheet.Cells[2, 12].Value = traspaso.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                worksheet.Cells[2, 13].Value = traspaso.CreatedBy;
                worksheet.Cells[2, 14].Value = traspaso.SentBy;
                worksheet.Cells[2, 15].Value = traspaso.TipoDocId;
                worksheet.Cells[2, 16].Value = traspaso.EstadoDocId;
                worksheet.Cells[2, 17].Value = traspaso.Impuesto;
                worksheet.Cells[2, 18].Value = traspaso.Subtotal;
                worksheet.Cells[2, 19].Value = traspaso.Total;

                // save our new workbook and we are done!
                package.Save();
            }

            return true;
        }
        public static bool CrearTraspasopExcel(string outputDir, string fileName, List<Traspasop> partidas)
        {
            // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);
            if (partidas.Count == 0)
            {
                Mensaje("Proceso abortado, no se empacó porque las partidas llegaron vacias.");
                return false;
            }

            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("PARTIDAS");
                // Start adding the header
                // First of all the first row

                worksheet.Cells[1, 1].Value = "TraspasopId";
                worksheet.Cells[1, 2].Value = "TraspasoId";
                worksheet.Cells[1, 3].Value = "ProductoId";
                worksheet.Cells[1, 4].Value = "Descripcion";
                worksheet.Cells[1, 5].Value = "Cantidad";
                worksheet.Cells[1, 6].Value = "Stock";
                worksheet.Cells[1, 7].Value = "Precio";
                worksheet.Cells[1, 8].Value = "LoteId";
                worksheet.Cells[1, 9].Value = "NoLote";
                worksheet.Cells[1, 10].Value = "Caducidad";
                worksheet.Cells[1, 11].Value = "ImpuestoId1";
                worksheet.Cells[1, 12].Value = "ImpuestoId2";
                worksheet.Cells[1, 13].Value = "Impuesto1";
                worksheet.Cells[1, 14].Value = "Impuesto2";
                worksheet.Cells[1, 15].Value = "ImporteImpuesto1";
                worksheet.Cells[1, 16].Value = "ImporteImpuesto2";
                worksheet.Cells[1, 17].Value = "Subtotal";
                worksheet.Cells[1, 18].Value = "Total";




                int i = 2;
                foreach (var p in partidas)
                {
                    worksheet.Cells[i, 1].Value = p.TraspasopId;
                    worksheet.Cells[i, 2].Value = p.TraspasoId;
                    worksheet.Cells[i, 3].Value = p.ProductoId;
                    worksheet.Cells[i, 4].Value = p.Descripcion;
                    worksheet.Cells[i, 5].Value = p.Cantidad;
                    worksheet.Cells[i, 6].Value = p.Stock;
                    worksheet.Cells[i, 7].Value = p.Precio;
                    worksheet.Cells[i, 8].Value = p.LoteId;
                    worksheet.Cells[i, 9].Value = p.NoLote;
                    worksheet.Cells[i, 10].Value = p.Caducidad == null ? null : ((DateTime)p.Caducidad).ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cells[i, 11].Value = p.ImpuestoId1;
                    worksheet.Cells[i, 12].Value = p.ImpuestoId2;
                    worksheet.Cells[i, 13].Value = p.Impuesto1;
                    worksheet.Cells[i, 14].Value = p.Impuesto2;
                    worksheet.Cells[i, 15].Value = p.ImporteImpuesto1;
                    worksheet.Cells[i, 16].Value = p.ImporteImpuesto2;
                    worksheet.Cells[i, 17].Value = p.Subtotal;
                    worksheet.Cells[i, 18].Value = p.Total;
                    i++;
                }
                // save our new workbook and we are done!
                package.Save();
            }

            return true;
        }
        public static bool CrearEnvioPreciosExcel(string outputDir, string fileName)
        {
            // Create the file using the FileInfo object
            var file = new FileInfo(outputDir + fileName);

            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("PARTIDAS");
                // Start adding the header
                // First of all the first row

                worksheet.Cells[1, 1].Value = "ProductoId";
                worksheet.Cells[1, 2].Value = "Descripcion";
                worksheet.Cells[1, 3].Value = "PrecioCompra";
                worksheet.Cells[1, 4].Value = "PrecioCaja";
                worksheet.Cells[1, 5].Value = "Precio1";
                worksheet.Cells[1, 6].Value = "Precio2";
                worksheet.Cells[1, 7].Value = "Precio3";
                worksheet.Cells[1, 8].Value = "Precio4";
                worksheet.Cells[1, 9].Value = "Utilidad1";
                worksheet.Cells[1, 10].Value = "Utilidad2";
                worksheet.Cells[1, 11].Value = "Utilidad3";
                worksheet.Cells[1, 12].Value = "Utilidad4";

                int i = 2;
                var partidas = new ProductoController().SelectAll();
                foreach (var p in partidas)
                {
                    worksheet.Cells[i, 1].Value = p.ProductoId;
                    worksheet.Cells[i, 2].Value = p.Descripcion;
                    worksheet.Cells[i, 3].Value = p.PrecioCompra;
                    worksheet.Cells[i, 4].Value = p.PrecioCaja;
                    worksheet.Cells[i, 5].Value = p.Precio1;
                    worksheet.Cells[i, 6].Value = p.Precio2;
                    worksheet.Cells[i, 7].Value = p.Precio3;
                    worksheet.Cells[i, 8].Value = p.Precio4;
                    worksheet.Cells[i, 9].Value = p.Utilidad1;
                    worksheet.Cells[i, 10].Value = p.Utilidad2;
                    worksheet.Cells[i, 11].Value = p.Utilidad3;
                    worksheet.Cells[i, 12].Value = p.Utilidad4;
                    i++;
                }
                // save our new workbook and we are done!
                package.Save();
            }

            return true;
        }
        public static bool CancelaProceso;
    }
}
