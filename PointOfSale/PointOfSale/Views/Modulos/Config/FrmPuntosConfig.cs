using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Config
{
    public partial class FrmPuntosConfig : Form
    {
        private PuntoConfig puntoConfig;
        private PuntoController puntoController;
        private PuntoConfigController puntoConfigController;
        public FrmPuntosConfig()
        {
            InitializeComponent();
            Inicializador();
        }

        private void Inicializador()
        {
            puntoConfigController = new PuntoConfigController();
            puntoController = new PuntoController();
            puntoConfig = puntoConfigController.SelectTopOne();
            if (puntoConfig != null)
            {
                NTasaDesc.Value = puntoConfig.TasaDescuento * 100;
                NdiasReset.Value = puntoConfig.DiasReset;
            }
            else
            {
                Ambiente.Mensaje("No hay configuración por defecto para este modulo");
                Close();
            }
        }
        private void ActualizaConfig()
        {
            if (puntoConfig != null)
            {
                puntoConfig.TasaDescuento = NTasaDesc.Value / 100;
                puntoConfig.DiasReset = (int)NdiasReset.Value;
                if (puntoConfigController.Update(puntoConfig))
                {
                    Ambiente.Mensaje("Proceso concluido con éxito");
                    Close();
                }
                else
                    Ambiente.Mensaje("Algo salió mal con este modulo");
            }
            else
            {
                Ambiente.Mensaje("No hay configuración por defecto para este modulo");
                Close();
            }
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            ActualizaConfig();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Ambiente.Mensaje("Esta operación quedará registrada y es perfectamente trazable");
            if (Ambiente.Pregunta("Realmente quiere eliminar el monedero de todos los clientes"))
            {
                if (puntoController.HardReset())
                    Ambiente.Mensaje("Proceso concluido con éxito");
                else
                    Ambiente.Mensaje("Algo salió mal con este modulo");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
