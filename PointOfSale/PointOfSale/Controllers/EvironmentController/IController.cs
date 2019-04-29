using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Controllers
{
    /*interface para automatizar el mantenimiento de las entidades
     * el tipo es T, es decir ningun tipo en espeficio, es generica
     * para poder implemenarla en cuanquier modelo.
     */
    public interface IController<T>
    {
        #region Operaciones de lectura

        T SelectOne(string Id);
        List<T> SelectOneOverList(string Id);
        List<T> SelectMany(int cantidad);
        List<T> SelectAll();
       

        #endregion


        #region Operaciones de escritura

        bool InsertOne(T o);
        bool InsertRange(List<T> lista);

        #endregion


        #region Operaciones de actualiación

        bool Update(T o);

        #endregion

        #region Operaciones de eliminación

        bool Delete(string Id);

        #endregion

    }
}
