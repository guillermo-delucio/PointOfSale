using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class VentapController
    {
        public Ventap SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Ventap.FirstOrDefault(x => x.VentapId == Id);
                }
            }
            catch (Exception ex)
            {
                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@" + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
        public bool InsertOne(Ventap o)
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
        public bool UpdateOne(Ventap o)
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
        public bool DeleteOne(Ventap o)
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
