using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class VentaController
    {
        public Venta SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Venta.FirstOrDefault(x => x.VentaId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public Venta SelectTicket(int NoRef)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Venta.FirstOrDefault(x => x.NoRef == NoRef && x.Anulada == false && x.EstadoDocId.Equals("CON") && x.TipoDocId.Equals("TIC"));
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public bool InsertOne(Venta o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Add(o);
                    if (db.SaveChanges() > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }
        public bool UpdateOne(Venta o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Entry(o).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }
        public bool DeleteOne(Venta o)
        {
            try
            {
                using (var db = new DymContext())
                {
                    db.Remove(o);
                    if (db.SaveChanges() > 0)
                        return true;
                    else
                        return false;
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
