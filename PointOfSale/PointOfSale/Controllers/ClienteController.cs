using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class ClienteController : IController<Cliente>
    {
        public bool Delete(Cliente o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    o.IsDeleted = true;
                    db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    var temp = db.Cliente.FirstOrDefault(x => x.ClienteId == Id.Trim());
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

        public bool InsertOne(Cliente o)
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

        public bool InsertRange(List<Cliente> lista)
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

        public List<Cliente> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Cliente.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public List<Cliente> SelectAllOrderByMonedero()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Cliente.OrderByDescending(x => x.TieneMonedero).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Cliente> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Cliente.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public Cliente SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Cliente.FirstOrDefault(x => x.ClienteId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public Cliente SelectOneByMonedero(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Cliente.FirstOrDefault(x => x.NoTarjetaPuntos == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Cliente> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Cliente.Where(x => x.ClienteId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Cliente o)
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
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }
    }
}
