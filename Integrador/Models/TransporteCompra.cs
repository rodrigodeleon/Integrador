using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class TransporteCompra
    {
        private int id;
        private Transporte transporte;
        private int cantidad;
        private DateTime fecha;

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
        public virtual Transporte Transporte
        {
            get
            {
                return transporte;
            }

            set
            {
                transporte = value;
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
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Viaje")]
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

        public TransporteCompra()
        {
                
        }

        public TransporteCompra(Transporte transporte, int cantidad, DateTime date)
        {
            Transporte = transporte;
            Cantidad = cantidad;
            Fecha = date;

        }
    }
}