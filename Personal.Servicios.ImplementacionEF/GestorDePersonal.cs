using Personal.Dominio.Entidades;
using Personal.Infraestructura.ContextoDeDatos;
using Personal.Servicios.Interfacez;
using Personal.Servicios.Interfacez.Peticiones;
using Personal.Servicios.Interfacez.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Servicios.ImplementacionEF
{
    public class GestorDePersonal : IGestorDePersonal
    {
        public IEnumerable<ActividadRegistrada> ListarTodasLasActividadesRegistradas()
        {
            using (var db = new PersonalDb())
            {
                return db.Actividades.Select(x => new
                {
                    NombrePersona = x.Persona.Nombre,
                    NombreDelProyecto = x.Proyecto.Nombre,
                    NombreDeLaActividad = x.Nombre,
                    Estado = x.Estado,
                    HoraInicio = x.HoraInicio,
                    HoraFin = x.HoraDeFin,
                    Id = x.Id
                })
                .ToList()
                .Select(x => new ActividadRegistrada()
                {
                    EstadoDeLaActividad = x.Estado.ToString(),
                    NombreDeLaActividad = x.NombreDeLaActividad,
                    HoraFin = x.HoraFin,
                    HoraInicio = x.HoraInicio,
                    Id = x.Id,
                    NombreDeLaPersona = x.NombrePersona,
                    NombreDelProyecto = x.NombreDelProyecto
                });
            }
        }

        public IEnumerable<PersonaRegistrada> ListarTodasLasPersonasRegistradas()
        {
            using (var db = new PersonalDb())
            {
                return db.Personas.ToList().Select(x => new PersonaRegistrada()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                });
            }
        }

        public IEnumerable<ProyectoRegistrado> ListarTodosLosProyectos()
        {
            using (var db = new PersonalDb())
            {
                return db.Proyectos.ToList().Select(x => new ProyectoRegistrado()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                });
            }
        }

        public ActividadRegistrada RegistrarNuevaActividad(CrearActividad crearActividad)
        {
            var actividad = new Actividad()
            {
                Estado = crearActividad.Estado,
                HoraDeFin = crearActividad.HoraFin,
                HoraInicio = crearActividad.HoraInicio,
                Nombre = crearActividad.Nombre,
                Observacion = crearActividad.Observacion,
                PersonaId = crearActividad.IdPersona,
                ProyectoId = crearActividad.IdProyecto                
            };


            using (var db = new PersonalDb())
            {
                db.Actividades.Add(actividad);
                db.SaveChanges();
                return new ActividadRegistrada()
                {
                    EstadoDeLaActividad = actividad.Estado.ToString(),
                    NombreDeLaActividad = actividad.Nombre,
                    HoraFin = actividad.HoraDeFin,
                    HoraInicio = actividad.HoraInicio,
                    Id = actividad.Id,
                    NombreDeLaPersona = db.Personas.Find(actividad.PersonaId).Nombre,
                    NombreDelProyecto = db.Proyectos.Find(actividad.ProyectoId).Nombre,
                };
            }
        }
    }
}
