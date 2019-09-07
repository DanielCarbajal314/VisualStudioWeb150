using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Dominio.Entidades.Compartido
{
    public class ExcepcionControlada : Exception
    {
        public ExcepcionControlada(string mensaje) : base(mensaje) { }
    }
}
