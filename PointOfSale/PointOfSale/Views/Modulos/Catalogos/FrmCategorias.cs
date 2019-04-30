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
    public partial class FrmCategorias : Form
    {
        private dynamic objeto;

        public FrmCategorias()
        {
            InitializeComponent();
        }

        public FrmCategorias(dynamic objeto)
        {
            InitializeComponent();
            this.objeto = objeto;
            if (this.objeto != null)
                TxtClave.Text = ((Categoria)this.objeto).CategoriaId;
        }

        private void TxtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LlenaCampos();
            }
        }

        private void LlenaCampos()
        {
            if (this.objeto == null)
                return;

            var NativeObject = (Categoria)this.objeto;
            TxtNombre.Text = NativeObject.Nombre;
        }
    }
}
