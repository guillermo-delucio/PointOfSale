using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Reportes
{

    public partial class FrmParamData : Form
    {
        public static DateTime Inicial;
        public static DateTime Final;
        public bool TodasLasFechas;
        public FrmParamData()
        {
            InitializeComponent();

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Inicial = DpInicial.Value;
            Final = DpFinal.Value;
            TodasLasFechas = ChkTotasLasFechas.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
