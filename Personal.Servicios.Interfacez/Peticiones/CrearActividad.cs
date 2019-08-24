using Personal.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Servicios.Interfacez.Peticiones
{
    public class CrearActividad
    {
        public int IdPersona { get; set; }
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Observacion { get; set; }
        public EstadoDeLaActividad Estado { get; set; }
    }
}
