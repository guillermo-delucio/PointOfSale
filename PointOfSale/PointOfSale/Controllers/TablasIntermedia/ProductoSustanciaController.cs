using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers.TablasIntermedia
{
    class ProductoSustanciaController
    {
        public string InsertRange(List<ProductoSustancia> lista)
        {
            List<ProductoSustancia> listaCorrectos = new List<ProductoSustancia>();
            List<string> errores = new List<string>();
            string correctos = string.Empty;
            using (var db = new DymContext())
            {
                foreach (var item in lista)
                {
                    var producto = db.Producto.FirstOrDefault(x => x.ProductoId == item.ProductoId);
                    var sustancia = db.Sustancia.FirstOrDefault(x => x.SustanciaId == item.SustanciaId);
                    if (producto != null || sustancia != null)
                    {
                        listaCorrectos.Add(item);
                    }
                    else
                    {
                        errores.Add(item.SustanciaId + ", NO EXISTE EN LOS SUSTANCIAS o PRODUCTOS\n");
                    }
                }
                db.AddRange(listaCorrectos);
                correctos += "SE GUARDARON " + listaCorrectos.Count + " REGISTOS\n";
                correctos += "SE OMITIERON " + errores.Count + " REGISTOS\n";
                correctos += "COPIE Y PEGUE LOS DETALLES\n ";
                correctos += errores.ToString();
            }
            return correctos;

        }

    }
}
