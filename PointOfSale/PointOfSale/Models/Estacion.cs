using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Estacion
    {
        public string EstacionId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }
        public string ImpresoraT { get; set; }
        public string ImpresoraR { get; set; }
        public string ImpresoraF { get; set; }
        public string ImpresoraNc { get; set; }
        public int DefaultAlmacenId { get; set; }
    }
}
