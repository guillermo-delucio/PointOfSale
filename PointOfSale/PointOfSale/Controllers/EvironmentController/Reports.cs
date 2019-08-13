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
    public static class Reports
    {
        //Objetos
        public static StiReport report;
        public static Empresa empresa;
        public static string file;

        //Formatos
        public static string FEntradasXCompra = @"C:\Dympos\Formatos\EntradaXcompra.mrt";
        public static string FCierres = @"C:\Dympos\Formatos\Cierres.mrt";
        public static string FClientes = @"C:\Dympos\Formatos\Clientes.mrt";
        public static string FCompras = @"C:\Dympos\Formatos\Compras.mrt";

        //Controladores
        public static CorteController corteController;
        public static ClienteController clienteController;
        public static CompraController compraController;
        public static ComprapController comprapController;
        public static FlujoController flujoController;
        public static ProductoController productoController;
        public static ProveedorController proveedorController;
        public static VentaController ventaController;
        public static VentapController ventapController;
        public static EmpresaController empresaController;

        public static void EntradaXCompra(Compra compra, List<Comprap> partidas, bool abrir = true)
        {
            report = new StiReport();
            report.Load(FEntradasXCompra);

            report.RegBusinessObject("compra", "compra", compra);
            report.RegBusinessObject("partidas", "partidas", partidas);
            file = empresa.DirectorioReportes + "COMPRA " + compra.CompraId + ".PDF";

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

        public static void Compras(DateTime inicial, DateTime final, bool todasLasFechas)
        {
            try
            {
                List<Comprap> partidas = new List<Comprap>();
                using (var db = new DymContext())
                {
                    if (todasLasFechas)
                        partidas = comprapController.SelectAll();
                    else
                    {
                        var comp = db.Compra.Where(x => x.CreatedAt.Date >= inicial && x.CreatedAt.Date <= final).ToList();
                        foreach (var c in comp)
                        {
                            var dc = db.Comprap.Where(x => x.CompraId == c.CompraId).ToList();
                            foreach (var p in dc)
                            {
                                partidas.Add(p);
                            }
                        }
                    }

                }

                report = new StiReport();
                report.Load(FCompras);

                report.RegBusinessObject("partidas", "partidas", partidas);

                //Diseñar
                //report.Load(@RutaFormato);
                //report.RegData(ds);
                //report.Dictionary.Synchronize();
                // report.Compile();
                //report.Design();
                //report.Save(@"C:\Dympos\Formatos\EntradaXcompra.mrt");
                //report.Render(true);
                //report.Compile();
                report.Show(true);
            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }
        }

        public static void Clientes()
        {
            try
            {
                var clientes = clienteController.SelectAll();
                report = new StiReport();
                report.Load(FClientes);

                report.RegBusinessObject("clientes", "clientes", clientes);

                //Diseñar
                //report.Load(@RutaFormato);
                //report.RegData(ds);
                //report.Dictionary.Synchronize();
                // report.Compile();
                //report.Design();
                //report.Save(@"C:\Dympos\Formatos\EntradaXcompra.mrt");
                //report.Render(true);
                //report.Compile();
                report.Show(true);

            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }
        }

        public static void Cortes(DateTime inicial, DateTime final, bool todasLasFechas)
        {
            try
            {
                var corteController = new CorteController();
                List<Corte> cortes;
                using (var db = new DymContext())
                {
                    if (todasLasFechas)
                        cortes = corteController.SelectAll();
                    else
                        cortes = db.Corte.Where(x => x.CreatedAt.Date >= inicial && x.CreatedAt.Date <= final).ToList();
                }

                report = new StiReport();
                report.Load(FCierres);

                report.RegBusinessObject("cortes", "cortes", cortes);

                //Diseñar
                //report.Load(@RutaFormato);
                //report.RegData(ds);
                //report.Dictionary.Synchronize();
                // report.Compile();
                //report.Design();
                //report.Save(@"C:\Dympos\Formatos\EntradaXcompra.mrt");
                //report.Render(true);
                //report.Compile();
                report.Show(true);
            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }

        }
    }
}
