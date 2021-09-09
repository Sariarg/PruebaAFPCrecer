using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIClinicasa.Models
{
    public class Cita
    {
        public int Paciente { get; set; }
        public int Citaid { get; set; }
        public int Doctor { get; set; }
        public int Hora { get; set; }
        public DateTime fecha { get; set; }
    }
}