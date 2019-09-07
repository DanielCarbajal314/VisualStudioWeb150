using Personal.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Dominio.Entidades
{
    public class LogDeExcepcion : TEntidadBase
    {
        public string Content { get; set; }
        public string Uri { get; set; }
        public string Stack { get; set; }
        public string Mensaje { get; set; }
    }
}
