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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Cliente o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Cliente> lista)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return false;
        }

        public List<Cliente> SelectAll()
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return null;
        }

        public List<Cliente> SelectMany(int cantidad)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return null;
        }

        public Cliente SelectOne(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return null;
        }

        public List<Cliente> SelectOneOverList(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Cliente o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @ClienteController\n" + ex.ToString());
            }
            return false;
        }
    }
}
