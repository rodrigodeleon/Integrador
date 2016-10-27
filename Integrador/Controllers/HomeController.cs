using Integrador.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrador.Controllers
{
    public class HomeController : Controller
    {
        IntegradorContext db = new IntegradorContext();
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["acceso"] != null)
                return RedirectToAction("Home", "Home");

            return View();
        }
        [HttpPost]
        public ActionResult Index(Administrador u)
        {
            List<Administrador> admins = db.Personas.OfType<Administrador>().ToList();
            Administrador usuario = null;

            foreach (Administrador a in admins)
            {
                if (a.Ci == u.Ci)
                {
                    if (a.Password == u.Password)
                    {
                        Session["acceso"] = a;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Contrasena Incorrecta");
                        return View();
                    }
                }
            }
            if (usuario == null)
            {
                ModelState.AddModelError("", "No existe Administrador con esa Cedula de Identidad");
                return View();
            }

            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["acceso"] = null;
            return RedirectToAction("Index");

        }
        public ActionResult Home()
        {
            Administrador a = (Administrador)Session["acceso"];

            return View(a);
        }

    }
}