using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            CambiosPrecio = new HashSet<CambiosPrecio>();
            Compra = new HashSet<Compra>();
            Corte = new HashSet<Corte>();
            Cxc = new HashSet<Cxc>();
            Cxp = new HashSet<Cxp>();
            UsuarioRole = new HashSet<UsuarioRole>();
            Venta = new HashSet<Venta>();
        }

        public string UsuarioId { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
        public string EstacionId { get; set; }
        public bool Facturar { get; set; }
        public bool Reportear { get; set; }

        public virtual ICollection<CambiosPrecio> CambiosPrecio { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Corte> Corte { get; set; }
        public virtual ICollection<Cxc> Cxc { get; set; }
        public virtual ICollection<Cxp> Cxp { get; set; }
        public virtual ICollection<UsuarioRole> UsuarioRole { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
