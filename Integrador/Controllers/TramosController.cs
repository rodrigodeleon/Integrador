using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrador.Models;
using Integrador.ViewModels;

namespace Integrador.Controllers
{
    public class TramosController : Controller
    {
        private IntegradorContext db = new IntegradorContext();

        // GET: Tramos
        public ActionResult Index()
        {
            return View(db.Tramoes.ToList());
        }

        // GET: Tramos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tramo tramo = db.Tramoes.Find(id);
            if (tramo == null)
            {
                return HttpNotFound();
            }
            return View(tramo);
        }

        [HttpPost]
        public ActionResult agregarTramo(int destino, DateTime arribo, DateTime partida)
        {
            Tramo miTramo = new Tramo(db.Destinos.Find(destino), arribo, partida);
            
            return Json(miTramo);
        }

        // GET: Tramos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tramos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Arribo,Partida")] Tramo tramo)
        {
            if (ModelState.IsValid)
            {
                db.Tramoes.Add(tramo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tramo);
        }

        // GET: Tramos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tramo tramo = db.Tramoes.Find(id);
            if (tramo == null)
            {
                return HttpNotFound();
            }
            return View(tramo);
        }

        // POST: Tramos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Arribo,Partida")] Tramo tramo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tramo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tramo);
        }

        // GET: Tramos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tramo tramo = db.Tramoes.Find(id);
            if (tramo == null)
            {
                return HttpNotFound();
            }
            return View(tramo);
        }

        // POST: Tramos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tramo tramo = db.Tramoes.Find(id);
            db.Tramoes.Remove(tramo);
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
