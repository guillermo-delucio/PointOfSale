using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class InventarioController
    {
        public bool AfectaInventario(string productoId, decimal cantidad)
        {
            //creamos nuestro contexto
            using (var db = new DymContext())
            {
                //creamos el ámbito de la transacción
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var producto = db.Producto.FirstOrDefault(x => x.ProductoId == productoId.Trim());
                        if (producto != null)
                        {
                            producto.Stock += cantidad;

                            if (db.SaveChanges() > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                                transaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        //hacemos rollback si hay excepción
                        ex.ToString();
                        transaction.Rollback();

                    }
                }
            }
            return false;
        }
    }
}
