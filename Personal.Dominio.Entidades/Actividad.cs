using Personal.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Dominio.Entidades
{
    public class Actividad :TEntidadBase
    {
        public string Nombre { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraDeFin { get; set; }
        public EstadoDeLaActividad Estado { get; set; }
        public string Observacion { get; set; }
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
