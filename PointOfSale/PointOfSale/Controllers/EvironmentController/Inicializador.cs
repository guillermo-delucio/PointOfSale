using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public static class Inicializador
    {
        public static void IniciliazaConexion()
        {
            try
            {
                using (var db = new DymContext())
                {

                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }

        public static void InicializaListas()
        {

            Ambiente.CatalgoMensajes = new Dictionary<int, string>
            {
                //[<0] MENSAJES NEGATIVOS
                {-1, "ALGO SALIÓ MAL :( \n" },
                {-2, "PROCESO ABORTADO :( \n" },
                {-3, "PROCESO CANCELADO :( \n" },
                {-4, "ERROR DESCONOCIDO :( \n" },
                {-5, "MÓDULO NO IMPLEMENTADO :( \n" },
                {-6, "EL REGISTRO YA NO EXISTE:( \n" },
                {-7, "LA CADENA NO TIENE EN FORMATO CORRECTO:( \n" },
                {-8, "OPERACIÓN DENEGADA:( \n" },

                //[>0] MENSAJES POSITIVOS
                {1, "COMPLETADO CON ÉXITO :) \n" },
                {2, "PROCESO COMPLETADO :) \n" },
                {3, "CAMBIOS GUARDADOS :) \n" },

            };

        }


        public static void InicializaProdiedades()
        {
            Ambiente.RutaImgs = @"C:\Dympos\IMGS";
            Ambiente.PrefijoRutaImg = @"C:\Dympos\";
        }

        public static void InicializaDatabaseDefaultsValues()
        {
            try
            {
                using (var db = new DymContext())
                {
                    var estacion = db.Estacion.FirstOrDefault(x => x.EstacionId == "SYS");
                    if (estacion == null)
                    {
                        estacion = new Estacion();
                        estacion.EstacionId = "SYS";
                        estacion.Nombre = "DEFAUTL";
                        db.Add(estacion);
                    }
                    var sustancia = db.Sustancia.FirstOrDefault(x => x.SustanciaId == "SYS");
                    if (sustancia == null)
                    {
                        sustancia = new Sustancia();
                        sustancia.SustanciaId = "SYS";
                        sustancia.Nombre = "DEFAUTL";
                        db.Add(sustancia);
                    }
                    var categoria = db.Categoria.FirstOrDefault(x => x.CategoriaId == "SYS");
                    if (categoria == null)
                    {
                        categoria = new Categoria();
                        categoria.CategoriaId = "SYS";
                        categoria.Nombre = "DEFAUTL";
                        db.Add(categoria);
                    }


                    var presentacion = db.Presentacion.FirstOrDefault(x => x.PresentacionId == "SYS");
                    if (presentacion == null)
                    {
                        presentacion = new Presentacion();
                        presentacion.PresentacionId = "SYS";
                        presentacion.Nombre = "DEFAUTL";
                        db.Add(presentacion);
                    }
                    var laboratorio = db.Laboratorio.FirstOrDefault(x => x.LaboratorioId == "SYS");
                    if (laboratorio == null)
                    {
                        laboratorio = new Laboratorio();
                        laboratorio.LaboratorioId = "SYS";
                        laboratorio.Nombre = "DEFAUTL";
                        db.Add(laboratorio);
                    }
                    var impuesto = db.Impuesto.FirstOrDefault(x => x.ImpuestoId == "SYS");
                    if (impuesto == null)
                    {
                        impuesto = new Impuesto();
                        impuesto.ImpuestoId = "SYS";
                        impuesto.Tasa = 0;
                        impuesto.CImpuesto = "002";
                        db.Add(impuesto);
                    }
                    var unidadMedida = db.UnidadMedida.FirstOrDefault(x => x.UnidadMedidaId == "SYS");
                    if (unidadMedida == null)
                    {
                        unidadMedida = new UnidadMedida();
                        unidadMedida.UnidadMedidaId = "SYS";
                        unidadMedida.Nombre = "DEFAUTL";
                        unidadMedida.UnidadSat = "H87";
                        db.Add(unidadMedida);
                    }

                    var edodocP = db.EstadoDoc.FirstOrDefault(x => x.EstadoDocId == "PEN");
                    if (edodocP == null)
                    {
                        edodocP = new EstadoDoc();
                        edodocP.EstadoDocId = "PEN";
                        edodocP.Descripcion = "PENDIENTE";
                        db.Add(edodocP);
                    }
                    var edodocCa = db.EstadoDoc.FirstOrDefault(x => x.EstadoDocId == "CAN");
                    if (edodocCa == null)
                    {
                        edodocCa = new EstadoDoc();
                        edodocCa.EstadoDocId = "CAN";
                        edodocCa.Descripcion = "CANCELADO";
                        db.Add(edodocCa);
                    }
                    var edodocCo = db.EstadoDoc.FirstOrDefault(x => x.EstadoDocId == "CON");
                    if (edodocCo == null)
                    {
                        edodocCo = new EstadoDoc();
                        edodocCo.EstadoDocId = "CON";
                        edodocCo.Descripcion = "CONFIRMADO";
                        db.Add(edodocCo);
                    }

                    var tipoDocCom = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "COM");
                    if (tipoDocCom == null)
                    {
                        tipoDocCom = new TipoDoc();
                        tipoDocCom.TipoDocId = "COM";
                        tipoDocCom.Descripcion = "COMPRA";
                        db.Add(tipoDocCom);
                    }

                    var tipoDocDvc = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "DVC");
                    if (tipoDocDvc == null)
                    {
                        tipoDocDvc = new TipoDoc();
                        tipoDocDvc.TipoDocId = "DVC";
                        tipoDocDvc.Descripcion = "DEVOLUCIÓN SOBRE COMPRA";
                        db.Add(tipoDocDvc);
                    }

                    var tipoDocDev = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "DVV");
                    if (tipoDocDev == null)
                    {
                        tipoDocDev = new TipoDoc();
                        tipoDocDev.TipoDocId = "DVV";
                        tipoDocDev.Descripcion = "DEVOLUCIÓN SOBRE VENTA";
                        db.Add(tipoDocDev);
                    }

                    var tipoDocFac = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "FAC");
                    if (tipoDocFac == null)
                    {
                        tipoDocFac = new TipoDoc();
                        tipoDocFac.TipoDocId = "FAC";
                        tipoDocFac.Descripcion = "FACTURA";
                        db.Add(tipoDocFac);
                    }

                    var tipoDocRem = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "REM");
                    if (tipoDocRem == null)
                    {
                        tipoDocRem = new TipoDoc();
                        tipoDocRem.TipoDocId = "REM";
                        tipoDocRem.Descripcion = "REMISIÓN";
                        db.Add(tipoDocRem);
                    }

                    var tipoDocTic = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "TIC");
                    if (tipoDocTic == null)
                    {
                        tipoDocTic = new TipoDoc();
                        tipoDocTic.TipoDocId = "TIC";
                        tipoDocTic.Descripcion = "TICKET";
                        db.Add(tipoDocTic);
                    }

                    var tipoDocNc = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "NC");
                    if (tipoDocNc == null)
                    {
                        tipoDocNc = new TipoDoc();
                        tipoDocNc.TipoDocId = "NC";
                        tipoDocNc.Descripcion = "NOTA DE CRÉDITO";
                        db.Add(tipoDocNc);
                    }

                    var tipoDocCxp = db.TipoDoc.FirstOrDefault(x => x.TipoDocId == "CXP");
                    if (tipoDocCxp == null)
                    {
                        tipoDocCxp = new TipoDoc();
                        tipoDocCxp.TipoDocId = "CXP";
                        tipoDocCxp.Descripcion = "CUENTA POR PAGAR";
                        db.Add(tipoDocCxp);
                    }

                    var clienteSYS = db.Cliente.FirstOrDefault(x => x.ClienteId == "SYS");
                    if (clienteSYS == null)
                    {
                        clienteSYS = new Cliente();
                        clienteSYS.ClienteId = "SYS";
                        clienteSYS.Negocio = "PUBLICO EN GENERAL";
                        clienteSYS.RazonSocial = "PUBLICO EN GENERAL";
                        clienteSYS.MetodoPagoId = "PUE";
                        clienteSYS.FormaPagoId = "01";
                        db.Add(clienteSYS);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error al inicializar db defautls: " + ex.ToString());
            }
        }
    }
}
