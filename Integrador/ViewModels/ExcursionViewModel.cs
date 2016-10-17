using Integrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrador.ViewModels
{
    public class ExcursionViewModel
    {
        public Excursion miExcursion { get; set; }
        public IEnumerable<SelectListItem> Destinos { get; set; }
        public Tramo miTramo { get; set; }
        public String tramosJson { get; set; }


    }
}