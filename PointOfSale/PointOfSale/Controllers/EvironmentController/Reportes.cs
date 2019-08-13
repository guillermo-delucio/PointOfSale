using PointOfSale.Models;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers.EvironmentController
{
    public static class Reportes
    {
        public static string FEntradasXCompra = @"C:\Dympos\Formatos\EntradaXcompra.mrt";
        public static StiReport report;


        public static void EntradaXCompra(Compra compra, List<Comprap> partidas, Empresa empresa, bool abrir = true)
        {
            report = new StiReport();
            report.Load(FEntradasXCompra);

            report.RegBusinessObject("compra", "compra", compra);
            report.RegBusinessObject("partidas", "partidas", partidas);

            var file = empresa.DirectorioReportes + "COMPRA " + compra.CompraId + ".PDF";

            //Diseñar
            //report.Load(@RutaFormato);
            //report.RegData(ds);
            //report.Dictionary.Synchronize();
            // report.Compile();
            //report.Design();
            //report.Save(@"C:\Dympos\Formatos\EntradaXcompra.mrt");
            report.Render(false);
            report.ExportDocument(StiExportFormat.Pdf, file);
            if (abrir)
                Process.Start(file);
            
        }

    }
}
