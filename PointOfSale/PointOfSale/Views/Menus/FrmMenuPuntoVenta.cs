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
                var file = @"C:\Dympos\Cortes\CORTE " + DateTime.Now.ToString("dd.MM.yyyy hh.mm.ss") + ".pdf";

                //Mostrar
                //report.RegData(Ambiente.DS("select V.CreatedAt, V.TipoDocId, C.RazonSocial, V.Unidades, V.EstadoDocId,v.SubTotal, V.Impuesto, V.Total from Venta v join Cliente  C  on V.ClienteId = C.ClienteId Where V.Cortada = 0 and EstadoDocId = 'CON'"));
                //report.Load(@"C:\Dympos\Formatos\Corte.mrt");
                //report.Compile();
                //report["userId"] = Ambiente.LoggedUser.UsuarioId;
                //report["hinicial"] = ((DateTime)ventaini.CreatedAt).ToShortTimeString().ToUpper();
                //report["hfinal"] = ((DateTime)ventafin.CreatedAt).ToShortTimeString().ToUpper();
                //report.Render();
                //report.Show(true);



                //Diseñar
                //report.RegData(Ambiente.DS("select V.CreatedAt, V.TipoDocId, C.RazonSocial, V.Unidades, V.EstadoDocId,v.SubTotal, V.Impuesto, V.Total from Venta v join Cliente  C  on V.ClienteId = C.ClienteId Where V.Cortada = 0 and EstadoDocId = 'CON'"));
                //report.Load(@"C:\Dympos\Formatos\Corte.mrt");
                //report.Compile();
                //report["userId"] = Ambiente.LoggedUser.UsuarioId;
                //report["hinicial"] = ((DateTime)ventaini.CreatedAt).ToShortTimeString().ToUpper();
                //report["hfinal"] = ((DateTime)ventafin.CreatedAt).ToShortTimeString().ToUpper();
                //report.Render();
                //report.Design();


                //Exportar

                report.Load(@"C:\Dympos\Formatos\Corte.mrt");
                report.RegData(Ambiente.DS("select V.CreatedAt, V.TipoDocId, C.RazonSocial, V.Unidades, V.EstadoDocId,v.SubTotal, V.Impuesto, V.Total from Venta v join Cliente  C  on V.ClienteId = C.ClienteId Where V.Cortada = 0 and EstadoDocId = 'CON'"));
                report.Render(false);

                StiReport reporte = new StiReport();
                reporte.Render(false);
                reporte.RenderedPages.Clear();

                foreach (StiPage page in report.RenderedPages)
                    reporte.RenderedPages.Add(page);

                reporte.ExportDocument(StiExportFormat.Pdf, file);
                System.Diagnostics.Process.Start(file);

            }

        }


    }
}
