using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Laboratorio
    {
        public string LaboratorioId { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }
    }
}
