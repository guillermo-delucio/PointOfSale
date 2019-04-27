using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DYM.Views
{
    public partial class Mensaje : Form
    {
        public Mensaje()
        {
            InitializeComponent();
        }
        public Mensaje(string s)
        {
            InitializeComponent();
            txtMensaje.Text = s;
            BringToFront();
            TopMost = true;
            Focus();

        }

        private void Mensaje_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
