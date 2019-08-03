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

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmLoteCaducidad : Form
    {
        //listas
        List<Lote> lotes;

        //Controladores
        LoteController loteController;
        ProductoController productoController;

        //obajetos
        Producto producto;
        Lote lote;

        //Variables
        decimal cantidadTotal;
        decimal restante;




        public FrmLoteCaducidad(decimal cantidad = 0, string productoId = "")
        {
            InitializeComponent();
            Inicializa();

            if (cantidad > 0)
                LlenaCampos(productoId, cantidad);
        }

        #region Metodos
        private void Inicializa()
        {
            //listas
            lotes = new List<Lote>();

            //Controladores
            loteController = new LoteController();
            productoController = new ProductoController();
            //obajetos
            producto = new Producto();
            lote = new Lote();
        }


        private void LlenaCampos(string productoId, decimal cantidad)
        {
            producto = productoController.SelectOne(productoId.Trim());
            cantidadTotal = cantidad;
            restante = cantidad;

            TxtRestante.Text = restante.ToString();
            NCantidad.Value = cantidadTotal;
            TxtProductoId.Text = productoId;
            TxtDescrip.Text = producto.Descripcion;
        }
        private void AgregarLote()
        {
            if (NCantidad.Value <= restante && TxtNoLote.Text.Trim().Length > 0)
            {
                lote = new Lote();
                lote.NoLote = TxtNoLote.Text.Trim();
                lote.ProductoId = TxtProductoId.Text.Trim();
                lote.StockInicial = NCantidad.Value;
                lote.StockRestante = NCantidad.Value;
                lote.Caducidad = DpFechaCaducidad.Value;
                lote.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                lote.CreatedAt = DateTime.Now;
                lotes.Add(lote);

                restante -= NCantidad.Value;
                TxtRestante.Text = restante.ToString();
                CargaGrid();
            }
            else
                Ambiente.Mensaje("Operación denegada");

        }

        private void CargaGrid()
        {
            Malla.Rows.Clear();
            foreach (var l in lotes)
            {
                Malla.Rows.Add();
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = l.NoLote;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = l.Caducidad;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = l.StockInicial;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = l.StockRestante;
            }
        }
        private void BorraPartida(int rowIndex)
        {
            restante += lotes[rowIndex].StockInicial;
            lotes.RemoveAt(rowIndex);
            CargaGrid();
        }
        private void Salir()
        {
            if (restante == 0 && lotes.Count > 0)
                if (lotes[0].LoteId > 0)
                    Close();
                else
                    Ambiente.Mensaje("Operación denegada, No se han guardado los cambios");
            else
                Ambiente.Mensaje("Operación denegada, hay lotes sin asignar");
        }
        private void GuardaLotes()
        {

            if (restante == 0 && lotes.Count > 0)
            {
                foreach (var l in lotes)
                    loteController.InsertOne(l);
                Ambiente.Mensaje("Proceso concluido con éxito");
                Close();
            }
            else
                Ambiente.Mensaje("Operación denegada, hay lotes sin asignar");



        }

        #endregion

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarLote();
        }

        private void Malla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Ambiente.Pregunta("Realmente quiere borrar: " + Malla.Rows[Malla.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                {
                    BorraPartida(Malla.CurrentCell.RowIndex);
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Salir();
        }


        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            GuardaLotes();
        }
    }
}
