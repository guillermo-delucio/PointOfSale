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
    public partial class FrmUsuarios : Form
    {
        private dynamic objeto;
        private UsuarioController usuarioController;
        bool ModoCreate;

        public FrmUsuarios()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
            ModoCreate = true;
        }

        public FrmUsuarios(dynamic objeto)
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
            this.objeto = objeto;

            if (this.objeto != null)
            {
                objeto = (Usuario)this.objeto;
                TxtUserId.Text = objeto.UsuarioId;
            }
        }

        private void TxtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenaCampos();
            }

        }
        private void LlenaCampos()
        {
            if (objeto == null)
                ModoCreate = true;
            else
            {
                ModoCreate = false;
                TxtUserId.Text = objeto.UsuarioId;
                TxtPassword.Text = Ambiente.Decrypt(objeto.Password);
                TxtArea.Text = objeto.Area;
                TxtNombre.Text = objeto.Nombre;
                ChkIsAdmin.Checked = objeto.IsAdmin;


            }


        }
        private void InsertOrUpdate()
        {
            if (ModoCreate)
            {
                if (TxtUserId.Text.Trim().Length == 0)
                    return;

                objeto = new Usuario();
                objeto.UsuarioId = TxtUserId.Text.Trim();

                objeto.Password = Ambiente.Encrypt(TxtPassword.Text);
                objeto.Area = TxtArea.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();
                objeto.IsAdmin = ChkIsAdmin.Checked;

                if (usuarioController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);
                Close();
            }
            else
            {
                objeto.Password = Ambiente.Encrypt(TxtPassword.Text);            
                objeto.Area = TxtArea.Text.Trim();
                objeto.Nombre = TxtNombre.Text.Trim();
                objeto.IsAdmin = ChkIsAdmin.Checked;

                if (usuarioController.Update(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1]);

                Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
