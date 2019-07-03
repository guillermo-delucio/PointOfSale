using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Configuracion
    {
        public int Id { get; set; }
        public string RutaFormatoTicket { get; set; }
        public string RutaFormatoFactura { get; set; }
        public string RutaFormatoCorte { get; set; }
        public string RutaCortes { get; set; }
        public string RutaComprobantes { get; set; }
        public string RutaPlantillas { get; set; }
        public string RutaCer { get; set; }
        public string RutaKey { get; set; }
        public string RutaCadenaOriginal { get; set; }
    }
}
