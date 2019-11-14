using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class DymErrorController
    {
        public bool Delete(DymError o)
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
                    var temp = db.DymError.FirstOrDefault(x => x.DymErrorId == Id);
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

        public bool InsertOne(DymError o)
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

        public bool InsertRange(List<DymError> lista)
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

        public List<DymError> SelectAll()
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.DymError.ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public List<DymError> SelectMany(int cantidad)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.DymError.Take(cantidad).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }

        public DymError SelectOne(int Id)
        {
            try
            {
                using (var db = new DymContext())
                {
                    return db.DymError.FirstOrDefault(x => x.DymErrorId == Id);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Algo salio mal @ " + GetType().Name + "\n" + ex.ToString());
            }
            return null;
        }
     

        public bool Update(DymError o)
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
