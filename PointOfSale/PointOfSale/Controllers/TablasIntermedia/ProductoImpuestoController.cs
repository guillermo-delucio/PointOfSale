using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers.TablasIntermedia
{
    class ProductoImpuestoController
    {
        public string InsertRange(List<ProductoImpuesto> lista)
        {
            var listaCorrectos = new List<ProductoImpuesto>();
            List<string> errores = new List<string>();
            string correctos = string.Empty;

            try
            {
                using (var db = new DymContext())
                {
                    foreach (var item in lista)
                    {
                        var producto = db.Producto.FirstOrDefault(x => x.ProductoId == item.ProductoId);
                        var impuesto = db.Impuesto.FirstOrDefault(x => x.ImpuestoId == item.ImpuestoId);
                        if (producto != null && impuesto != null)
                        {

                            var prodImp = new ProductoImpuesto();
                            prodImp.ProductoId = producto.ProductoId;
                            prodImp.ImpuestoId = impuesto.ImpuestoId;
                            listaCorrectos.Add(prodImp);

                        }
                        else
                        {
                            errores.Add(item.ImpuestoId + ", NO EXISTE EN LOS IMPUESTOS o, " + item.ProductoId + ", NO EXISTE EN LOS PRODUCTOS");
                        }
                    }
                    db.AddRange(listaCorrectos);
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

                Ambiente.Mensaje(Ambiente.CatalgoErrores[101] + "\n" + "  @ProductoSustanciaController\n" + ex.ToString());
            }

            return correctos;

        }
    }
}
