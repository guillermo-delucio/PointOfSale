using PointOfSale.Models;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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

        public static string FIngresosVsEgresos = @"C:\Dympos\Formatos\IngresosVsEgresos.mrt";
        public static string FExistencias = @"C:\Dympos\Formatos\Existencias.mrt";
        public static string FMCMPS = @"C:\Dympos\Formatos\MCMPS.mrt";
        public static string FProductos = @"C:\Dympos\Formatos\Productos.mrt";
        public static string FProductoXPrecio = @"C:\Dympos\Formatos\ProductoXPrecio.mrt";
        public static string FProveedores = @"C:\Dympos\Formatos\Proveedores.mrt";
        public static string FVentasAcosto = @"C:\Dympos\Formatos\VentasAcosto.mrt";
        public static string FVentasXPeriodo = @"C:\Dympos\Formatos\VentasXPeriodo.mrt";

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

        internal static void ProductosConPrecio()
        {
            try
            {
                var ds = new DataSet();
                var Sql = "";
                Sql += " select ";
                Sql += " ProductoId clave,";
                Sql += " Descripcion,";
                Sql += " PrecioCompra pcompra,";
                Sql += " Precio1,";
                Sql += " Precio2,";
                Sql += " Precio3,";
                Sql += " Precio4,";
                Sql += " Utilidad1,";
                Sql += " Utilidad2,";
                Sql += " Utilidad3,";
                Sql += " Utilidad4";
                Sql += " from Producto order by Descripcion";

                ds.Tables.Add(Ambiente.DT(Sql, "DS"));

                //Preview
                report = new StiReport();
                report.Load(FProductoXPrecio);
                report.RegData(ds);
                report.Show(true);

                //Diseñar
                //report = new StiReport();
                //report.Load(FProductoXPrecio);
                //report.Dictionary.Clear();
                //report.RegData(ds);
                //report.Dictionary.Synchronize();
                //report.Design();
                //report.Save(FProductoXPrecio);


            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }
        }

        public static void Productos()
        {
            try
            {
                var ds = new DataSet();
                var Sql = "";
                Sql += " select ";
                Sql += " p.ProductoId clave,";
                Sql += " p.Descripcion,";
                Sql += " p.Contenido cupo,";
                Sql += " p.PresentacionId presentacion,";
                Sql += " p.Unidades,";
                Sql += " p.PrecioCompra pcompra,";
                Sql += " p.Precio1,";
                Sql += " p.Precio2";
                Sql += " from Producto p";
                Sql += " join Laboratorio l on p.LaboratorioId = l.LaboratorioId";
                Sql += " join Categoria c on p.CategoriaId = c.CategoriaId";
                Sql += " join Presentacion pr on p.PresentacionId = pr.PresentacionId";
                ds.Tables.Add(Ambiente.DT(Sql, "DS"));

                //Preview
                report = new StiReport();
                report.Load(FProductos);
                report.RegData(ds);
                report.Show(true);

                //Diseñar
                //report = new StiReport();
                //report.Load(FProductos);
                //report.Dictionary.Clear();
                //report.RegData(ds);
                //report.Dictionary.Synchronize();
                //report.Design();
                //report.Save(FProductos);


            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }
        }

        public static void Existencias()
        {
            try
            {
                var ds = new DataSet();
                var Sql = "";
                Sql += "  select ";
                Sql += " p.ProductoId, ";
                Sql += " p.Descripcion,";
                Sql += " l.Nombre laboraroio,";
                Sql += " c.Nombre categoria,";
                Sql += " p.Stock,";
                Sql += " p.Impuesto1Id,";
                Sql += " p.Impuesto2Id";
                Sql += " from Producto p";
                Sql += " join Laboratorio l on p.LaboratorioId = l.LaboratorioId";
                Sql += " join Categoria c on p.CategoriaId = c.CategoriaId";
                ds.Tables.Add(Ambiente.DT(Sql, "pe"));

                report = new StiReport();
                report.Load(FExistencias);
                report.RegData(ds);
                report.Show(true);

            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }
        }

        internal static void IngresosVsEgresos(DateTime inicial, DateTime final, bool todasLasFechas)
        {
            try
            {
                report = new StiReport();
                report.Load(FIngresosVsEgresos);

                List<Flujo> ingresos = new List<Flujo>();
                List<Flujo> egresos = new List<Flujo>();

                using (var db = new DymContext())
                {
                    if (todasLasFechas)
                    {
                        ingresos = db.Flujo.Where(x => x.EntradaSalida.Equals("E")).ToList();
                        egresos = db.Flujo.Where(x => x.EntradaSalida.Equals("S")).ToList();

                    }
                    else
                    {
                        ingresos = db.Flujo.Where(x => x.EntradaSalida.Equals("E") && (x.CreatedAt.Date >= inicial && x.CreatedAt <= final)).ToList();
                        egresos = db.Flujo.Where(x => x.EntradaSalida.Equals("S") && (x.CreatedAt.Date >= inicial && x.CreatedAt <= final)).ToList();

                    }

                }


                report.RegBusinessObject("ingresos", "ingresos", ingresos);
                report.RegBusinessObject("egresos", "egresos", egresos);
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
