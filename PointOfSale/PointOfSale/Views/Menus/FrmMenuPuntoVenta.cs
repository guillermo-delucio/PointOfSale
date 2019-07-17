using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.PuntoVenta;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System;
using System.Data;
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

            StiReport report = new StiReport();
            report.Load(@"C:\Dympos\Formatos\Corte.mrt");
            var ds = new DataSet("DS");
            ds.Tables.Add(Ambiente.DT("select  v.CreatedAt, c.RazonSocial,v.Unidades, v.EstadoDocId, v.SubTotal, v.Impuesto, v.Total from Venta v join Cliente c on v.ClienteId = c.ClienteId", "v"));
            report.RegData(ds);


            report.Render(false);
            var file = @"C:\Dympos\Corte.PDF";
            report.ExportDocument(StiExportFormat.Pdf, file);
            System.Diagnostics.Process.Start(file);

        }

        private void BtnTicketAFactura_Click(object sender, EventArgs e)
        {
            var o = new FrmTicketFactura();
            o.Show();

        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            var o = new FrmFacturas();
            o.Show();
        }
    }
}
