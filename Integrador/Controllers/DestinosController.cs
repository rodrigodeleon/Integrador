using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrador.Models;

namespace Integrador.Controllers
{
    public class DestinosController : Controller
    {
        private IntegradorContext db = new IntegradorContext();

        // GET: Destinos
        public ActionResult Index()
        {
            return View(db.Destinos.Where(x => x.Activo == true).ToList());
        }

        // GET: Destinos/Details/5


        public static IEnumerable<SelectListItem> GetDestinos()
        {
            IntegradorContext sdb = new IntegradorContext();

            var Destinos = sdb.Destinos.Where(x => x.Activo == true).Select
                       (x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Nombre,
                                });

            return new SelectList(Destinos, "Value", "Text");

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // GET: Destinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Pais,CostoDiario,Costa")] Destino destino)
        {
            destino.Activo = true;

            if (ModelState.IsValid)
            {
                db.Destinos.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destino);
        }

        // GET: Destinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Pais,CostoDiario,Costa")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destino);
        }

        // GET: Destinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }

        // POST: Destinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destinos.Find(id);
            destino.Activo = false;
            var transportes = db.Transportes.Where(x => x.Origen.Id == destino.Id || x.Destino.Id == destino.Id).ToList();
            foreach (Transporte t in transportes)
            {
                t.Activo = false;
            }
            var excursiones = db.Excursions.Where(x => x.Activa == true).ToList();
            foreach (Excursion e in excursiones)
            {
                foreach (Tramo t in e.Tramos)
                {
                    if (t.Destino.Id == destino.Id && e.Activa == true)
                    {

                        Excursion excursion = db.Excursions.Find(e.Id);
                        excursion.Activa = false;
                        excursion.Creador = db.Personas.Find(excursion.Creador.Id);
                       
                        db.SaveChanges();
                        e.Activa = false;

                    }
                }

                if (e.Activa == true)
                {
                    foreach (Transporte t in e.Transportes)
                    {
                        if (t.Origen.Id == destino.Id || t.Destino.Id == destino.Id)
                        {
                            Excursion excursion = db.Excursions.Find(e.Id);
                            excursion.Activa = false;
                            excursion.Creador = db.Personas.Find(excursion.Creador.Id);

                            db.SaveChanges();
                            e.Activa = false;
                        }

                    }
                }


            }
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
