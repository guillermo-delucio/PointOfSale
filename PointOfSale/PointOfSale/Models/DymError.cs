using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class DymError
    {
        public int DymErrorId { get; set; }
        public string Message { get; set; }
        public string ToString { get; set; }
        public string VentaId { get; set; }
        public string LoggedUser { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
