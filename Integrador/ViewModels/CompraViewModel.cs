using Integrador.Controllers;
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
        public TransporteCompra miTransporteCompra { get; set; }
        public ExcursionCompra miExcursionCompra { get; set; }
        public string transportesJson { get; set; }
        public string excursionesJson { get; set; }

        public CompraViewModel()
        {
            micliente = new Persona();
            miCompra = new Compra();
            miTransporte = new Transporte();
            miExcursion = new Excursion();
            miTransporteCompra = new TransporteCompra();
            miExcursionCompra = new ExcursionCompra();
            Excursiones = ExcursionesController.GetExcursiones();
            Transportes = TransportesController.GetTransportes();
            Clientes = PersonasController.GetPersonas();


        }
    }
}