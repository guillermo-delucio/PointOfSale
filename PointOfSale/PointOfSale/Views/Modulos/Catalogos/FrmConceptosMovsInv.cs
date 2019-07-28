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
    public partial class FrmConceptosMovsInv : Form
    {
        private ConceptoMovInv objeto;
        private ConceptoMovInvController conceptoMovInvController;

        public FrmConceptosMovsInv()
        {
            InitializeComponent();
            Inicializa();
        }
        public FrmConceptosMovsInv(dynamic o)
        {
            InitializeComponent();
            Inicializa();
            objeto = (ConceptoMovInv)o;
            TxtClave.Text = objeto.ConceptoMovInvId;
        }
        private void Inicializa()
        {
            conceptoMovInvController = new ConceptoMovInvController();
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
                objeto = new ConceptoMovInv();
                objeto.ConceptoMovInvId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                if (conceptoMovInvController.InsertOne(objeto))
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
                objeto.ConceptoMovInvId = TxtClave.Text.Trim();
                objeto.Descripcion = TxtNombre.Text.Trim();
                if (conceptoMovInvController.Update(objeto))
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
                objeto = conceptoMovInvController.SelectOne(TxtClave.Text);
            if (objeto == null)
                return;

            TxtClave.Text = objeto.ConceptoMovInvId;
            TxtNombre.Text = objeto.Descripcion;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
