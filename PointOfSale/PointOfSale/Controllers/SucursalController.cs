using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class SucursalController
    {
        public Sucursal SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                   return db.Sucursal.FirstOrDefault(x => x.SucursalId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
    }
}
