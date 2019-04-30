using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class AlmacenController: IController<Almacen>
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertOne(Almacen o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return false;
        }

        public bool InsertRange(List<Almacen> lista)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return false;
        }

        public List<Almacen> SelectAll()
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return null;
        }

        public List<Almacen> SelectMany(int cantidad)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return null;
        }

        public Almacen SelectOne(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return null;
        }

        public List<Almacen> SelectOneOverList(string Id)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return null;
        }

        public bool Update(Almacen o)
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
                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n @UsuarioController\n" + ex.ToString());
            }
            return false;
        }
    }
}
