using Microsoft.EntityFrameworkCore;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale.Views.Modulos.Catalogos
{
    public partial class FrmProveedores : Form
    {
        private Proveedor objeto;
        private ProveedorController proveedorController;


        public FrmProveedores()
        {
            InitializeComponent();
            proveedorController = new ProveedorController();
            objeto = null;
        }

        public FrmProveedores(dynamic objeto)
        {
            InitializeComponent();
            RecibeObjeto(objeto);
            proveedorController = new ProveedorController();
        }

        private void RecibeObjeto(dynamic objeto)
        {
            if (objeto != null)
            {
                this.objeto = (Proveedor)objeto;
                TxtProveedorId.Text = this.objeto.ProveedorId;
            }

        }
        private void LlenaCampos()
        {
            if (objeto == null)
                objeto = proveedorController.SelectOne(TxtProveedorId.Text.Trim());

            if (objeto == null)
                return;

            TxtRFC.Text = objeto.Rfc;
            TxtNegocio.Text = objeto.Negocio;
            TxtRazonSocial.Text = objeto.RazonSocial;
            TxtContacto.Text = objeto.Contancto;
            TxtDireccion.Text = objeto.Direccion;
            TxtCp.Text = objeto.Cp;
            TxtColonia.Text = objeto.Colonia;
            TxtMunicipio.Text = objeto.Municipio;
            TxtLocalidad.Text = objeto.Localidad;
            TxtEstado.Text = objeto.Estado;
            TxtPais.Text = objeto.Pais;
            TxtCorreo.Text = objeto.Correo;
            TxtLimiteCredito.Text = objeto.LimiteCredito.ToString();
            TxtDiasCredito.Text = objeto.DiasCredito.ToString();
            TxtCelular.Text = objeto.Celular;
            TxtTelefono.Text = objeto.Telefono;


        }

        private void TxtProveedorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtProveedorId.Text.Trim(), (int)Ambiente.TipoBusqueda.Proveedores))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                        TxtProveedorId.Text = form.Proveedor.ProveedorId;
                }
            }

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            InsertOrUpdate();
        }

        private void InsertOrUpdate()
        {
            bool success = false;

            if (objeto == null && TxtProveedorId.Text.Trim().Length > 0)
            {

                objeto = new Proveedor();
                objeto.ProveedorId = TxtProveedorId.Text.Trim();
                objeto.Rfc = TxtRFC.Text.Trim().Length == 0 ? "XAXX010101000" : TxtRFC.Text.Trim();
                objeto.Negocio = TxtNegocio.Text.Trim().Length == 0 ? "" : TxtNegocio.Text.Trim();
                objeto.RazonSocial = TxtRazonSocial.Text.Trim().Length == 0 ? "" : TxtRazonSocial.Text.Trim();
                objeto.Contancto = TxtContacto.Text.Trim().Length == 0 ? "" : TxtContacto.Text.Trim();
                objeto.Direccion = TxtDireccion.Text.Trim().Length == 0 ? "" : TxtDireccion.Text.Trim();
                objeto.Cp = TxtCp.Text.Trim().Length == 0 ? "" : TxtCp.Text.Trim();
                objeto.Colonia = TxtColonia.Text.Trim().Length == 0 ? "" : TxtColonia.Text.Trim();
                objeto.Municipio = TxtMunicipio.Text.Trim().Length == 0 ? "" : TxtMunicipio.Text.Trim();
                objeto.Localidad = TxtLocalidad.Text.Trim().Length == 0 ? "" : TxtLocalidad.Text.Trim();
                objeto.Estado = TxtEstado.Text.Trim().Length == 0 ? "" : TxtEstado.Text.Trim();
                objeto.Pais = TxtPais.Text.Trim().Length == 0 ? "" : TxtPais.Text.Trim();
                objeto.Correo = TxtCorreo.Text.Trim().Length == 0 ? "" : TxtCorreo.Text.Trim();
                objeto.Telefono = TxtTelefono.Text.Trim().Length == 0 ? "" : TxtTelefono.Text.Trim();
                objeto.Celular = TxtCelular.Text.Trim().Length == 0 ? "" : TxtCelular.Text.Trim();

                success = decimal.TryParse(TxtLimiteCredito.Text.Trim(), out decimal nLimite);
                success = int.TryParse(TxtDiasCredito.Text.Trim(), out int nDias);
                if (success)
                {
                    objeto.LimiteCredito = nLimite;
                    objeto.DiasCredito = nDias;
                }
                else
                {
                    objeto.LimiteCredito = 0M;
                    objeto.DiasCredito = 0;
                }

                if (proveedorController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name);
            }
            else
            {

                objeto.Rfc = TxtRFC.Text.Trim().Length == 0 ? "XAXX010101000" : TxtRFC.Text.Trim();
                objeto.Negocio = TxtNegocio.Text.Trim().Length == 0 ? "" : TxtNegocio.Text.Trim();
                objeto.RazonSocial = TxtRazonSocial.Text.Trim().Length == 0 ? "" : TxtRazonSocial.Text.Trim();
                objeto.Contancto = TxtContacto.Text.Trim().Length == 0 ? "" : TxtContacto.Text.Trim();
                objeto.Direccion = TxtDireccion.Text.Trim().Length == 0 ? "" : TxtDireccion.Text.Trim();
                objeto.Cp = TxtCp.Text.Trim().Length == 0 ? "" : TxtCp.Text.Trim();
                objeto.Colonia = TxtColonia.Text.Trim().Length == 0 ? "" : TxtColonia.Text.Trim();
                objeto.Municipio = TxtMunicipio.Text.Trim().Length == 0 ? "" : TxtMunicipio.Text.Trim();
                objeto.Localidad = TxtLocalidad.Text.Trim().Length == 0 ? "" : TxtLocalidad.Text.Trim();
                objeto.Estado = TxtEstado.Text.Trim().Length == 0 ? "" : TxtEstado.Text.Trim();
                objeto.Pais = TxtPais.Text.Trim().Length == 0 ? "" : TxtPais.Text.Trim();
                objeto.Correo = TxtCorreo.Text.Trim().Length == 0 ? "" : TxtCorreo.Text.Trim();
                objeto.Telefono = TxtTelefono.Text.Trim().Length == 0 ? "" : TxtTelefono.Text.Trim();
                objeto.Celular = TxtCelular.Text.Trim().Length == 0 ? "" : TxtCelular.Text.Trim();

                success = decimal.TryParse(TxtLimiteCredito.Text.Trim(), out decimal nLimite);
                success = int.TryParse(TxtDiasCredito.Text.Trim(), out int nDias);
                if (success)
                {
                    objeto.LimiteCredito = nLimite;
                    objeto.DiasCredito = nDias;
                }
                else
                {
                    objeto.LimiteCredito = 0M;
                    objeto.DiasCredito = 0;
                }

                if (proveedorController.Update(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name);
            }
        }

        private void TxtProveedorId_Leave(object sender, EventArgs e)
        {
            LlenaCampos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void TraeCP(string cp)
        {
            using (var db = new DymContext())
            {
                var data = db.Cp
                    .Include(x => x.Municipio)
                    .ThenInclude(x => x.Estado)
                    .ThenInclude(x => x.Pais)
                    .Where(x => x.Codigo == cp)
                    .FirstOrDefault();
                if (data != null)
                {
                    TxtMunicipio.Text = data.Municipio.Nombre;
                    TxtLocalidad.Text = data.Municipio.Nombre;
                    TxtEstado.Text = data.Municipio.Estado.Nombre;
                    TxtPais.Text = data.Municipio.Estado.Pais.Nombre;
                }
            }
        }

        private void TxtCp_Leave(object sender, EventArgs e)
        {
            TraeCP(TxtCp.Text);
        }
    }
}
