using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    class LaboratorioController : IController<Laboratorio>
    {
        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.Laboratorio.FirstOrDefault(x => x.LaboratorioId == Id.Trim());
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
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return false;
        }

        public bool InsertOne(Laboratorio o)
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
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return false;
        }

        public bool InsertRange(List<Laboratorio> lista)
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
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return false;
        }

        public List<Laboratorio> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Laboratorio.ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return null;
        }

        public List<Laboratorio> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Laboratorio.Take(cantidad).ToList();

                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return null;
        }

        public Laboratorio SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Laboratorio.FirstOrDefault(x => x.LaboratorioId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return null;
        }

        public List<Laboratorio> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Laboratorio.Where(x => x.LaboratorioId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return null;
        }

        public bool Update(Laboratorio o)
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
                Ambiente.Mensaje("LaboratorioController: " + ex.ToString());
            }

            return false;
        }
    }
}
