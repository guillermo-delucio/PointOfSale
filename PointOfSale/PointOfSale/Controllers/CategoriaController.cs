using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class CategoriaController : IController<Categoria>
    {
        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Categoria o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Categoria> lista)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return false;
        }

        public List<Categoria> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return null;
        }

        public List<Categoria> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return null;
        }

        public Categoria SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return null;
        }

        public List<Categoria> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Categoria o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @CategoriaController\n" + ex.ToString());
            }
            return false;
        }
    }
}
