using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoAlmacen = new HashSet<ProductoAlmacen>();
            ProductoImpuesto = new HashSet<ProductoImpuesto>();
            ProductoSustancia = new HashSet<ProductoSustancia>();
        }

        public string ProductoId { get; set; }
        public string CategoriaId { get; set; }
        public string PresentacionId { get; set; }
        public string LaboratorioId { get; set; }
        public string Descripcion { get; set; }
        public string Unidades { get; set; }
        public int? Stock { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioCaja { get; set; }
        public decimal? Precio1 { get; set; }
        public decimal? Precio2 { get; set; }
        public decimal? Precio3 { get; set; }
        public decimal? Precio4 { get; set; }
        public decimal? Utilidad1 { get; set; }
        public decimal? Utilidad2 { get; set; }
        public decimal? Utilidad3 { get; set; }
        public decimal? Utilidad4 { get; set; }
        public bool TieneLote { get; set; }
        public bool IsDeleted { get; set; }
        public string CratedBy { get; set; }
        public DateTime CratedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public string LoteId { get; set; }
        public string UnidadMedidaId { get; set; }
        public string ClaveCfdiId { get; set; }
        public string UnidadCfdi { get; set; }
        public string Contenido { get; set; }
        public string RutaImg { get; set; }

        public virtual ICollection<ProductoAlmacen> ProductoAlmacen { get; set; }
        public virtual ICollection<ProductoImpuesto> ProductoImpuesto { get; set; }
        public virtual ICollection<ProductoSustancia> ProductoSustancia { get; set; }
    }
}
