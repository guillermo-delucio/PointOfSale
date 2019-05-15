using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class CambiosPrecio
    {
        public int CambioPrecioId { get; set; }
        public string ProductoId { get; set; }
        public decimal PrecioCompraViejo { get; set; }
        public decimal PrecioCompraNuevo { get; set; }
        public decimal? Precio1Viejo { get; set; }
        public decimal? Precio2Viejo { get; set; }
        public string Precio3Viejo { get; set; }
        public string Precio4Viejo { get; set; }
        public string Precio1Nuevo { get; set; }
        public string Precio2Nuevo { get; set; }
        public string Precio3Nuevo { get; set; }
        public string Precio4Nuevo { get; set; }
        public string Utilidad1Viejo { get; set; }
        public string Utilidad2Viejo { get; set; }
        public string Utilidad3Viejo { get; set; }
        public string Utilidad4Viejo { get; set; }
        public string Utilidad1Nuevo { get; set; }
        public string Utilidad2Nuevo { get; set; }
        public string Utilidad3Nuevo { get; set; }
        public string Utilidad4Nuevo { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Estado { get; set; }

        public virtual Usuario CreatedByNavigation { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
