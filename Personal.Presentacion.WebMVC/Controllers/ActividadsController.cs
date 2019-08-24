using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Personal.Dominio.Entidades;
using Personal.Infraestructura.ContextoDeDatos;

namespace Personal.Presentacion.WebMVC.Controllers
{
    public class ActividadsController : Controller
    {
        private PersonalDb db = new PersonalDb();

        // GET: Actividads
        public ActionResult Index()
        {
            var actividades = db.Actividades.Include(a => a.Persona).Include(a => a.Proyecto);
            return View(actividades.ToList());
        }

        // GET: Actividads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividades.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // GET: Actividads/Create
        public ActionResult Create()
        {
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombre");
            ViewBag.ProyectoId = new SelectList(db.Proyectos, "Id", "Nombre");
            return View();
        }

        // POST: Actividads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,HoraInicio,HoraDeFin,Estado,Observacion,PersonaId,ProyectoId,DiaDeCreacion")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Actividades.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombre", actividad.PersonaId);
            ViewBag.ProyectoId = new SelectList(db.Proyectos, "Id", "Nombre", actividad.ProyectoId);
            return View(actividad);
        }

        // GET: Actividads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividades.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombre", actividad.PersonaId);
            ViewBag.ProyectoId = new SelectList(db.Proyectos, "Id", "Nombre", actividad.ProyectoId);
            return View(actividad);
        }

        // POST: Actividads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,HoraInicio,HoraDeFin,Estado,Observacion,PersonaId,ProyectoId,DiaDeCreacion")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonaId = new SelectList(db.Personas, "Id", "Nombre", actividad.PersonaId);
            ViewBag.ProyectoId = new SelectList(db.Proyectos, "Id", "Nombre", actividad.ProyectoId);
            return View(actividad);
        }

        // GET: Actividads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividades.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // POST: Actividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividad actividad = db.Actividades.Find(id);
            db.Actividades.Remove(actividad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
