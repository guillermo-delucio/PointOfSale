using DYM.Views;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Controllers
{
    public static class Ambiente
    {
        public static Dictionary<int, string> CatalgoMensajes { get; set; }

        public static Usuario LoggedUser { get; set; }

        #region Enums
        public enum TipoBusqueda
        {
            Clientes, Proveedores, Productos,
            Categorias, Laboratorios, Impuestos,
            Sustancias, Almacenes, Estaciones,
            ClavesSat, Presentaciones, UnidadesMedida,
            Usuarios, ProductoImpuesto, ProductoSustancia

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


        public static string FechaSQL(DateTime dateTime)
        {
            return dateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string FDinero(string valor)
        {
            bool successv = decimal.TryParse(valor, out decimal nValor);
            if (!successv)
                return "1.000";
            return string.Format("{0:0.000}", nValor);
        }

        #endregion

        #region Precios y margenes

        public static string GetPrecioString(string Costo, string Margen)
        {
            bool successc = decimal.TryParse(Costo, out decimal nCosto);
            bool successm = decimal.TryParse(Margen, out decimal nMargen);

            if (!successc || !successm)
                return "1.000";

            decimal nPrecio = nCosto / (1 - (nMargen / 100));

            return string.Format("{0:0.000}", nPrecio);
        }
        public static decimal GetPrecioDecimal(string Costo, string Margen)
        {
            bool successc = decimal.TryParse(Costo, out decimal nCosto);
            bool successm = decimal.TryParse(Margen, out decimal nMargen);

            if (!successc || !successm)
                return 0M;

            decimal nPrecio = ((nCosto) / (1 - (nMargen / 100)));

            return nPrecio;
        }
        public static string GetMargenString(string Costo, string Precio)
        {

            bool successc = decimal.TryParse(Costo, out decimal nCosto);
            bool successp = decimal.TryParse(Precio, out decimal nPrecio);

            if (!successc || !successp)
                return "1.000";

            decimal nMargen = (1 - (nCosto / nPrecio)) * 100;

            return string.Format("{0:0.000}", nMargen);
        }
        public static decimal GetMargenDecimal(string Costo, string Precio)
        {

            bool successc = decimal.TryParse(Costo, out decimal nCosto);
            bool successp = decimal.TryParse(Precio, out decimal nPrecio);

            if (!successc || !successp)
                return 0M;

            decimal nMargen = (1 - (nCosto / nPrecio)) * 100;

            return nMargen;
        }

        public static decimal GetPrecioSDecimal(decimal precio, ICollection<ProductoImpuesto> productoImpuestos)
        {

            try
            {
                //bool successp = decimal.TryParse(precio, out decimal nPrecio);
                decimal acumulado = 0;

                //if (!successp)
                //    return 1M;

                foreach (var prodImp in productoImpuestos)
                {
                    using (var db = new DymContext())
                    {
                        var impuesto = db.Impuesto.FirstOrDefault(x => x.ImpuestoId == prodImp.ImpuestoId);
                        if (impuesto != null)
                            acumulado = acumulado + precio * ((decimal)impuesto.Tasa / 100);
                    }

                }

                return precio + acumulado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal. \n Ambiente GetPrecioSDecimal\n " + ex.Message);
            }

            return -1m;
        }


        public static string GetPrecioSstring(string precio, ICollection<ProductoImpuesto> productoImpuestos)
        {
            try
            {
                bool successp = decimal.TryParse(precio, out decimal nPrecio);
                decimal acumulado = 0;

                if (!successp)
                    return "1.000";

                foreach (var prodImp in productoImpuestos)
                {
                    using (var db = new DymContext())
                    {
                        var impuesto = db.Impuesto.FirstOrDefault(x => x.ImpuestoId == prodImp.ImpuestoId);
                        if (impuesto != null)
                            acumulado = acumulado + nPrecio * ((decimal)impuesto.Tasa / 100);
                    }

                }

                return FDinero(precio + acumulado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal. \n Ambiente GetPrecioSDecimal\n " + ex.Message);
            }

            return FDinero("1");
        }

        #endregion
    }
}
