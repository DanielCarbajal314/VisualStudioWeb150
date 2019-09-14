using Microsoft.AspNet.SignalR;
using Personal.Presentacion.WebMVC.Filtros;
using Personal.Presentacion.WebMVC.Hubs;
using Personal.Servicios.ImplementacionEF;
using Personal.Servicios.Interfacez;
using Personal.Servicios.Interfacez.Peticiones;
using Personal.Servicios.Interfacez.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Personal.Presentacion.WebMVC.Controllers
{
    public class GestionDeActividadesController : ApiController
    {

        IGestorDePersonal _gestorDePersonal = new GestorDePersonal();

        [HttpGet]
        public IEnumerable<ActividadRegistrada> Actividades()
        {
            return this._gestorDePersonal.ListarTodasLasActividadesRegistradas();
        }

        [HttpGet]
        public IEnumerable<PersonaRegistrada> Personal()
        {
            return this._gestorDePersonal.ListarTodasLasPersonasRegistradas();
        }

        [HttpGet]
        public IEnumerable<ProyectoRegistrado> Proyectos()
        {
            return this._gestorDePersonal.ListarTodosLosProyectos();
        }

        [HttpPost]
        public ActividadRegistrada RegistrarNuevaActividad(CrearActividad crearActividad)
        {
            var nuevaActividadRegistrada = this._gestorDePersonal.RegistrarNuevaActividad(crearActividad);

            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            string message = "Se registro una nueva actividad con id " + nuevaActividadRegistrada.Id;
            context.Clients.All.NewNotificationPushed(message);

            return nuevaActividadRegistrada;
        }
    }
}
