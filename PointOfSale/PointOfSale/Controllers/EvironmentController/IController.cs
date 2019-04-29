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
        bool Add(T o);

        T Read(string Id);

        bool Update(T o);

        bool Delete(string Id);

        List<T> List(int cantidad);

        bool Addrange(List<T> lista);
    }
}
