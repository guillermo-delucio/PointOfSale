using PointOfSale.Controllers;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Windows.Forms;

namespace DYM.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Autenticha();
        }

        private void Autenticha()
        {
            var login = new LoginController();
            var estacioncontroller = new EstacionController();
            var usuarioController = new UsuarioController();


            if (login.AuthenticaUsuario(txtUser.Text, txtPassword.Text))
            {

                var form = new FrmMain
                {
                    MdiParent = this.MdiParent
                };

                if (Ambiente.Estacion == null)
                {
                    Ambiente.Estacion = estacioncontroller.SelectOne(TxtEstacionId.Text.Trim());
                    if (Ambiente.Estacion == null)
                    {
                        Ambiente.Mensaje("LA ESTACION NO EXISTE");
                        return;
                    }
                    else
                    {
                        Ambiente.LoggedUser.EstacionId = Ambiente.Estacion.EstacionId;
                        usuarioController.Update(Ambiente.LoggedUser);
                    }
                }
                else
                {
                    Ambiente.LoggedUser.EstacionId = Ambiente.Estacion.EstacionId;
                    usuarioController.Update(Ambiente.LoggedUser);
                }



                form.Show();
                Dispose();
            }
            else
            {
                Ambiente.Mensaje("Credenciales incorrectas");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Autenticha();
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(txtUser.Text.Trim(), (int)Ambiente.TipoBusqueda.Usuarios))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        txtUser.Text = form.Usuario.UsuarioId;
                        TxtEstacionId.Text = form.Usuario.EstacionId;
                    }
                }
            }
        }

        private void TxtEstacionId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtEstacionId.Text.Trim(), (int)Ambiente.TipoBusqueda.Estaciones))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        Ambiente.Estacion = form.Estacion;
                        TxtEstacionId.Text = Ambiente.Estacion.EstacionId;
                    }
                }
            }
        }
    }
}
