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
using Newtonsoft.Json;

namespace Integrador.Controllers
{
    public class TransportesController : Controller
    {
        private IntegradorContext db = new IntegradorContext();

        // GET: Transportes
        public ActionResult Index()
        {
            return View(db.Transportes.ToList());
        }

        // GET: Transportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = db.Transportes.Find(id);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }
       
        public static IEnumerable<SelectListItem> GetTransportes()
        {
            IntegradorContext sdb = new IntegradorContext();

            var Transportes = sdb.Transportes.Select
                       (x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = "Desde: "+ x.Origen.Nombre + "  -   Hasta: " + x.Destino.Nombre + "  -   Medio: "+x.Medio+"  -   Costo: $"+ x.Costo ,
                                });

            return new SelectList(Transportes, "Value", "Text");

        }

        public ActionResult getTransportes(int origenId , int destinoId)
        {
            if (db.Destinos.Find(origenId).Costa == true && db.Destinos.Find(destinoId).Costa == true)
            {

                return Json(new[] {
            new { Id = 1, Value = "Aereo" },
            new { Id = 2, Value = "Terrestre" },
            new { Id = 3, Value = "Barco" },
             }, JsonRequestBehavior.AllowGet);

            }

            return Json(new[] {
            new { Id = 1, Value = "Aereo" },
            new { Id = 2, Value = "Terrestre" },
             }, JsonRequestBehavior.AllowGet);

        }

       
        // GET: Transportes/Create
        public ActionResult Create()
        {

            var model = new TransporteViewModel
            {
                miTransporte = new Transporte(),
                Destinos = DestinosController.GetDestinos()

            };
            return View(model);


        }

        // POST: Transportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransporteViewModel miDTV)
        {
            try
            {
                miDTV.miTransporte.Activo = true;
                miDTV.miTransporte.Origen = db.Destinos.Find(miDTV.miTransporte.Origen.Id);
                miDTV.miTransporte.Destino = db.Destinos.Find(miDTV.miTransporte.Destino.Id);
                db.Transportes.Add(miDTV.miTransporte);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }

        }

        // GET: Transportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = db.Transportes.Find(id);

            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Costo,Medio")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transporte);
        }

        // GET: Transportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporte transporte = db.Transportes.Find(id);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transporte transporte = db.Transportes.Find(id);
            transporte.Activo = false;
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
