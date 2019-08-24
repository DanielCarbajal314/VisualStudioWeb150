using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Servicios.Interfacez.Respuestas
{
    public class ActividadRegistrada
    {
        public int Id { get; set; }
        public string NombreDelProyecto { get; set; }
        public string NombreDeLaPersona { get; set; }
        public string NombreDeLaActividad { get; set; }
        public string EstadoDeLaActividad { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
