using Microsoft.VisualBasic.FileIO;
using PointOfSale.Controllers;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Logistica
{
    public partial class FrmEntradasPorTraspaso : Form
    {
        //controladores
        private EmpresaController empresaController;
        private TraspasoController traspasoController;
        private TraspasopController traspasopController;
        private LoteController loteController;
        private ProductoController productoController;
        private MovInvController movInvController;

        //objetos
        Empresa empresa;
        Traspaso traspaso;

        //List
        List<Traspasop> partidas;

        public FrmEntradasPorTraspaso()
        {
            InitializeComponent();
            Inicializa();
        }

        #region Metodos
        private void Inicializa()
        {

            empresaController = new EmpresaController();
            traspasoController = new TraspasoController();
            loteController = new LoteController();
            traspasoController = new TraspasoController();
            traspasopController = new TraspasopController();
            productoController = new ProductoController();
            movInvController = new MovInvController();
            traspaso = null;
            partidas = new List<Traspasop>();
            empresa = empresaController.SelectTopOne();
            Ambiente.BorrarFile(empresa.DirectorioTrabajo + @"\PH.XLSX");
            Ambiente.BorrarFile(empresa.DirectorioTrabajo + @"\PD.XLSX");
            //Ambiente.VaciarDirectorio(empresa.DirectorioTraspasos);

            TxtOrigen.Text = "";
            TxtDestino.Text = "";
            TxtDocumento.Text = "";
            TxtFechaDoc.Text = "";
            TxtEnviadoPor.Text = "";
            TxtSubtotal.Text = "";
            TxtImpuesto.Text = "";
            TxtTotal.Text = "";
            Malla.Rows.Clear();
            CargaTraspasosPendientes();
        }
        private void CargaTraspasosPendientes()
        {
            foreach (var t in Ambiente.GetDirectoryFiles(empresa.DirectorioTraspasos))
            {
                if (t.Substring(0, 1).Equals("P") && !t.Substring(1, 2).Equals("P"))
                    CboTraspasos.Items.Add(t);
            }
        }
        #endregion

        #region Eventos
        private void BtnCargar_Click(object sender, EventArgs e)
        {

            CargarTraspaso();
        }

        private void CargarTraspaso()
        {
            if (CboTraspasos.Text.Trim().Length == 0)
            {
                Ambiente.Mensaje("Proceso abortado, seleccione un traspaso.");
                return;
            }
            if (Ambiente.ExtraerFile(empresa.DirectorioTraspasos + CboTraspasos.Text.Trim(), empresa.DirectorioTrabajo))
            {
                traspaso = Ambiente.SerializaPH(empresa.DirectorioTrabajo + @"\PH.XLSX");
                partidas = Ambiente.SerializaPD(empresa.DirectorioTrabajo + @"\PD.XLSX");
                LlenaHeader();
                LlenaMalla();

            }
            else
            {
                Ambiente.Mensaje("Proceso abortado, no se pudo extraer el archivo.");
            }
        }

        private void LlenaMalla()
        {
            Malla.Rows.Clear();
            foreach (var partida in partidas)
            {
                Malla.Rows.Add();
                //partida al grid
                Malla.Rows[Malla.RowCount - 1].Cells[0].Value = partida.Descripcion;
                Malla.Rows[Malla.RowCount - 1].Cells[1].Value = partida.Stock;
                Malla.Rows[Malla.RowCount - 1].Cells[2].Value = partida.Cantidad;
                Malla.Rows[Malla.RowCount - 1].Cells[3].Value = partida.Precio;
                Malla.Rows[Malla.RowCount - 1].Cells[4].Value = partida.Impuesto1;
                Malla.Rows[Malla.RowCount - 1].Cells[5].Value = partida.Impuesto2;
                Malla.Rows[Malla.RowCount - 1].Cells[6].Value = partida.Subtotal;
                Malla.Rows[Malla.RowCount - 1].Cells[7].Value = partida.Subtotal + partida.ImporteImpuesto1 + partida.ImporteImpuesto2;
                Malla.Rows[Malla.RowCount - 1].Cells[8].Value = partida.NoLote;
                Malla.Rows[Malla.RowCount - 1].Cells[9].Value = partida.Caducidad;
            }
        }

        private void LlenaHeader()
        {
            TxtOrigen.Text = traspaso.SucursalOrigenName;
            TxtDestino.Text = traspaso.SucursalDestinoName;
            TxtDocumento.Text = traspaso.Documento;
            TxtFechaDoc.Text = traspaso.FechaDocumento.ToString();
            TxtEnviadoPor.Text = traspaso.SentBy;
            TxtSubtotal.Text = Ambiente.FDinero(traspaso.Subtotal.ToString());
            TxtImpuesto.Text = Ambiente.FDinero(traspaso.Impuesto.ToString());
            TxtTotal.Text = Ambiente.FDinero(traspaso.Total.ToString());
        }
        #endregion

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Ambiente.Pregunta("Realmente quieres abortar este proceso"))
            {
                Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AplicarTraspaso();
        }

        private void AplicarTraspaso()
        {
            if (traspasoController.InsertOne(traspaso))
            {
                foreach (var p in partidas)
                {
                    p.TraspasoId = traspaso.TraspasoId;
                }
                if (traspasopController.InsertRange(partidas))
                {
                    SumaLotes();
                    AfectaStock();
                    AfectaMovsInv();
                    CambiarStatus();
                    Ambiente.Mensaje("Proceso concluido con éxito.");
                    Inicializa();
                }
            }
        }

        private void CambiarStatus()
        {
            try
            {
                var old = CboTraspasos.Text.Trim();
                var nuevo = old.Substring(1, old.Length - 1);
                nuevo = "A" + nuevo;
                File.Move(empresa.DirectorioTraspasos + CboTraspasos.Text.Trim(), empresa.DirectorioTraspasos + nuevo);
            }
            catch (Exception e)
            {

                Ambiente.Mensaje(e.Message);
            }
        }

        private void AfectaMovsInv()
        {
            foreach (var p in partidas)
            {
                var movInv = new MovInv();
                movInv.ConceptoMovsInvId = "ET";
                movInv.NoRef = (int)traspaso.TraspasoId;
                movInv.EntradaSalida = "E";
                movInv.IdEntrada = p.TraspasopId;
                movInv.IdSalida = null;
                movInv.ProductoId = p.ProductoId;
                movInv.Precio = p.Precio;
                movInv.Cantidad = p.Cantidad;
                movInv.CreatedAt = DateTime.Now;
                movInv.CreatedBy = Ambiente.LoggedUser.UsuarioId;
                movInvController.InsertOne(movInv);
            }
        }
        private void AfectaStock()
        {
            foreach (var p in partidas)
            {
                var prod = productoController.SelectOne(p.ProductoId);
                prod.Stock += p.Cantidad;
                productoController.Update(prod);
            }
        }
        private void SumaLotes()
        {
            foreach (var p in partidas)
            {
                if (p.LoteId != null)
                {
                    var prod = productoController.SelectOne(p.ProductoId);
                    if (prod != null)
                    {
                        var l = loteController.SelectOneByNoLote(p.NoLote);
                        if (l == null)
                        {
                            l = new Lote();
                            l.NoLote = p.NoLote;
                            l.StockInicial = p.Cantidad;
                            l.StockRestante = p.Cantidad;
                            l.ProductoId = p.ProductoId;
                            loteController.InsertOne(l);
                        }
                        else
                        {
                            l.StockRestante += p.Cantidad;
                            loteController.Update(l);
                        }
                    }

                }

            }
        }

        private void FrmEntradasPorTraspaso_Load(object sender, EventArgs e)
        {

        }
    }
}
