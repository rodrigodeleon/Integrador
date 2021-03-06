﻿using System;
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
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Validation;

namespace Integrador.Controllers
{
    public class ExcursionesController : Controller
    {
        private IntegradorContext db = new IntegradorContext();

        // GET: Excursiones
        public ActionResult Index()
        {
            return View(db.Excursions.Where(x => x.Activa == true).ToList());
        }
        // GET: Excursiones por ci
        public ActionResult IndexCi(int? ci)
        {
            try
            {
                ViewBag.Ci = ci;
                return View("Index", db.Excursions.Where(x => x.Creador.Ci == ci && x.Activa == true).ToList());
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        // GET: Excursiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excursion excursion = db.Excursions.Find(id);
            if (excursion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Costo = excursion.getCosto();
            return View(excursion);
        }

        // GET: Excursiones/Create
        public ActionResult Create()
        {
            Tramo aux = new Tramo();
            Destino d = new Destino();
            Transporte t = new Transporte();
            aux.Destino = d;

            var model = new ExcursionViewModel
            {
                miTransporte = t,
                miTramo = aux,
                miExcursion = new Excursion(),
                Transportes = TransportesController.GetTransportes(),
                Destinos = DestinosController.GetDestinos(),
                Clientes = PersonasController.GetPersonas()
            };
            return View(model);
        }

        // POST: Excursiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExcursionViewModel excursionVM)
        {
            try
            {
                db.Excursions.Add(crearExcursion(excursionVM));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return View(excursionVM);
            }

        }


        public Excursion crearExcursion(ExcursionViewModel excursionVM)
        {
            try
            {
                excursionVM.miExcursion.Activa = true;
                excursionVM.miExcursion.Creador = db.Personas.Find(excursionVM.miExcursion.Creador.Id);
                excursionVM.miExcursion.Tramos = new List<Tramo>();
                excursionVM.miExcursion.Transportes = new List<Transporte>();

                JavaScriptSerializer oJS = new JavaScriptSerializer();
                IEnumerable<IDictionary<String, String>> aux = (IEnumerable<IDictionary<String, String>>)oJS.Deserialize(excursionVM.tramosJson, typeof(IEnumerable<IDictionary<String, String>>));
                foreach (IDictionary<String, String> res in aux)
                {
                    string id = res["Id"];
                    string arribo = res["Arribo"];
                    string partida = res["Partida"];

                    Tramo miTramo = new Tramo(db.Destinos.Find(int.Parse(id)), DateTime.Parse(arribo), DateTime.Parse(partida));
                    excursionVM.miExcursion.Tramos.Add(miTramo);
                }
                aux = (IEnumerable<IDictionary<String, String>>)oJS.Deserialize(excursionVM.transportesJson, typeof(IEnumerable<IDictionary<String, String>>));
                foreach (IDictionary<String, String> res in aux)
                {
                    Console.Write(res.Keys);
                    string id = res["Id"];
                    excursionVM.miExcursion.Transportes.Add(db.Transportes.Find(int.Parse(id)));
                }

                excursionVM.miExcursion.getDuracion();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return excursionVM.miExcursion;

        }

        public ActionResult calcularCosto(ExcursionViewModel excursionVM)
        {
            excursionVM.miExcursion = new Excursion();
            excursionVM.miExcursion.Creador = new Persona();
            excursionVM.miExcursion.Creador.Id = 1;
            int costo = crearExcursion(excursionVM).getCosto();
            return Json(new[] {
            new { Costo = costo } }, JsonRequestBehavior.AllowGet);
        }


        public static IEnumerable<SelectListItem> GetExcursiones()
        {
            IntegradorContext sdb = new IntegradorContext();
            var exc = sdb.Excursions.Where(x => x.Activa == true).ToList();
            List<SelectListItem> sl = new List<SelectListItem>();
            foreach (Excursion a in exc)
            {
                string text = "Nombre: " + a.Nombre + "  -   Descripcion: " + a.Descripcion + " - Destinos Incluidos: ";

                foreach (Tramo t in a.Tramos)
                {
                    text += (t.Destino.Nombre) + ", ";
                }
                text += " - Duracion: " + a.Duracion.ToString() + " dias";
                text += " - Costo Total: $" + a.getCosto().ToString();
                sl.Add(new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = text
                });
            };
            return new SelectList(sl, "Value", "Text");

        }

        // GET: Excursiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excursion excursion = db.Excursions.Find(id);
            if (excursion == null)
            {
                return HttpNotFound();
            }
            return View(excursion);
        }

        // POST: Excursiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Duracion,Activa")] Excursion excursion)
        {
            try
            {
                Excursion e = db.Excursions.Find(excursion.Id);
                e.Nombre = excursion.Nombre;
                e.Descripcion = excursion.Descripcion;
                e.Creador = db.Personas.Find(e.Creador.Id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(excursion);
            }
        }

        // GET: Excursiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excursion excursion = db.Excursions.Find(id);
            if (excursion == null)
            {
                return HttpNotFound();
            }
            return View(excursion);
        }

        // POST: Excursiones/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Excursion excursion = db.Excursions.Find(id);
                excursion.Activa = false;
                excursion.Creador = db.Personas.Find(excursion.Creador.Id);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
                return View();
            }
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
