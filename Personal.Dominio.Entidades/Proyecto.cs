using Personal.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Dominio.Entidades
{
    public class Proyecto: TEntidadBase
    {
        public string Nombre { get; set; }
        public virtual HashSet<Persona> Personas { get; set; }
        public virtual HashSet<Actividad> Actividades { get; set; }
    }
}
