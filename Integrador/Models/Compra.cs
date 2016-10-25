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
        private ICollection<Transporte> transportes;
        private ICollection<Excursion> excursiones;

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

        public Persona Cliente
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

        public virtual ICollection<Transporte> Transportes
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

        public virtual ICollection<Excursion> Excursiones
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
    }
}