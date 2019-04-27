using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Role
    {
        public Role()
        {
            RolePermiso = new HashSet<RolePermiso>();
            UsuarioRole = new HashSet<UsuarioRole>();
        }

        public string RoleId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RolePermiso> RolePermiso { get; set; }
        public virtual ICollection<UsuarioRole> UsuarioRole { get; set; }
    }
}
