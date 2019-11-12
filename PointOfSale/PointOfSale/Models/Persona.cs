using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Aparterno { get; set; }
        public string Amaterno { get; set; }
        public int? Edad { get; set; }
    }
}
