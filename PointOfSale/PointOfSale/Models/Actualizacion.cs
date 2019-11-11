using System;
using System.Collections.Generic;

namespace PointOfSale.Models
{
    public partial class Actualizacion
    {
        public int ActualizacionId { get; set; }
        public string Version { get; set; }
        public string ScriptSql { get; set; }
        public bool BatchExitoso { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Applied { get; set; }
        public string Appliedby { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
