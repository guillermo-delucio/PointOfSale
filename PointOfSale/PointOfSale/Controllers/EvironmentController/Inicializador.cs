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

                    var almacen = db.Almacen.FirstOrDefault(x => x.AlmacenId == "SYS");
                    if (almacen == null)
                    {
                        almacen = new Almacen();
                        almacen.AlmacenId = "SYS";
                        almacen.Nombre = "DEFAUTL";
                        db.Add(almacen);
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
