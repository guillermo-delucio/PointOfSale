using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Lote
    {
        public string LoteId { get; set; }
        public string ProductoId { get; set; }
        public DateTime? Caducidad { get; set; }
        public int? ExistenciaInicial { get; set; }
        public int? Restante { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
