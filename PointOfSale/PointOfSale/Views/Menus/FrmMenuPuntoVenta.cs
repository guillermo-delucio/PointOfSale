using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.PuntoVenta;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale.Views.Menus
{
    public partial class FrmMenuPuntoVenta : Form
    {
        public FrmMenuPuntoVenta()
        {
            InitializeComponent();
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

            Ambiente.SaveAndCorte();
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
