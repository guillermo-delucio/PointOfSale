using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Query
    {
        public string QueryId { get; set; }
        public string Sql { get; set; }
        public string Descripcion { get; set; }
    }
}
