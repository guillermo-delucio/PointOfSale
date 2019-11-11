using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class ActualizacionController
    {
        public bool Delete(Actualizacion o)
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
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool Delete(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    var temp = db.Actualizacion.FirstOrDefault(x => x.ActualizacionId == Id);
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
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Actualizacion o)
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
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Actualizacion> lista)
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
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

        public List<Actualizacion> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Actualizacion.ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<Actualizacion> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Actualizacion.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public Actualizacion SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.Actualizacion.FirstOrDefault(x => x.ActualizacionId == Id);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }


        public bool Update(Actualizacion o)
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
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return false;
        }

    }
}
