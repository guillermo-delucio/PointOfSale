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
    public partial class Pregunta : Form
    {
        public Pregunta()
        {
            InitializeComponent();
        }
        public Pregunta(string s)
        {
            InitializeComponent();
            txtMensaje.Text = "¿" + s + "?";
        }

        private void Pregunta_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Dispose();
        }
    }
}
