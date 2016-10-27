using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class ExcursionCompra
    {
        private int id;
        private Excursion excursion;
        private int cantidad;

        [Required]
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
        [Required]
        public virtual Excursion Excursion
        {
            get
            {
                return excursion;
            }

            set
            {
                excursion = value;
            }
        }
        [Required]
        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public ExcursionCompra()
        {

        }

        public ExcursionCompra( Excursion excursion, int cantidad)
        {
            Excursion = excursion;
            Cantidad = cantidad;
        }
    }
}