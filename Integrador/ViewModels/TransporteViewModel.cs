using Integrador.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrador.ViewModels
{
    public class TransporteViewModel
    {
       
        public IEnumerable<SelectListItem> Destinos  {get ; set;}
        public Transporte miTransporte { get; set; }

    }
}