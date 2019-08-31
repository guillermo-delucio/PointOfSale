using PointOfSale.Models;
using PointOfSale.Views.Modulos.Reportes;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static string FIngresosVsEgresos = @"C:\Dympos\Formatos\IngresosVsEgresos.mrt";
        public static string FExistencias = @"C:\Dympos\Formatos\Existencias.mrt";
        public static string FMCMPS = @"C:\Dympos\Formatos\MCMPS.mrt";
        public static string FProductos = @"C:\Dympos\Formatos\Productos.mrt";
        public static string FProductoXPrecio = @"C:\Dympos\Formatos\ProductoXPrecio.mrt";
        public static string FProveedores = @"C:\Dympos\Formatos\Proveedores.mrt";
        public static string FVentasAcosto = @"C:\Dympos\Formatos\VentasAcosto.mrt";
        public static string FClientesXmonedero = @"C:\Dympos\Formatos\ClientesXmonedero.mrt";
        public static string FVentas = @"C:\Dympos\Formatos\Ventas.mrt";
        public static string FVentasDetallada = @"C:\Dympos\Formatos\VentasDetallada.mrt";


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


            report.Render(false);
            report.ExportDocument(StiExportFormat.Pdf, file);
            if (abrir)
                Process.Start(file);

        }

        public static void Compras()
        {

            StiReport report = new StiReport();

            try
            {
                using (var form = new FrmParamData())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {

                        using (var db = new DymContext())
                        {
                            if (form.TodasLasFechas)
                            {
                                var q = from compra in db.Compra
                                        join comprap in db.Comprap on compra.CompraId equals comprap.CompraId
                                        where compra.EstadoDocId.Equals("CON")
                                        select new
                                        {
                                            compra.CompraId,
                                            comprap.ProductoId,
                                            comprap.Descripcion,
                                            comprap.Cantidad,
                                            comprap.ImporteImpuesto1,
                                            comprap.ImporteImpuesto2,
                                            comprap.PrecioCompra,
                                            comprap.Total,
                                            compra.CreatedAt,
                                            compra.CreatedBy
                                        };
                                report.Load(Reports.FVentas);
                                report.Dictionary.DataSources.Clear();
                                report.RegBusinessObject("partidas", "partidas", q.ToList());
                                report.Dictionary.Synchronize();
                                //report.Design();
                                //report.Save(Reports.FCompras);
                                report.Show(true);
                            }
                            else
                            {
                                var q = from compra in db.Compra
                                        join comprap in db.Comprap on compra.CompraId equals comprap.CompraId
                                        where compra.EstadoDocId.Equals("CON") && compra.CreatedAt.Date >= form.Inicial && compra.CreatedAt.Date <= form.Final
                                        select new
                                        {
                                            compra.CompraId,
                                            comprap.ProductoId,
                                            comprap.Descripcion,
                                            comprap.Cantidad,
                                            comprap.ImporteImpuesto1,
                                            comprap.ImporteImpuesto2,
                                            comprap.Total,
                                            comprap.PrecioCompra,
                                            compra.CreatedAt,
                                            compra.CreatedBy
                                        };
                                report.Load(Reports.FVentas);
                                report.Dictionary.DataSources.Clear();
                                report.RegBusinessObject("partidas", "partidas", q.ToList());
                                report.Dictionary.Synchronize();
                                //report.Design();
                                //report.Save(Reports.FCompras);
                                report.Show(true);
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.Message);
            }

        }

        public static void ClientesXmonedero()
        {
            try
            {
                report = new StiReport();

                report.Load(FClientesXmonedero);
                report.Compile();
                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                report.RegBusinessObject("clientes", clienteController.SelectAllOrderByMonedero());

                report.Show();



            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }
        }

        internal static void VentasDetallada()
        {
            StiReport report = new StiReport();

            try
            {
                using (var form = new FrmParamData())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {

                        using (var db = new DymContext())
                        {
                            if (form.TodasLasFechas)
                            {
                                var q =
                                       from v in db.Venta
                                       join vp in db.Ventap on v.VentaId equals vp.VentaId
                                       join p in db.Producto on vp.ProductoId equals p.ProductoId
                                       where v.EstadoDocId.Equals("CON") && v.Anulada == false
                                       select new
                                       {
                                           v.NoRef,
                                           vp.ProductoId,
                                           vp.Cantidad,
                                           vp.Descripcion,
                                           v.VentaId,
                                           v.CreatedAt,
                                           v.CreatedBy,
                                           vp.SubTotal,
                                           Impuesto = (vp.ImporteImpuesto1 + vp.ImporteImpuesto2),
                                           vp.Total
                                       };
                                report.Load(FVentasDetallada);
                                report.Compile();
                                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                                report["inicial"] = form.Inicial;
                                report["final"] = form.Final;
                                report.Dictionary.DataSources.Clear();
                                report.RegBusinessObject("ventas", "ventas", q.ToList());
                                report.Dictionary.Synchronize();

                                report.Design();
                                report.Save(FVentasDetallada);
                                //report.Show(true);
                            }
                            else
                            {
                                var q =
                                       from v in db.Venta
                                       join vp in db.Ventap on v.VentaId equals vp.VentaId
                                       join p in db.Producto on vp.ProductoId equals p.ProductoId
                                       where v.EstadoDocId.Equals("CON") && v.Anulada == false
                                       select new
                                       {
                                           v.NoRef,
                                           vp.ProductoId,
                                           vp.Cantidad,
                                           vp.Descripcion,
                                           v.VentaId,
                                           v.CreatedAt,
                                           v.CreatedBy,
                                           vp.SubTotal,
                                           Impuesto = (vp.ImporteImpuesto1 + vp.ImporteImpuesto2),
                                           vp.Total
                                       };
                                report.Load(FVentasDetallada);
                                report.Compile();
                                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                                report["inicial"] = form.Inicial;
                                report["final"] = form.Final;
                                report.Dictionary.DataSources.Clear();
                                report.RegBusinessObject("ventas", "ventas", q.ToList());
                                report.Dictionary.Synchronize();

                                report.Design();
                                report.Save(FVentasDetallada);
                                //report.Show(true);
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.Message);
            }
        }

        internal static void Ventas()
        {
            StiReport report = new StiReport();

            try
            {
                using (var form = new FrmParamData())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {

                        using (var db = new DymContext())
                        {
                            if (form.TodasLasFechas)
                            {
                                var q =
                                        from v in db.Venta
                                        join c in db.Cliente on v.ClienteId equals c.ClienteId
                                        where v.EstadoDocId.Equals("CON") && v.Anulada == false
                                        select new
                                        {
                                            v.VentaId,
                                            c.RazonSocial,
                                            c.Negocio,
                                            v.CreatedAt,
                                            v.CreatedBy,
                                            v.SubTotal,
                                            v.Impuesto,
                                            v.Total,
                                            v.TipoDocId,
                                            v.NoRef
                                        };
                                report.Load(FVentas);
                                report.Compile();
                                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                                report["inicial"] = form.Inicial;
                                report["final"] = form.Final;
                                report.Dictionary.DataSources.Clear();
                                report.RegBusinessObject("ventas", "ventas", q.ToList());
                                report.Dictionary.Synchronize();

                                //report.Design();
                                //report.Save(FVentas);
                                report.Show(true);
                            }
                            else
                            {
                                var q =
                                         from v in db.Venta
                                         join c in db.Cliente on v.ClienteId equals c.ClienteId
                                         where v.EstadoDocId.Equals("CON") && v.Anulada == false &&
                                         v.CreatedAt.Date >= form.Inicial && v.CreatedAt.Date <= form.Final
                                         select new
                                         {
                                             v.VentaId,
                                             c.RazonSocial,
                                             c.Negocio,
                                             v.CreatedAt,
                                             v.CreatedBy,
                                             v.SubTotal,
                                             v.Impuesto,
                                             v.Total,
                                             v.TipoDocId,
                                             v.NoRef
                                         };
                                report.Load(FVentas);
                                report.Compile();
                                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                                report["inicial"] = form.Inicial;
                                report["final"] = form.Final;
                                report.Dictionary.DataSources.Clear();
                                report.RegBusinessObject("ventas", "ventas", q.ToList());
                                report.Dictionary.Synchronize();

                                //report.Design();
                                //report.Save(FVentas);
                                report.Show(true);
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.Message);
            }
        }

        internal static void VentasAcosto(DateTime inicial, DateTime final, bool todasLasFechas)
        {
            report = new StiReport();


            List<Producto> productos;
            List<Ventap> partidas;

            using (var db = new DymContext())
            {

                if (todasLasFechas)
                {
                    var q = from v in db.Venta
                            join vp in db.Ventap on v.VentaId equals vp.VentaId
                            where (v.Anulada == false && !v.EstadoDocId.Equals("PEN"))
                            select vp;
                    partidas = q.ToList();
                    productos = db.Producto.ToList();
                }

                else
                {
                    var q = from v in db.Venta
                            join vp in db.Ventap on v.VentaId equals vp.VentaId
                            where (v.Anulada == false && !v.EstadoDocId.Equals("PEN") && v.CreatedAt.Date >= inicial.Date && v.CreatedAt.Date <= final.Date)
                            select vp;
                    partidas = q.ToList();
                    productos = db.Producto.ToList();
                }
            }
            decimal subtotalvp = 0, impuestovp = 0, totalvp = 0;
            decimal subtotalcp = 0, impuestocp = 0, totalcp = 0;

            decimal subtotalvt = 0, impuestovt = 0, totalvt = 0;
            decimal subtotalct = 0, impuestoct = 0, totalct = 0;

            foreach (var p in partidas)
            {
                var prod = productoController.SelectOne(p.ProductoId.Trim());

                //Importe parcial venta
                subtotalvp = p.SubTotal;
                impuestovp = p.ImporteImpuesto1 + p.ImporteImpuesto2;
                totalvp = subtotalvp + impuestovp;

                //Importe pacial costo
                impuestocp = 0;
                subtotalcp = p.Cantidad * prod.PrecioCompra;
                impuestocp = subtotalcp * Ambiente.GetTasaImpuesto(prod.Impuesto1Id);
                impuestocp += subtotalcp * Ambiente.GetTasaImpuesto(prod.Impuesto2Id);
                totalcp = subtotalcp + impuestocp;

                //Sumar totales

                subtotalvt += subtotalvp;
                impuestovt += impuestovp;
                totalvt += totalvp;

                subtotalct += subtotalcp;
                impuestoct += impuestocp;
                totalct += totalcp;
            }

            report.Load(@"C:\Dympos\Formatos\VentasAcosto.mrt");
            report.Compile();
            report["creador"] = Ambiente.LoggedUser.UsuarioId;
            report["subv"] = subtotalvt;
            report["impv"] = impuestovt;
            report["totv"] = totalvt;
            report["subc"] = subtotalct;
            report["impc"] = impuestoct;
            report["totc"] = totalct;
            report["utilidad"] = totalvt - totalct;
            if (!todasLasFechas)
            {
                report["inicial"] = inicial.ToString("dd-MM-yyyy");
                report["final"] = final.ToString("dd-MM-yyyy");
            }

            report.Show();
        }

        public static void Proveedores()
        {
            try
            {
                report = new StiReport();
                report.Load(@"C:\Dympos\Formatos\Proveedores.mrt");
                report.Compile();
                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                report.RegBusinessObject("proveedores", proveedorController.SelectAll());
                // report.Dictionary.Synchronize();
                //report.Render();
                //report.Design();
                //report.Save(@"C:\Dympos\Formatos\Proveedores.mrt");
                report.Show();



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
                report = new StiReport();


                report.Load(@"C:\Dympos\Formatos\ProductoXprecio.mrt");
                report.Compile();
                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                report.RegBusinessObject("productos", productoController.SelectAll());
                report.Dictionary.Synchronize();
                //report.Render();
                // report.Design();
                //report.Save(@"C:\Dympos\Formatos\ProductoXprecio.mrt");
                report.Show();


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
                report = new StiReport();

                report.Load(@"C:\Dympos\Formatos\Productos.mrt");
                report.Compile();
                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                report.RegBusinessObject("productos", productoController.SelectAll());
                report.Dictionary.Synchronize();
                //report.Render();
                //report.Design();
                //report.Save(@"C:\Dympos\Formatos\Productos.mrt");
                report.Show();


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
                report = new StiReport();

                List<Producto> productos;
                using (var db = new DymContext())
                {
                    productos = db.Producto.ToList();
                }
                report.Load(@"C:\Dympos\Formatos\Existencias.mrt");
                report.Compile();
                report["creador"] = Ambiente.LoggedUser.UsuarioId;
                report.RegBusinessObject("productos", productos);
                report.Dictionary.Synchronize();
                //report.Render();
                //report.Design();
                //report.Save(@"C:\Dympos\Formatos\Existencias.mrt");
                report.Show();

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
