using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class UsuarioRole
    {
        public string UsuarioId { get; set; }
        public string RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Role Role { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
