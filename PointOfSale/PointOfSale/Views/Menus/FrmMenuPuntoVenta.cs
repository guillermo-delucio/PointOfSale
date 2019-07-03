using PointOfSale.Controllers;
using PointOfSale.Models;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale.Views.Menus
{
    public partial class FrmMenuPuntoVenta : Form
    {
        public FrmMenuPuntoVenta()
        {
            InitializeComponent();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            var o = new PointOfSale.Views.Modulos.PuntoVenta.PointOfSale();
            o.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {

            Venta ventaini;
            Venta ventafin;
            using (var db = new DymContext())
            {
                ventaini = db.Venta.Where(x => x.Cortada == false && x.EstadoDocId.Equals("CON")).OrderBy(x => x.CreatedAt).FirstOrDefault();
                ventafin = db.Venta.Where(x => x.Cortada == false && x.EstadoDocId.Equals("CON")).OrderByDescending(x => x.CreatedAt).FirstOrDefault();
            }

            if (ventafin != null && ventaini != null)
            {
                StiReport report = new StiReport();
            }

        }


    }
}
