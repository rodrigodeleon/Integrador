using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Compra
    {
        private int id;
        private Persona cliente;
        private DateTime fecha;
        private ICollection<TransporteCompra> transportes;
        private ICollection<ExcursionCompra> excursiones;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public  virtual Persona Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Compra")]
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }
        public virtual ICollection<TransporteCompra> Transportes
        {
            get
            {
                return transportes;
            }

            set
            {
                transportes = value;
            }
        }
        public virtual ICollection<ExcursionCompra> Excursiones
        {
            get
            {
                return excursiones;
            }

            set
            {
                excursiones = value;
            }
        }

        public Compra()
        {
            transportes = new List<TransporteCompra>();
            excursiones = new List<ExcursionCompra>();
                
        }

        public int getCosto()
        {
            int costo = 0;
            foreach (ExcursionCompra e in Excursiones)
            {
                costo += e.Excursion.getCosto() * e.Cantidad;
            }
            foreach (TransporteCompra t in Transportes)
            {
                costo += t.Transporte.Costo * t.Cantidad;
            }
            return costo;
        }

    }
}