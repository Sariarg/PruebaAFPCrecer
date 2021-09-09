using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClinicasa.Models
{
    public class Expediente
    {
        public int Cita { get; set; }
        public string Observacion { get; set; }
        public string Medicamento { get; set; }
        public string Diagnostico { get; set; }
    }
}