using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class UnidadMedida
    {
        public string UnidadMedidaId { get; set; }
        public string Nombre { get; set; }
        public string UnidadSat { get; set; }
        public bool IsDeleted { get; set; }
    }
}
