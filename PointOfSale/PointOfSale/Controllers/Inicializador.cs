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
    }
}
