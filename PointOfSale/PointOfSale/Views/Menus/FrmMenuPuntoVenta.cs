using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.PuntoVenta;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PointOfSale.Views.Menus
{
    public partial class FrmMenuPuntoVenta : Form
    {
        ReporteController reporteController;
        List<Parametro> parametros;

        public FrmMenuPuntoVenta()
        {
            InitializeComponent();
            reporteController = new ReporteController();
            parametros = new List<Parametro>();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            var o = new Modulos.PuntoVenta.PointOfSale();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {
            //var parametros = new List<Parametro>();
            //try
            //{
            //    if (Ambiente.Empresa.FormatoCortes.Equals("CORTEXESTACION"))
            //    {
            //        parametros.Add(new Parametro { Clave = "[EstacionId]", Valor = "'" + Ambiente.Estacion.EstacionId + "'" });
            //        parametros.Add(new Parametro { Clave = "[FechaSistema]", Valor = Ambiente.FechaSQL(DateTime.Now) });
            //        Ambiente.ShowReport("CORTEXESTACION", parametros);
            //    }
            //    else if (Ambiente.Empresa.FormatoCortes.Equals("CORTEXUSUARIO"))
            //    {
            //        parametros.Add(new Parametro { Clave = "[UsuarioId]", Valor = "'" + Ambiente.LoggedUser.UsuarioId + "'" });
            //        parametros.Add(new Parametro { Clave = "[FechaSistema]", Valor = Ambiente.FechaSQL(DateTime.Now) });
            //        Ambiente.ShowReport("CORTEXUSUARIO", parametros);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Ambiente.Mensaje(ex.Message);
            //}


            try
            {
                if (Ambiente.Empresa.FormatoCortes.Equals("CORTEXESTACION"))
                {
                    Ambiente.AddReportParam("[EstacionId]", "'" + Ambiente.Estacion.EstacionId + "'", true);
                    Ambiente.AddReportParam("[FechaSistema]", Ambiente.FechaSQL(DateTime.Now));
                    Ambiente.ShowReport("CORTEXESTACION", Ambiente.GetReportParam());
                }
                else if (Ambiente.Empresa.FormatoCortes.Equals("CORTEXUSUARIO"))
                {
                    Ambiente.AddReportParam("[UsuarioId]", "'" + Ambiente.LoggedUser.UsuarioId + "'", true);
                    Ambiente.AddReportParam("[FechaSistema]", Ambiente.FechaSQL(DateTime.Now));
                    Ambiente.ShowReport("CORTEXUSUARIO", Ambiente.GetReportParam());

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(ex.Message);
            }
        }

        private void BtnTicketAFactura_Click(object sender, EventArgs e)
        {
            var o = new FrmTicketFactura();
            o.MdiParent = MdiParent;
            o.Show();

        }

        private void BtnFacturas_Click(object sender, EventArgs e)
        {
            var o = new FrmFacturas();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnFacturaGlobal_Click(object sender, EventArgs e)
        {
            var o = new FrmFacturaGlobal3();
            o.MdiParent = MdiParent;
            o.Show();
        }

        private void BtnMovsCaja_Click(object sender, EventArgs e)
        {

        }

        private void BtnVentasDelDia_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
