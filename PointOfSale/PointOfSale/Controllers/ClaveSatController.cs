using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    class ClaveSatController : IController<ClaveSat>
    {
        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.ClaveSat.FirstOrDefault(x => x.ClaveSatId == Id.Trim());
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
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return false;
        }

        public bool InsertOne(ClaveSat o)
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
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return false;
        }

        public bool InsertRange(List<ClaveSat> lista)
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
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return false;
        }

        public List<ClaveSat> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.ClaveSat.ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return null;
        }

        public List<ClaveSat> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.ClaveSat.Take(cantidad).ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return null;
        }

        public ClaveSat SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.ClaveSat.FirstOrDefault(x => x.ClaveSatId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return null;
        }

        public List<ClaveSat> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.ClaveSat.Where(x => x.ClaveSatId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return null;
        }

        public bool Update(ClaveSat o)
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
                Ambiente.Mensaje("ClaveSatController:: " + ex.ToString());
            }

            return false;
        }
    }
}
