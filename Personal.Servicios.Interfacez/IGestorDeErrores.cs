using Personal.Servicios.Interfacez.Peticiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Servicios.Interfacez
{
    public interface IGestorDeErrores
    {
        int RegistrarExcepcion(CrearExcepcion crearExcepcion);
    }
}
