using Microsoft.EntityFrameworkCore;
using PointOfSale.Controllers;
using PointOfSale.Models;
using PointOfSale.Views.Modulos.Busquedas;
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
    public partial class FrmClientes : Form
    {
        private Cliente objeto;
        private ClienteController clienteController;


        public FrmClientes()
        {
            InitializeComponent();
            clienteController = new ClienteController();
            objeto = null;
        }

        public FrmClientes(dynamic objeto)
        {
            InitializeComponent();
            RecibeObjeto(objeto);
            clienteController = new ClienteController();
        }

        private void RecibeObjeto(dynamic objeto)
        {
            if (objeto != null)
            {
                this.objeto = (Cliente)objeto;
                TxtClienteId.Text = this.objeto.ClienteId;
            }

        }
        private void LlenaCampos()
        {
            if (objeto == null)
                objeto = clienteController.SelectOne(TxtClienteId.Text.Trim());

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
            TxtFormaPago.Text = objeto.FormaPagoId;
            TxtMetodoPago.Text = objeto.MetodoPagoId;
            CboPrecioDefault.Text = objeto.PrecioDefault;

        }

        private void TxtClienteId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtClienteId.Text.Trim(), (int)Ambiente.TipoBusqueda.Clientes))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                        TxtClienteId.Text = form.Cliente.ClienteId;
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

            if (objeto == null && TxtClienteId.Text.Trim().Length > 0)
            {

                objeto = new Cliente();
                objeto.ClienteId = TxtClienteId.Text.Trim();
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
                objeto.MetodoPagoId = TxtMetodoPago.Text.Trim().Length == 0 ? "01" : TxtMetodoPago.Text.Trim();
                objeto.FormaPagoId = TxtFormaPago.Text.Trim().Length == 0 ? "PUE" : TxtFormaPago.Text.Trim();
                objeto.PrecioDefault = CboPrecioDefault.Text.Trim().Length == 0 ? "PRECIO 1" : CboPrecioDefault.Text.Trim();

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

                if (clienteController.InsertOne(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name);
            }
            else
            {

                if (objeto == null)
                    return;

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
                objeto.MetodoPagoId = TxtMetodoPago.Text.Trim().Length == 0 ? "01" : TxtMetodoPago.Text.Trim();
                objeto.FormaPagoId = TxtFormaPago.Text.Trim().Length == 0 ? "PUE" : TxtFormaPago.Text.Trim();
                objeto.PrecioDefault = CboPrecioDefault.Text.Trim().Length == 0 ? "PRECIO 1" : CboPrecioDefault.Text.Trim();

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

                if (clienteController.Update(objeto))
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[3]);
                else
                    Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name);
            }
        }

        private void TxtClienteId_Leave(object sender, EventArgs e)
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

        private void TxtClienteId_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtClienteId.Text.Trim(), (int)Ambiente.TipoBusqueda.Clientes))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                        TxtClienteId.Text = form.Cliente.ClienteId;
                }
            }
        }

        private void TxtMetodoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtMetodoPago.Text.Trim(), (int)Ambiente.TipoBusqueda.MetodoPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                        TxtMetodoPago.Text = form.MetodoPago.MetodoPagoId;
                }
            }
        }

        private void TxtFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var form = new FrmBusqueda(TxtFormaPago.Text.Trim(), (int)Ambiente.TipoBusqueda.FormaPago))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                        TxtFormaPago.Text = form.FormaPago.FormaPagoId;
                }
            }
        }
    }
}
