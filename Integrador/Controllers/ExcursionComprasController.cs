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
    public class ExcursionComprasController : Controller
    {
        private IntegradorContext db = new IntegradorContext();

        // GET: ExcursionCompras
        public ActionResult Index()
        {
            return View(db.ExcursionCompras.ToList());
        }

        // GET: ExcursionCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcursionCompra excursionCompra = db.ExcursionCompras.Find(id);
            if (excursionCompra == null)
            {
                return HttpNotFound();
            }
            return View(excursionCompra);
        }

        // GET: ExcursionCompras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExcursionCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad")] ExcursionCompra excursionCompra)
        {
            if (ModelState.IsValid)
            {
                db.ExcursionCompras.Add(excursionCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excursionCompra);
        }

        // GET: ExcursionCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcursionCompra excursionCompra = db.ExcursionCompras.Find(id);
            if (excursionCompra == null)
            {
                return HttpNotFound();
            }
            return View(excursionCompra);
        }

        // POST: ExcursionCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad")] ExcursionCompra excursionCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excursionCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excursionCompra);
        }

        // GET: ExcursionCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcursionCompra excursionCompra = db.ExcursionCompras.Find(id);
            if (excursionCompra == null)
            {
                return HttpNotFound();
            }
            return View(excursionCompra);
        }

        // POST: ExcursionCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExcursionCompra excursionCompra = db.ExcursionCompras.Find(id);
            db.ExcursionCompras.Remove(excursionCompra);
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
