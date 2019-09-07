using Personal.Dominio.Entidades;
using Personal.Infraestructura.ContextoDeDatos;
using Personal.Servicios.Interfacez;
using Personal.Servicios.Interfacez.Peticiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Servicios.ImplementacionEF
{
    public class GestorDeErrores : IGestorDeErrores
    {
        public int RegistrarExcepcion(CrearExcepcion crearExcepcion)
        {
            using (var db = new PersonalDb())
            {
                var nuevaExcepcion = new LogDeExcepcion()
                {
                    Content = crearExcepcion.Contenido,
                    Mensaje = crearExcepcion.Excepcion.Message,
                    Stack = crearExcepcion.Excepcion.StackTrace,
                    Uri = crearExcepcion.Uri
                };
                db.LogDeExcepciones.Add(nuevaExcepcion);
                db.SaveChanges();
                return nuevaExcepcion.Id;
            }
        }
    }
}
