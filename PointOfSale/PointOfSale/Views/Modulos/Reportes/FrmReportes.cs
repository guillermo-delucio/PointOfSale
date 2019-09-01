using PointOfSale.Controllers;
using PointOfSale.Controllers.EvironmentController;
using PointOfSale.Models;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Reportes
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
            InicializaReporteador();
        }

        private void InicializaReporteador()
        {
            Reports.corteController = new Controllers.CorteController();
            Reports.clienteController = new Controllers.ClienteController();
            Reports.compraController = new Controllers.CompraController();
            Reports.comprapController = new Controllers.ComprapController();
            Reports.flujoController = new Controllers.FlujoController();
            Reports.productoController = new Controllers.ProductoController();
            Reports.proveedorController = new Controllers.ProveedorController();
            Reports.ventaController = new Controllers.VentaController();
            Reports.ventapController = new Controllers.VentapController();
            Reports.empresaController = new Controllers.EmpresaController();
            Reports.empresa = Reports.empresaController.SelectTopOne();
        }

        private void BtnCierresCaja_Click(object sender, EventArgs e)
        {
            using (var form = new FrmParamData())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Reports.Cortes(FrmParamData.Inicial.Date, FrmParamData.Final.Date, form.TodasLasFechas);
                }
            }

        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            Reports.Clientes();
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            Reports.Compras();
        }


        private void BtnComprasXdia_Click(object sender, EventArgs e)
        {
            Reports.Compras();
        }

        private void BtnEgresosVSIngresos_Click(object sender, EventArgs e)
        {
            using (var form = new FrmParamData())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Reports.IngresosVsEgresos(FrmParamData.Inicial.Date, FrmParamData.Final.Date, form.TodasLasFechas);
                }
            }
        }

        private void BtnExistencias_Click(object sender, EventArgs e)
        {
            Reports.Existencias();
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            Reports.Productos();
        }

        private void BtnProdConPrecio_Click(object sender, EventArgs e)
        {
            Reports.ProductosConPrecio();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            Reports.Proveedores();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
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
                                    where compra.EstadoDocId.Equals("CON") && compra.CreatedAt.Date >= FrmParamData.Inicial.Date && compra.CreatedAt.Date <= FrmParamData.Final.Date
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

        private void BtnClientXMonXSal_Click(object sender, EventArgs e)
        {
            Reports.ClientesXmonedero();
        }

        private void BtnVentasACosto_Click(object sender, EventArgs e)
        {
            using (var form = new FrmParamData())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Reports.VentasAcosto(FrmParamData.Inicial.Date, FrmParamData.Final.Date, form.TodasLasFechas);
                }
            }
        }

        private void BtnVentasDelDia_Click(object sender, EventArgs e)
        {
            Reports.Ventas();
        }

        private void BtnVentasDetalladas_Click(object sender, EventArgs e)
        {
            Reports.VentasDetallada();
        }
    }
}
