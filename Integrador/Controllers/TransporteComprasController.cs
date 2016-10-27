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
    public class TransporteComprasController : Controller
    {
        private IntegradorContext db = new IntegradorContext();

        // GET: TransporteCompras
        public ActionResult Index()
        {
            return View(db.TransporteCompras.ToList());
        }

        // GET: TransporteCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransporteCompra transporteCompra = db.TransporteCompras.Find(id);
            if (transporteCompra == null)
            {
                return HttpNotFound();
            }
            return View(transporteCompra);
        }

        // GET: TransporteCompras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransporteCompras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cantidad,Fecha")] TransporteCompra transporteCompra)
        {
            if (ModelState.IsValid)
            {
                db.TransporteCompras.Add(transporteCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transporteCompra);
        }

        // GET: TransporteCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransporteCompra transporteCompra = db.TransporteCompras.Find(id);
            if (transporteCompra == null)
            {
                return HttpNotFound();
            }
            return View(transporteCompra);
        }

        // POST: TransporteCompras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cantidad,Fecha")] TransporteCompra transporteCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporteCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transporteCompra);
        }

        // GET: TransporteCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransporteCompra transporteCompra = db.TransporteCompras.Find(id);
            if (transporteCompra == null)
            {
                return HttpNotFound();
            }
            return View(transporteCompra);
        }

        // POST: TransporteCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransporteCompra transporteCompra = db.TransporteCompras.Find(id);
            db.TransporteCompras.Remove(transporteCompra);
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
