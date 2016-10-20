using Integrador.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrador.ViewModels
{
    public class ExcursionViewModel
    {
        public Excursion miExcursion { get; set; }
        public IEnumerable<SelectListItem> Destinos { get; set; }
        public IEnumerable<SelectListItem> Clientes { get; set; }
        public IEnumerable<SelectListItem> Transportes { get; set; }
        public Tramo miTramo { get; set; }
        [Display(Name = "Transporte")]
        public Transporte miTransporte { get; set; }
        public String tramosJson { get; set; }
        public String transportesJson { get; set; }


    }
}