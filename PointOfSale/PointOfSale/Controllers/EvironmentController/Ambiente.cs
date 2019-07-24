using DYM.Views;
using Microsoft.EntityFrameworkCore;
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
            Tickets, Empresas, RegimenFiscal

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
        public static void AdditionalSettingsDataGridView(DataGridView dataGridView)
        {
            if (dataGridView.ColumnCount > 0)
                dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
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
            valor = valor.Trim();
            if (valor == null)
                return string.Format("{0:0.00}", "1");


            bool successv = decimal.TryParse(valor, out decimal nValor);
            if (!successv)
                return "1.00";
            return string.Format("{0:0.00}", nValor);
        }
        public static Tuple<string, string> GetFilePath()
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
            return null;
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

                decimal nPrecio = nCosto / (1 - (nMargen / 100));

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

                decimal nMargen = (1 - (nCosto / nPrecio)) * 100;
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
                if (decimal.TryParse(nPrecio, out precio) && impuestos.Count > 0)
                    foreach (var i in impuestos)
                        acumulado += precio * i.Tasa;
                else
                    return "1.000";
            }
            catch (Exception)
            {

                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + " precio y/o margen invalidos");
            }
            return FDinero((precio + acumulado).ToString());
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
            if (impuestoId == null)
            {
                return 0;
            }

            try
            {
                using (var db = new DymContext())
                {
                    var impuesto = db.Impuesto.FirstOrDefault(x => x.ImpuestoId == impuestoId.Trim());
                    if (impuesto != null)
                        return impuesto.Tasa;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@ GetTasaImpuesto \n" + ex.ToString());
            }
            return 0;

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
                    report.ExportDocument(StiExportFormat.Pdf, file);
                    report.Print(false, settings);
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
                    ds.Tables.Add(Ambiente.DT("select top 1 * from Empresa", "e"));

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
            using (var db = new DymContext())
            {
                ventas = db.Venta.Where(x => x.Cortada == false).OrderBy(x => x.CreatedAt).ToList();
            }

            if (ventas.Count > 0)
            {
                var empresaController = new EmpresaController();
                var empresa = empresaController.SelectTopOne();

                report.Load(empresa.RutaFormatoCorte);
                var ds = new DataSet("DS");
                report["userId"] = LoggedUser.UsuarioId;
                report["hinicial"] = ventas.FirstOrDefault().CreatedAt.ToString("dd/MM/yyyy h:mm tt");
                report["hfinal"] = ventas.Last().CreatedAt.ToString("dd/MM/yyyy h:mm tt");


                ds.Tables.Add(Ambiente.DT("select  v.CreatedAt, c.RazonSocial,v.Unidades, v.EstadoDocId, v.SubTotal, v.Impuesto, v.Total from Venta v join Cliente c on v.ClienteId = c.ClienteId where v.Cortada = 0 and v.EstadoDocId = 'CON'", "v"));
                report.RegData(ds);

                report.Render(false);
                var file = empresa.DirectorioCortes + "CORTE " + LoggedUser.UsuarioId + "_" + TimeText((DateTime)ventas.Last().CreatedAt) + ".PDF"; ;
                report.ExportDocument(StiExportFormat.Pdf, file);

                foreach (var v in ventas)
                    v.Cortada = true;
                if (new VentaController().UpdateRange(ventas))
                    Process.Start(file);




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


    }
}
