using PointOfSale.Controllers;
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
            if (login.AuthenticaUsuario(txtUser.Text, txtPassword.Text))
            {
                var form = new FrmMain
                {
                    MdiParent = this.MdiParent
                };
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
    }
}
