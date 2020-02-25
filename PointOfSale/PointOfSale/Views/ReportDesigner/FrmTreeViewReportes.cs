using PointOfSale.Controllers;
using PointOfSale.Models;
using Stimulsoft.Report;
using Stimulsoft.Report.Design;
using Stimulsoft.Report.Dictionary;
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
    public partial class FrmTreeViewReportes : Form
    {
        private InformeController informeController;
        private InformeCategoriaController informeCategoriaController;
        private InformeParametroController informeParametroController;

        private Informe informe;
        private InformeCategoria informeCategoria;
        private InformeParametro informeParametro;

        private List<InformeParametro> parametros;
        private List<InformeCategoria> categorias;
        private List<Informe> informes;

        private string nodo;

        //Stimulsoft
        private StiDesigner designer;
        private StiReport stiReport;


        public FrmTreeViewReportes()
        {
            InitializeComponent();
            Inicializa();
            LlenaTreeView();

        }

        private void LlenaTreeView()
        {

            MyTreeView.Nodes.Clear();
            MyTreeView.ImageList = Ambiente.ImageList;
            categorias = informeCategoriaController.SelectAll();

            TreeNode root = new TreeNode("Reportes");
            root.ImageIndex = 0;
            root.SelectedImageIndex = 0;

            foreach (var c in categorias)
            {
                var nc = new TreeNode();
                nc.Name = c.Nombre;
                nc.Text = c.Nombre;
                nc.Tag = c.InformeCategoriaId;
                nc.ImageIndex = 1;
                nc.SelectedImageIndex = 2;
                root.Nodes.Add(nc);

            }
            MyTreeView.Nodes.Add(root);
            MyTreeView.AfterSelect += MyTreeView_AfterSelect;

        }

        private void MyTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            using (var db = new DymContext())
            {
                var query =
                   from i in db.Informe
                   join c in db.InformeCategoria on i.InformeCateforiaId equals c.InformeCategoriaId
                   where c.InformeCategoriaId == (int)e.Node.Tag
                   select i;
                LlenaGridInformes(query.ToList());
            }
        }
        private void LlenaGridInformes(List<Informe> informes)
        {
            Malla.Rows.Clear();
            foreach (var i in informes)
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = i.InformeId;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = i.Sistema;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = i.Descripcion;
            }
        }

        private void Inicializa()
        {
            informeController = new InformeController();
            informeCategoriaController = new InformeCategoriaController();
            informeParametroController = new InformeParametroController();

            informe = null;
            informeCategoria = null;
            informeParametro = null;

            parametros = new List<InformeParametro>();
            categorias = new List<InformeCategoria>();
            informes = new List<Informe>();

            nodo = string.Empty;

            designer = new StiDesigner();
            StiDesigner.SavingReport += new StiSavingObjectEventHandler(OnSaveReport);
            StiDesigner.LoadingReport += new StiLoadingObjectEventHandler(OnLoading);
            StiDesigner.CreatingReport += new StiCreatingObjectEventHandler(OnCreating);
            stiReport = null;
        }

        private void OnCreating(object sender, StiCreatingObjectEventArgs e)
        {
            informe = null;
            stiReport = new StiReport();
            stiReport.Dictionary.Databases.Add(new StiSqlDatabase("Dym", Ambiente.ConnectionString()));
            designer.Report = stiReport;
        }

        private void OnLoading(object sender, StiLoadingObjectEventArgs e)
        {
            using (var form = new FrmBuscadorInformes())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    informe = form.Informe;
                    //Add data to datastore
                    stiReport = new StiReport();
                    stiReport.LoadEncryptedReportFromString(informe.Codigo, informe.Guid);

                    stiReport.Dictionary.Databases.Clear();
                    stiReport.Dictionary.Databases.Add(new StiSqlDatabase("Dym", @"Data Source=.\SQLEXPRESS;Initial Catalog=Dym;Integrated Security=True;"));

                    designer.Report = stiReport;
                }
            }
        }

        private void OnSaveReport(object sender, StiSavingObjectEventArgs e)
        {
            if (designer.Report == null) return;
            e.Processed = true;

            if (informe == null)
            {
                informe = new Informe();
                informe.Guid = Guid.NewGuid().ToString();
                using (var form = new FrmNuevoInforme())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        informe.Codigo = designer.Report.SaveEncryptedReportToString(informe.Guid);
                        informe.Descripcion = form.Descrip;
                        informe.InformeCateforiaId = form.CategoriaId;
                        informe.Sistema = form.Sistema;
                        if (informeController.InsertOne(informe))
                            Ambiente.Mensaje("Cambios guardados");

                    }
                }
            }
            else
            {
                if (!informe.Sistema)
                {
                    using (var form = new FrmNuevoInforme(informe.InformeCateforiaId, informe.Descripcion, informe.Sistema))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            informe.Codigo = designer.Report.SaveEncryptedReportToString(informe.Guid);
                            informe.Descripcion = form.Descrip;
                            informe.InformeCateforiaId = form.CategoriaId;
                            informe.Sistema = form.Sistema;
                            if (informeController.Update(informe))
                                Ambiente.Mensaje("Cambios guardados");

                        }
                    }
                }
                else
                {
                    Ambiente.Mensaje("Ningun cambio guardado, el reporte es del sistema");
                    return;
                }
            }
            //your code for save report
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (designer.IsDisposed)
                designer = new StiDesigner();

            designer.ShowDesigner();
        }

        private void BtnProbar_Click(object sender, EventArgs e)
        {
            if (Malla.RowCount == 0) return;

            informe = informeController.SelectOne(int.Parse(Malla.Rows[Malla.CurrentRow.Index].Cells[0].Value.ToString()));
            if (informe != null)
            {
                stiReport = new StiReport();
                stiReport.LoadEncryptedReportFromString(informe.Codigo, informe.Guid);
                stiReport.Render();
                stiReport.Show();
            }
            else Ambiente.Mensaje("El informe ya no existe");
        }
    }
}
