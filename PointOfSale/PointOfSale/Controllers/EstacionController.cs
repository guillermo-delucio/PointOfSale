using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class EstacionController:IController<Estacion>
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Estacion o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Estacion> lista)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return false;
        }

        public List<Estacion> SelectAll()
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return null;
        }

        public List<Estacion> SelectMany(int cantidad)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return null;
        }

        public Estacion SelectOne(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return null;
        }

        public List<Estacion> SelectOneOverList(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Estacion o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @EstacionController\n" + ex.ToString());
            }
            return false;
        }
    }
}
