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

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmConceptosEgreso : Form
    {

        private ConceptoEgreso objeto;
        private ConceptoEgresoController conceptoEgresoController;

        public FrmConceptosEgreso()
        {
            InitializeComponent();
            Inicializa();
        }

        public FrmConceptosEgreso(dynamic o)
        {
            InitializeComponent();
            Inicializa();
            objeto = (ConceptoEgreso)o;
            TxtClave.Text = objeto.ConceptoEgresoId;
        }
        private void Inicializa()
        {
            conceptoEgresoController = new ConceptoEgresoController();
            objeto = null;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void InsertOrUpdate()
        {
            if (objeto == null)
            {
                if (TxtClave.Text.Trim().Length == 0)
                {
                    Ambiente.Mensaje("Proceso abortado");
                    return;
                }
                objeto = new ConceptoEgreso();
                objeto.ConceptoEgresoId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                if (conceptoEgresoController.InsertOne(objeto))
                {
                    Ambiente.Mensaje("Cambios guardados");
                    Close();
                }
                else
                    Ambiente.Mensaje("Algo salio mal");

            }
            else
            {
                if (TxtClave.Text.Trim().Length == 0)
                {
                    Ambiente.Mensaje("Proceso abortado");
                    return;
                }
                objeto.ConceptoEgresoId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                if (conceptoEgresoController.Update(objeto))
                {
                    Ambiente.Mensaje("Cambios guardados");
                    Close();
                }
                else
                    Ambiente.Mensaje("Algo salio mal");
            }
        }

        private void TxtClave_Leave(object sender, EventArgs e)
        {
            LlenaCampos();
        }

        private void LlenaCampos()
        {
            if (objeto == null)
                objeto = conceptoEgresoController.SelectOne(TxtClave.Text);
            if (objeto == null)
                return;

            TxtClave.Text = objeto.ConceptoEgresoId;
            TxtNombre.Text = objeto.Descripcion;

        }



        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
