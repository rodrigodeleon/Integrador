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
using System.Web.Script.Serialization;
using System.Globalization;

namespace Integrador.Controllers
{
    public class ComprasController : Controller
    {
        private IntegradorContext db = new IntegradorContext();

        // GET: Compras
        public ActionResult Index()
        {
            return View(db.Compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            var model = new CompraViewModel();
            return View(model);
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompraViewModel cvm)
        {

            try
            {
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                if (cvm.excursionesJson != null)
                {
                    IEnumerable<IDictionary<String, String>> aux = (IEnumerable<IDictionary<String, String>>)oJS.Deserialize(cvm.excursionesJson, typeof(IEnumerable<IDictionary<String, String>>));
                    foreach (IDictionary<String, String> res in aux)
                    {
                        int id = int.Parse(res["Id"]);
                        int cant = int.Parse(res["Cantidad"]);
                        ExcursionCompra miEC = new ExcursionCompra(db.Excursions.Find(id), cant);
                        cvm.miCompra.Excursiones.Add(miEC);

                    }
                }

                if (cvm.transportesJson != null)
                {
                    IEnumerable<IDictionary<String, String>> aux = (IEnumerable<IDictionary<String, String>>)oJS.Deserialize(cvm.transportesJson, typeof(IEnumerable<IDictionary<String, String>>));
                    foreach (IDictionary<String, String> res in aux)
                    {
                        int id = int.Parse(res["Id"]);
                        int cant = int.Parse(res["Cantidad"]);
                        DateTime fecha = DateTime.Parse(res["Fecha de Viaje"]);
                       // string x = fecha.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                       
                        TransporteCompra miTC = new TransporteCompra(db.Transportes.Find(id), cant,fecha);
                        cvm.miCompra.Transportes.Add(miTC);

                    }
                }
                cvm.miCompra.Cliente = db.Personas.Find(cvm.miCompra.Cliente.Id);

                db.Compras.Add(cvm.miCompra);
                db.SaveChanges();
                return RedirectToAction("Index");


            }

            catch (Exception ex)
            {

                Console.Write(ex.Message);
                return View(cvm);


            }


        }

        public ActionResult calcularCosto(CompraViewModel cvm)
        {
            try
            {
                int costo = 0;
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                if (cvm.excursionesJson != null)
                {
                    IEnumerable<IDictionary<String, String>> aux = (IEnumerable<IDictionary<String, String>>)oJS.Deserialize(cvm.excursionesJson, typeof(IEnumerable<IDictionary<String, String>>));
                    foreach (IDictionary<String, String> res in aux)
                    {
                        int id = int.Parse(res["Id"]);
                        int cant = int.Parse(res["Cantidad"]);

                        costo += db.Excursions.Find(id).getCosto() * cant;

                    }
                }

                if (cvm.transportesJson != null)
                {
                    IEnumerable<IDictionary<String, String>> aux = (IEnumerable<IDictionary<String, String>>)oJS.Deserialize(cvm.transportesJson, typeof(IEnumerable<IDictionary<String, String>>));
                    foreach (IDictionary<String, String> res in aux)
                    {
                        int id = int.Parse(res["Id"]);
                        int cant = int.Parse(res["Cantidad"]);

                        costo += db.Transportes.Find(id).Costo * cant;

                    }
                }
                return Json(new[] {
                         new { Costo = costo } }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception)
            {

                throw;
            }
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
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
