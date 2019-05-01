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

            try
            {
                using (var db = new DymContext())
                {
                    foreach (var item in lista)
                    {
                        var producto = db.Producto.FirstOrDefault(x => x.ProductoId == item.ProductoId);
                        var sustancia = db.Sustancia.FirstOrDefault(x => x.SustanciaId == item.SustanciaId);
                        if (producto != null && sustancia != null)
                        {

                            var prodsus = new ProductoSustancia();
                            prodsus.ProductoId = producto.ProductoId;
                            prodsus.SustanciaId = sustancia.SustanciaId;
                            prodsus.Contenido = item.Contenido;

                            listaCorrectos.Add(prodsus);
                         
                        }
                        else
                        {
                            errores.Add(item.SustanciaId + ", NO EXISTE EN LAS SUSTANCIAS o, "+item.ProductoId+ ", NO EXISTE EN LOS PRODUCTOS");
                        }
                    }
                    db.ProductoSustancia.AddRange(listaCorrectos);
                    db.SaveChanges();
                    correctos += "SE GUARDARON " + listaCorrectos.Count + " REGISTOS\n\n";
                    correctos += "SE OMITIERON " + errores.Count + " REGISTOS\n\n";
                    correctos += "COPIE Y PEGUE LOS DETALLES\n\n ";
                    var result = String.Join(" \n ", errores.ToArray());
                    correctos += result;
                }
            }
            catch (Exception ex)
            {

                Ambiente.Mensaje(Ambiente.CatalgoMensajes[-1] + "@"+ this.GetType().Name+"\n" + ex.ToString());
            }

            return correctos;

        }

    }
}
