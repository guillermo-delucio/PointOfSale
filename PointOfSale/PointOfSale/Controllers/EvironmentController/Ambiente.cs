using DYM.Views;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        public static string RutaImgs { get; set; }
        public static string PrefijoRutaImg { get; set; }

        #region Enums
        public enum TipoBusqueda
        {
            Clientes, Proveedores, Productos,
            Categorias, Laboratorios, Impuestos,
            Sustancias, Almacenes, Estaciones,
            ClavesSat, Presentaciones, UnidadesMedida,
            Usuarios, ProductoImpuesto, ProductoSustancia,
            ProductosCompleto, MetodoPago, FormaPago

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
                return string.Format("{0:0.000}", "1");


            bool successv = decimal.TryParse(valor, out decimal nValor);
            if (!successv)
                return "1.000";
            return string.Format("{0:0.000}", nValor);
        }
        public static Tuple<string, string> GetRuta()
        {

            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JPG files (*.JPG)|*.JPG|PNG files (*.PNG)|*.PNG";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    return new Tuple<string, string>(filePath, openFileDialog.SafeFileName);
                }
            }
            return null;
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
                        return consecutivo.Folio;
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


    }
}
