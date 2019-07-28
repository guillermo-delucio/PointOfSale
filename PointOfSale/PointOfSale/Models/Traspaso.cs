using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Traspaso
    {
        public Traspaso()
        {
            Traspasop = new HashSet<Traspasop>();
        }

        public int TraspasoId { get; set; }
        public string Documento { get; set; }
        public string SucursalOrigenId { get; set; }
        public string SucursalOrigen { get; set; }
        public string SucursalDestinoId { get; set; }
        public string SucursalDestino { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool Enviado { get; set; }
        public bool Aplicado { get; set; }

        public virtual Sucursal SucursalDestinoNavigation { get; set; }
        public virtual Sucursal SucursalOrigenNavigation { get; set; }
        public virtual ICollection<Traspasop> Traspasop { get; set; }
    }
}
