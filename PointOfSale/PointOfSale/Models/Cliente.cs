using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Cliente
    {
        public string ClienteId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }
    }
}
