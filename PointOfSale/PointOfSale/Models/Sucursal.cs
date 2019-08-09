using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            TraspasoSucursalDestino = new HashSet<Traspaso>();
            TraspasoSucursalOrigen = new HashSet<Traspaso>();
        }

        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Serie { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Traspaso> TraspasoSucursalDestino { get; set; }
        public virtual ICollection<Traspaso> TraspasoSucursalOrigen { get; set; }
    }
}
