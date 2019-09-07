using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Servicios.Interfacez.Peticiones
{
    public class CrearExcepcion
    {
        public string Contenido { get; set; }
        public string Uri { get; set; }
        public Exception Excepcion { get; set; }
    }
}
