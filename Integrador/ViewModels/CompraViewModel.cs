using Integrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrador.ViewModels
{
    public class CompraViewModel
    {
        public Compra miCompra { get; set; }
        public Persona micliente { get; set; }
        public IEnumerable<SelectListItem> Clientes { get; set; }
        public IEnumerable<SelectListItem> Transportes { get; set; }
        public IEnumerable<SelectListItem> Excursiones { get; set; }
        public Transporte miTransporte { get; set; }
        public Excursion miExcursion { get; set; }

    }
}