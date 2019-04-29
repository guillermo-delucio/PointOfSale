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
                    db.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(ex.ToString());
            }
        }

        public static void InicializaListas()
        {
            Ambiente.CatalgoErrores = new Dictionary<int, string>();

            Ambiente.CatalgoErrores.Add(100, "Proceso abortado");
            Ambiente.CatalgoErrores.Add(101, "Proceso cancelado");
            Ambiente.CatalgoErrores.Add(102, "Algo salio mal");
            Ambiente.CatalgoErrores.Add(103, "Módulo no implementado");



            Ambiente.CatalgoErrores.Add(200, "Proceso Concluido");
            Ambiente.CatalgoErrores.Add(201, "Proceso Finalizado");

        }
    }
}
