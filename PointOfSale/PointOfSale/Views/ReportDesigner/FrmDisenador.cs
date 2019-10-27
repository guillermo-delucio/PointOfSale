using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.ReportDesigner
{
    public partial class FrmDisenador : Form
    {
        //Objetos
        private ReporteController reporteController;
        List<Parametro> parametros;

        private StiReport stireport;
        private Reporte reporte;
        private DataSet ds;
        private string s;


        public FrmDisenador()
        {
            InitializeComponent();
            reporteController = new ReporteController();
        }

        #region Metodos



        private void LlenarDatos()
        {
            if (reporte == null)
            {
                Ambiente.Mensaje("Proceso abortado, el reporte no se encontró");
                return;
            }
            TxtReporte.Text = reporte.Nombre;
            TxtReporteSeleccionad.Text = reporte.Nombre;
            TxtSecuenciaEnc.Text = reporte.SecuenciaCifrado;
            TxtQuery.Text = reporte.Sql;
            ChkParam.Checked = reporte.Parametrizado;
        }
        private void Nuevo()
        {
            TxtSecuenciaEnc.Text = reporteController.GeneraSecuencia();

            if (TxtReporte.Text.Trim().Length == 0 || TxtSecuenciaEnc.Text.Trim().Length == 0 || TxtQuery.Text.Trim().Length == 0)
            {
                MessageBox.Show("Complete los campos");
                return;
            }

            try
            {
                //Inicializa objetos
                stireport = new StiReport();
                reporte = new Reporte();

                reporte.SecuenciaCifrado = TxtSecuenciaEnc.Text.Trim();
                reporte.Sql = TxtQuery.Text.Trim();
                reporte.Nombre = TxtReporte.Text.Trim();
                reporte.Parametrizado = ChkParam.Checked;

                if (reporte.Parametrizado)
                {
                    parametros = reporteController.DeSerializar(TxtQuery.Text.Trim());
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
                }

                s = reporteController.Serializar(TxtQuery.Text.Trim(), parametros);
                ds = reporteController.GetDataSet(s);

                //Add data to datastore
                stireport.RegData("DS", "DS", ds);
                //Fill dictionary
                stireport.Dictionary.Synchronize();
                stireport.Design();
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }
        }
        private void Guardar()
        {
            if (Ambiente.Pregunta("Quieres Guardar los cambios"))
            {
                if (reporte != null && stireport != null)
                {
                    reporte.Nombre = TxtReporte.Text;
                    reporte.SecuenciaCifrado = TxtSecuenciaEnc.Text.Trim();
                    reporte.Sql = TxtQuery.Text;
                    reporte.Codigo = stireport.SaveEncryptedReportToString(reporte.SecuenciaCifrado);
                    reporte.Parametrizado = ChkParam.Checked;


                    if (reporte.ReporteId == 0)
                        reporteController.InsertOne(reporte);
                    else
                        reporteController.Update(reporte);

                    Ambiente.Mensaje("Cambios guardados");
                }
                else
                {
                    Ambiente.Mensaje("No hay nada que guardar");
                }
            }
        }

        private void Visualizar()
        {
            if (reporte == null)
            {
                Ambiente.Mensaje("Nada que mostrar, primero selecciona un reporte");
                return;
            }

            try
            {
                //Inicializa objetos
                stireport = new StiReport();
                reporte.SecuenciaCifrado = TxtSecuenciaEnc.Text.Trim();
                reporte.Sql = TxtQuery.Text.Trim();
                reporte.Nombre = TxtReporte.Text.Trim();
                reporte.Parametrizado = ChkParam.Checked;

                if (reporte.Parametrizado)
                {
                    parametros = reporteController.DeSerializar(TxtQuery.Text.Trim());
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
                }

                s = reporteController.Serializar(TxtQuery.Text.Trim(), parametros);
                ds = reporteController.GetDataSet(s);

                //Add data to datastore
                stireport.LoadEncryptedReportFromString(reporte.Codigo, reporte.SecuenciaCifrado);
                stireport.RegData("DS", "DS", ds);
                //Fill dictionary
                stireport.Dictionary.Synchronize();
                stireport.Show();
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }
        }
        private void Disenar()
        {
            if (reporte == null)
            {
                Ambiente.Mensaje("Nada que mostrar, primero selecciona un reporte");
                return;
            }

            try
            {
                //Inicializa objetos
                stireport = new StiReport();
                reporte.SecuenciaCifrado = TxtSecuenciaEnc.Text.Trim();
                reporte.Sql = TxtQuery.Text.Trim();
                reporte.Nombre = TxtReporte.Text.Trim();
                reporte.Parametrizado = ChkParam.Checked;

                if (reporte.Parametrizado)
                {
                    parametros = reporteController.DeSerializar(TxtQuery.Text.Trim());
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
                }

                s = reporteController.Serializar(TxtQuery.Text.Trim(), parametros);
                ds = reporteController.GetDataSet(s);

                //Add data to datastore
                stireport.LoadEncryptedReportFromString(reporte.Codigo, reporte.SecuenciaCifrado);
                stireport.RegData("DS", "DS", ds);
                //Fill dictionary
                stireport.Dictionary.Synchronize();
                stireport.Design();
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }
        }
        private void Salir()
        {
            Guardar();
            Close();
        }
        #endregion

        #region Eventos


        private void TxtReporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtReporte.Text.Trim(), (int)Ambiente.TipoBusqueda.Reportes))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        reporte = form.Reporte;
                        LlenarDatos();
                    }
                }
            }
        }
        private void BtnVisualizar_Click(object sender, EventArgs e)
        {
            Visualizar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void BtnDisenar_Click(object sender, EventArgs e)
        {
            Disenar();
        }
        #endregion
    }
}
