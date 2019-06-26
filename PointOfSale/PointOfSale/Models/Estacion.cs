using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Estacion
    {
        public Estacion()
        {
            Compra = new HashSet<Compra>();
            Venta = new HashSet<Venta>();
        }

        public string EstacionId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }
        public string ImpresoraT { get; set; }
        public string ImpresoraF { get; set; }
        public string ImpresoraNc { get; set; }
        public int DefaultAlmacenId { get; set; }
        public bool VenderSinStock { get; set; }
        public bool SolicitarFmpago { get; set; }
        public bool SumarUnidadesPdv { get; set; }

        public virtual ICollection<Compra> Compra { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
