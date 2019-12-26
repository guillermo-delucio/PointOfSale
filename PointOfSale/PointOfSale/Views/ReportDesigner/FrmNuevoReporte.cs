using PointOfSale.Controllers;
using PointOfSale.Models;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.ReportDesigner
{
    public partial class FrmNuevoReporte : Form
    {
        //propiedes publicas
        public Reporte Reporte { get; set; }
        public StiReport StiReport { get; set; }

        //privado
        private ReporteController reporteController;
        private List<Parametro> parametros;
        private StiReport stiReport;
        private Reporte reporte;
        private string sql;
        private DataSet ds;

        public FrmNuevoReporte()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            reporteController = new ReporteController();
            parametros = new List<Parametro>();
            stiReport = new StiReport();
            reporte = new Reporte();
            sql = string.Empty;
            ds = null;
        }



        private void ProbarSql()
        {
            sql = TxtQuery.Text.Trim();
            parametros = new List<Parametro>();
            parametros = reporteController.DeSerializar(sql);

            if (parametros.Count > 0)
            {
                foreach (var p in parametros)
                {
                    using (var form = new FrmSolicitudParam(p.Clave))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            p.Valor = form.Valor.Trim();
                        }
                    }
                }
                sql = reporteController.Serializar(sql, parametros);
            }
            if (reporteController.TestQuery(sql))
                Ambiente.Mensaje("SQL Correcto!");
        }

        private void Guardar()
        {
            if (TxtNomre.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Debe informar el nombre");
                return;
            }
            if (TxtQuery.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Debe informar el query");
                return;
            }
            if (reporteController.TestQuery(sql))
            {
                try
                {
                    //Inicializa objetos

                    reporte.SecuenciaCifrado = reporteController.GeneraSecuencia();
                    reporte.Sql = TxtQuery.Text.Trim();
                    reporte.Rtf = TxtQuery.Rtf;
                    reporte.Nombre = TxtNomre.Text.Trim();
                    reporte.Parametrizado = parametros.Count > 0 ? true : false;
                    ds = reporteController.GetDataSet(sql);

                    //Add data to datastore
                    stiReport.RegData("DS", "DS", ds);
                    //Fill dictionary
                    stiReport.Dictionary.Synchronize();

                    //Generar el codigo del reporte 
                    reporte.Codigo = stiReport.SaveEncryptedReportToString(reporte.SecuenciaCifrado);

                    Reporte = reporte;
                    StiReport = stiReport;
                    DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    Ambiente.Mensaje(ex.Message);
                }
            }
            else
                Ambiente.Mensaje("Proceso abortado, SQL incorrecto");
        }

        private void Salir()
        {
          
        }
        private void BtnProbarSql_Click(object sender, EventArgs e)
        {
            ProbarSql();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }
    }
}
