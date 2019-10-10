using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.PuntoVenta
{
    public partial class FrmSolicitudPuntos : Form
    {
        public string NoTarjeta { get; set; }

        public FrmSolicitudPuntos()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (TxtNoTarjeta.Text.Trim().Length == 0)
            {
                Controllers.Ambiente.Mensaje("El campo es requerido");
                return;
            }
            NoTarjeta = TxtNoTarjeta.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
