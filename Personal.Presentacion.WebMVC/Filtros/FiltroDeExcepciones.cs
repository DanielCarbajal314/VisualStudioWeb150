using Personal.Dominio.Entidades.Compartido;
using Personal.Servicios.ImplementacionEF;
using Personal.Servicios.Interfacez;
using Personal.Servicios.Interfacez.Peticiones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Personal.Presentacion.WebMVC.Filtros
{
    public class FiltroDeExcepciones: ExceptionFilterAttribute
    {
        IGestorDeErrores _gestorDeErrores = new GestorDeErrores();


        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ExcepcionControlada)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new
                    {
                        MensajeDeError = actionExecutedContext.Exception.Message
                    }
                );
            }
            else {
                // REGISTRAR EN LA BASE DE DATOS
                var idDeRegistro = _gestorDeErrores.RegistrarExcepcion(new CrearExcepcion() {
                    Excepcion = actionExecutedContext.Exception,
                    Uri = actionExecutedContext.Request.RequestUri.ToString(),
                    Contenido = this.sacarContenido(actionExecutedContext)
                });
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new
                    {
                        MensajeDeError = $"Ha ocurrido un problema no controlado, profavor comuniquese con TI y dele este numero para que lo ayuden : {idDeRegistro}"
                    }
                );
            }
            base.OnException(actionExecutedContext);
        }

        private string sacarContenido(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Content.Headers.ContentType.ToString() == "application/json")
            {
                var streamResult = actionExecutedContext.Request.Content.ReadAsStreamAsync().Result;
                using (var stream = new StreamReader(streamResult))
                {
                    stream.BaseStream.Position = 0;
                    return stream.ReadToEnd();
                }                   
            }
            return "";
        }
    }
}