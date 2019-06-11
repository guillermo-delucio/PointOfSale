using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CambiosPrecio = new HashSet<CambiosPrecio>();
            Lote = new HashSet<Lote>();
            ProductoSustancia = new HashSet<ProductoSustancia>();
        }

        public string ProductoId { get; set; }
        public string CategoriaId { get; set; }
        public string PresentacionId { get; set; }
        public string LaboratorioId { get; set; }
        public string Descripcion { get; set; }
        public string Unidades { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioCaja { get; set; }
        public decimal Precio1 { get; set; }
        public decimal Precio2 { get; set; }
        public decimal Precio3 { get; set; }
        public decimal Precio4 { get; set; }
        public decimal Utilidad1 { get; set; }
        public decimal Utilidad2 { get; set; }
        public decimal Utilidad3 { get; set; }
        public decimal Utilidad4 { get; set; }
        public bool TieneLote { get; set; }
        public bool IsDeleted { get; set; }
        public string CratedBy { get; set; }
        public DateTime CratedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public string LoteId { get; set; }
        public string UnidadMedidaId { get; set; }
        public string ClaveProdServId { get; set; }
        public string ClaveUnidadId { get; set; }
        public string Contenido { get; set; }
        public string RutaImg { get; set; }
        public bool ChkCaducidad { get; set; }
        public int DiasCredito { get; set; }
        public string Impuesto1Id { get; set; }
        public string Impuesto2Id { get; set; }
        public string Impuesto3Id { get; set; }
        public string AlmacenId { get; set; }
        public bool? Ocupado { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Impuesto Impuesto1 { get; set; }
        public virtual Impuesto Impuesto2 { get; set; }
        public virtual Impuesto Impuesto3 { get; set; }
        public virtual Laboratorio Laboratorio { get; set; }
        public virtual Presentacion Presentacion { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual ICollection<CambiosPrecio> CambiosPrecio { get; set; }
        public virtual ICollection<Lote> Lote { get; set; }
        public virtual ICollection<ProductoSustancia> ProductoSustancia { get; set; }
    }
}
