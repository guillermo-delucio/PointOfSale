using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            TraspasoSucursalDestinoNavigation = new HashSet<Traspaso>();
            TraspasoSucursalOrigenNavigation = new HashSet<Traspaso>();
        }

        public string SucursalId { get; set; }
        public string Nombre { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Traspaso> TraspasoSucursalDestinoNavigation { get; set; }
        public virtual ICollection<Traspaso> TraspasoSucursalOrigenNavigation { get; set; }
    }
}
