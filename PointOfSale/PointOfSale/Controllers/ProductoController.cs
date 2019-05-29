using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class ProductoController : IController<Producto>
    {
        public bool Delete(Producto o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    o.IsDeleted = true;
                    db.Entry(o).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool Delete(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.Producto.FirstOrDefault(x => x.ProductoId == Id.Trim());
                    if (temp != null)
                    {
                        temp.IsDeleted = true;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Producto o)
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
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Producto> lista)
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
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public List<Producto> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Producto

                      
                        .Include(x => x.ProductoSustancia)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Producto> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Producto
                        .Include(x => x.ProductoSustancia)
                        .Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public Producto SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Producto
                        .Include(x => x.ProductoSustancia)
                        .FirstOrDefault(x => x.ProductoId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

       

        public List<Producto> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Producto
                     
                        .Include(x => x.ProductoSustancia)
                        .Where(x => x.ProductoId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Producto o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Entry(o).State = EntityState.Modified;

                    foreach (var item in db.ProductoSustancia.Where(x => x.ProductoId == o.ProductoId).ToList())
                        db.Remove(item);

                    db.SaveChanges();

                    foreach (var sustancia in o.ProductoSustancia)
                        db.Add(sustancia);

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public List<Producto> FiltrarVsDescrip(string SearchText)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Producto
                         
                        .Include(x => x.ProductoSustancia)
                        .Where(x => x.Descripcion.Contains(SearchText.Trim())).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("ProductoController: " + ex.ToString());
            }

            return null;
        }

        public List<Producto> FiltrarVsSustancia(string SearchText)
        {
            try
            {
                using (var db = new DymContext())
                {
                    //var query= db.Categories.Where(c=>c.Category_ID==cat_id).SelectMany(c=>Articles);

                    var query = from prod in db.Producto
                                 
                                   .Include(x => x.ProductoSustancia)
                                where prod.ProductoSustancia.Any(c => c.SustanciaId.Contains(SearchText.Trim()))
                                select prod;
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje("ProductoController: " + ex.ToString());
            }

            return null;
        }
    }
}
