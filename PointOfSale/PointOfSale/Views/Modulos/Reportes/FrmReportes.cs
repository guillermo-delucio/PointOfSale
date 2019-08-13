using PointOfSale.Controllers.EvironmentController;
using System;
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
                    Reports.Cortes(form.Inicial, form.Final, form.TodasLasFechas);
                }
            }

        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            Reports.Clientes();
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {
            using (var form = new FrmParamData())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Reports.Compras(form.Inicial, form.Final, form.TodasLasFechas);
                }
            }
        }

        private void BtnComprasXdia_Click(object sender, EventArgs e)
        {
            using (var form = new FrmParamData())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Reports.Compras(form.Inicial, form.Final, form.TodasLasFechas);
                }
            }
        }

        private void BtnEgresosVSIngresos_Click(object sender, EventArgs e)
        {
            using (var form = new FrmParamData())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Reports.IngresosVsEgresos(form.Inicial, form.Final, form.TodasLasFechas);
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
    }
}
