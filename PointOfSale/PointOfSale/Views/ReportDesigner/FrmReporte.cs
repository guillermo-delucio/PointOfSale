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
    public partial class FrmReporte : Form
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
        private bool modoCreate;

        public FrmReporte(bool boolcreate)
        {
            InitializeComponent();
            Inicializar();
            modoCreate = boolcreate;

        }

        public FrmReporte(bool boolcreate, Reporte reporte)
        {
            InitializeComponent();
            Inicializar();
            this.reporte = reporte;
            modoCreate = boolcreate;
            if (reporte != null)
            {
                Text = "ACTUALIZANDO " + reporte.Nombre;
                TxtDescripcion.Text = reporte.Descripcion;
                TxtNomre.Text = reporte.Nombre;
                TxtQuery.Text = reporte.Sql;
                TxtQuery.Rtf = reporte.Rtf;

            }
            else
                Ambiente.Mensaje("Nigun reporte seleccionado");

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
            if (TxtDescripcion.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Debe informar la descripcion");
                return;
            }
            if (TxtQuery.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Debe informar el query");
                return;
            }

            ProbarSql();
            if (reporteController.TestQuery(sql))
            {
                try
                {
                    #region Nuevo Reporte
                    if (modoCreate)
                    {
                        //Inicializa objetos
                        reporte.SecuenciaCifrado = reporteController.GeneraSecuencia();
                        reporte.Sql = TxtQuery.Text.Trim();
                        reporte.Rtf = TxtQuery.Rtf;
                        reporte.Nombre = TxtNomre.Text.Trim();
                        reporte.Descripcion = TxtDescripcion.Text.Trim();
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
                    else
                    {
                        #region Actualizar Reporte
                        reporte.Sql = TxtQuery.Text.Trim();
                        reporte.Rtf = TxtQuery.Rtf;
                        reporte.Nombre = TxtNomre.Text.Trim();
                        reporte.Descripcion = TxtDescripcion.Text.Trim();
                        reporte.Parametrizado = parametros.Count > 0 ? true : false;
                        reporte.Codigo = stiReport.SaveEncryptedReportToString(reporte.SecuenciaCifrado);
                        if (reporteController.Update(reporte))
                            DialogResult = DialogResult.OK;
                        #endregion
                    }
                    #endregion



                }
                catch (Exception ex)
                {
                    Ambiente.Mensaje(ex.ToString());
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
