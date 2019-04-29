using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    class UnidadMedidaController: IController<UnidadMedida>
    {
        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.UnidadMedida.FirstOrDefault(x => x.UnidadMedidaId == Id.Trim());
                    if (temp != null)
                    {
                        db.Remove(temp);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return false;
        }

        public bool InsertOne(UnidadMedida o)
        {
            try
            {
                using (var db = new DymContext())
                {

                    db.Add(o);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return false;
        }

        public bool InsertRange(List<UnidadMedida> lista)
        {
            try
            {
                using (var db = new DymContext())
                {

                    db.AddRange(lista);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return false;
        }

        public List<UnidadMedida> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.UnidadMedida.ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return null;
        }

        public List<UnidadMedida> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.UnidadMedida.Take(cantidad).ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return null;
        }

        public UnidadMedida SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.UnidadMedida.FirstOrDefault(x => x.UnidadMedidaId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return null;
        }

        public List<UnidadMedida> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.UnidadMedida.Where(x => x.UnidadMedidaId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return null;
        }

        public bool Update(UnidadMedida o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("UnidadMedidaController:: " + ex.ToString());
            }

            return false;
        }
    }
}
