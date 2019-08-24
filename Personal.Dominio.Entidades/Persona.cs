using Personal.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Dominio.Entidades
{
    public class Persona: TEntidadBase
    {
        public string Nombre { get; set; }
        public virtual HashSet<Proyecto> Proyectos { get; set; }
        public virtual HashSet<Actividad> Actividades { get; set; }
    }
}
