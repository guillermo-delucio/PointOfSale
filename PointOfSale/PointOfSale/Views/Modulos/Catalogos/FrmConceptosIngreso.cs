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
    public partial class FrmConceptosIngreso : Form
    {
        private ConceptoIngreso objeto;
        private ConceptoIngresoController conceptoIngresoController;

        public FrmConceptosIngreso()
        {
            InitializeComponent();
            Inicializa();
        }

        public FrmConceptosIngreso(dynamic o)
        {
            InitializeComponent();
            Inicializa();
            objeto = (ConceptoIngreso)o;
            TxtClave.Text = objeto.ConceptoIngresoId;
        }
        private void Inicializa()
        {
            conceptoIngresoController = new ConceptoIngresoController();
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
                objeto = new ConceptoIngreso();
                objeto.ConceptoIngresoId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                if (conceptoIngresoController.InsertOne(objeto))
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
                objeto.ConceptoIngresoId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                if (conceptoIngresoController.Update(objeto))
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
                objeto = conceptoIngresoController.SelectOne(TxtClave.Text);
            if (objeto == null)
                return;

            TxtClave.Text = objeto.ConceptoIngresoId;
            TxtNombre.Text = objeto.Descripcion;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
