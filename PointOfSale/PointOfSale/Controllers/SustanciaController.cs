using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    class SustanciaController : IController<Sustancia>
    {
        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.Sustancia.FirstOrDefault(x => x.SustanciaId == Id.Trim());
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
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return false;
        }

        public bool InsertOne(Sustancia o)
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
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return false;
        }

        public bool InsertRange(List<Sustancia> lista)
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
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return false;
        }

        public List<Sustancia> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Sustancia.ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return null;
        }

        public List<Sustancia> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Sustancia.Take(cantidad).ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return null;
        }

        public Sustancia SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Sustancia.FirstOrDefault(x => x.SustanciaId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return null;
        }

        public List<Sustancia> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Sustancia.Where(x => x.SustanciaId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return null;
        }

        public bool Update(Sustancia o)
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
                Ambiente.Mensaje("SustanciaController: " + ex.ToString());
            }

            return false;
        }
    }
}
