using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    class LoteController : IController<Lote>
    {

        public bool Delete(Lote o)
        {
            try
            {
                using (var db = new DymContext())
                {

                    db.Remove(o);
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
                    var temp = db.Lote.FirstOrDefault(x => x.LoteId == Id.Trim());
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
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Lote o)
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

        public bool InsertRange(List<Lote> lista)
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

        public List<Lote> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Lote> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public List<Lote> SelectMany(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.Where(x => x.LoteId == Id && x.StockRestante > 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public Lote SelectOne(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.FirstOrDefault(x => x.LoteId == Id.Trim());
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Lote> SelectOneOverList(string Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Lote.Where(x => x.LoteId == Id.Trim()).ToList();
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Lote o)
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

        public Tuple<string, DateTime> TraeDatosLote(Producto producto, decimal cantidad)
        {

            Tuple<string, DateTime> datos;// = Tuple.Create("", DateTime.Now);
            string sLote = "";
            DateTime caducidad = DateTime.Now;

            if (producto.TieneLote && cantidad > 0)
            {
                using (var db = new DymContext())
                {
                    var lotes = db.Lote.Where(x => x.ProductoId.Equals(producto.ProductoId) && x.StockRestante > 0).OrderBy(x => x.CreatedAt).ToList();
                    foreach (var lote in lotes)
                    {
                        if (lote.StockRestante >= cantidad && cantidad > 0)
                        {
                            sLote += lote.LoteId + ",";
                            caducidad = (DateTime)lote.Caducidad;
                            cantidad = 0;
                        }
                        else if (cantidad > 0)
                        {
                            sLote += lote.LoteId + ",";
                            caducidad = (DateTime)lote.Caducidad;
                            cantidad -= (decimal)lote.StockRestante;


                        }
                    }
                    if (sLote.EndsWith(","))
                        sLote = sLote.Substring(0, sLote.LastIndexOf(","));

                    datos = Tuple.Create(sLote, caducidad);
                    return datos;
                }
            }
            else
            {
                return Tuple.Create("", DateTime.Now);
            }
        }
        public bool RestaLote(Producto producto, decimal cantidad)
        {

            Tuple<string, DateTime> datos;// = Tuple.Create("", DateTime.Now);
            string sLote = "";
            DateTime caducidad = DateTime.Now;
            int afectados = 0;
            if (producto.TieneLote && cantidad > 0)
            {
                using (var db = new DymContext())
                {
                    var lotes = db.Lote.Where(x => x.ProductoId.Equals(producto.ProductoId) && x.StockRestante > 0).OrderBy(x => x.CreatedAt).ToList();
                    foreach (var lote in lotes)
                    {
                        if (lote.StockRestante >= cantidad && cantidad > 0)
                        {
                            sLote += lote.LoteId + ",";
                            caducidad = (DateTime)lote.Caducidad;
                            lote.StockRestante -= cantidad;
                            db.Update(lote);
                            afectados = db.SaveChanges();
                            cantidad = 0;
                        }
                        else if (cantidad > 0)
                        {
                            sLote += lote.LoteId + ",";
                            caducidad = (DateTime)lote.Caducidad;
                            cantidad -= (decimal)lote.StockRestante;
                            lote.StockRestante = 0;
                            db.Update(lote);
                            afectados = db.SaveChanges();
                        }
                    }
                    if (afectados > 0)
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
