using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    public class LoginController
    {
        public bool AuthenticaUsuario(string userString, string password)
        {

            using (var db = new DymContext())
            {
                var user = db.Usuario.Where(x => x.UsuarioId == userString.Trim())
               .Include(x => x.UsuarioRole)
               .FirstOrDefault();

                if (user != null)
                {
                    if (Decrypt(user.Password).Equals(password.Trim()))
                    {
                        Ambiente.LoggedUser = user;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        /// Encripta una cadena
        public string Encrypt(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        string Decrypt(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

    }

}
