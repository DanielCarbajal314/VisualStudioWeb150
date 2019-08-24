using Personal.Servicios.Interfacez.Peticiones;
using Personal.Servicios.Interfacez.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Servicios.Interfacez
{
    public interface IGestorDePersonal
    {
        IEnumerable<ProyectoRegistrado> ListarTodosLosProyectos();
        IEnumerable<PersonaRegistrada> ListarTodasLasPersonasRegistradas();
        IEnumerable<ActividadRegistrada> ListarTodasLasActividadesRegistradas();
        ActividadRegistrada RegistrarNuevaActividad(CrearActividad crearActividad);
    }
}
