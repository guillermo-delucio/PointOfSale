using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            RolePermiso = new HashSet<RolePermiso>();
        }

        public string PermisoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RolePermiso> RolePermiso { get; set; }
    }
}
