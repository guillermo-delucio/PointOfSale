using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
   public class ImpuestoController: IController<Impuesto>
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Impuesto o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Impuesto> lista)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return false;
        }

        public List<Impuesto> SelectAll()
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return null;
        }

        public List<Impuesto> SelectMany(int cantidad)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return null;
        }

        public Impuesto SelectOne(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return null;
        }

        public List<Impuesto> SelectOneOverList(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Impuesto o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ImpuestoController\n" + ex.ToString());
            }
            return false;
        }
    }
}
