using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.ReportDesigner;
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

namespace ReportDesignerProyect
{
    public partial class FrmReportDesigner : Form
    {

        //privado
        private ReporteController reporteController;
        private List<Parametro> parametros;
        private StiReport stiReport;
        private Reporte reporte;
        private bool procesado;
        private string sql;
        private DataSet ds;


        public FrmReportDesigner()
        {
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
            StiOptions.Engine.GlobalEvents.SavingReportInDesigner += new Stimulsoft.Report.Design.StiSavingObjectEventHandler(GlobalEvents_SavingReportInDesigner);
            StiOptions.Engine.GlobalEvents.LoadingReportInDesigner += new Stimulsoft.Report.Design.StiLoadingObjectEventHandler(GlobalEvents_LoadingReportInDesigner);
            //StiOptions.Engine.GlobalEvents.CreatingReportInDesigner += GlobalEvents_CreatingReportInDesigner;
            StiOptions.Engine.GlobalEvents.CreatingReportInDesigner += GlobalEvents_CreatingReportInDesigner1;


            reporteController = new ReporteController();
            parametros = new List<Parametro>();
            stiReport = new StiReport();
            reporte = new Reporte();
            sql = string.Empty;
            procesado = false;
            ds = null;
        }

        private void GlobalEvents_CreatingReportInDesigner1(object sender, Stimulsoft.Report.Design.StiCreatingObjectEventArgs e)
        {
            CrearNuevoReporte();

            if (procesado) e.Processed = true;
            e.Processed = false;
        }



        private void CrearNuevoReporte()
        {
            using (var form = new FrmNuevoReporte())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    reporte = form.Reporte;
                    stiReport = form.StiReport;
                    if (reporte == null || stiReport == null)
                        procesado = true;
                    else
                    {
                        ReportDesigner.Report = stiReport;
                    }
                }
            }
        }

        private void GlobalEvents_LoadingReportInDesigner(object sender, Stimulsoft.Report.Design.StiLoadingObjectEventArgs e)
        {
            e.Processed = true;

            StiReport report = new StiReport();
            report.Load("..\\..\\Reports\\SimpleList.mrt");
            ReportDesigner.Report = report;
        }

        private void GlobalEvents_SavingReportInDesigner(object sender, Stimulsoft.Report.Design.StiSavingObjectEventArgs e)
        {
            if (ReportDesigner.Report == null) return;
            e.Processed = true;


            Guardar();
        }

        private void Guardar()
        {
            try
            {
                reporte.Codigo = stiReport.SaveEncryptedReportToString(reporte.SecuenciaCifrado);
                if (reporte.ReporteId > 0)
                {
                    //Actualizacion
                    if (reporteController.Update(reporte))
                        Ambiente.Mensaje("Cambios guardados");
                }
                else
                {
                    //Nuevo
                    if (reporteController.InsertOne(reporte))
                        Ambiente.Mensaje("Cambios guardados");
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }
        }
    }
}
