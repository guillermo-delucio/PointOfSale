using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Traspaso
    {
        public Traspaso()
        {
            Traspasop = new HashSet<Traspasop>();
        }

        public int TraspasoId { get; set; }
        public string Documento { get; set; }
        public DateTime FechaDocumento { get; set; }
        public int? SucursalOrigenId { get; set; }
        public string SucursalOrigenName { get; set; }
        public string SerieOrigen { get; set; }
        public int? SucursalDestinoId { get; set; }
        public string SucursalDestinoName { get; set; }
        public string SerieDestino { get; set; }
        public bool Enviado { get; set; }
        public bool Aplicado { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string TipoDocId { get; set; }
        public string EstadoDocId { get; set; }

        public virtual Sucursal SucursalDestino { get; set; }
        public virtual Sucursal SucursalOrigen { get; set; }
        public virtual ICollection<Traspasop> Traspasop { get; set; }
    }
}
