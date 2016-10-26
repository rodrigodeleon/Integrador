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

        

    }
}