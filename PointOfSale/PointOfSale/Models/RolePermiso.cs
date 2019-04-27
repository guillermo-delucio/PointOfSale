using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class RolePermiso
    {
        public string RoleId { get; set; }
        public string Permisoid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Permiso Permiso { get; set; }
        public virtual Role Role { get; set; }
    }
}
