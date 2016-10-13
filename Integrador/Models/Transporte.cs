using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Transporte
    {
        private int id;
        private Destino origen;
        private Destino destino;
        private int costo;
        private string medio;

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

        [Display(Name = "Origen")]
        public virtual Destino Origen
        {
            get
            {
                return origen;
            }

            set
            {
                origen = value;
            }
        }
        [Display(Name = "Destino")]
        public virtual Destino Destino
        {
            get
            {
                return destino;
            }

            set
            {
                destino = value;
            }
        }
        [Required]
        public int Costo
        {
            get
            {
                return costo;
            }

            set
            {
                costo = value;
            }
        }
        [Required]
        [Display(Name = "Medio de Transporte")]
        public string Medio
        {
            get
            {
                return medio;
            }

            set
            {
                medio = value;
            }
        }

        public Transporte()
        {
                
        }

        public Transporte(Destino origen, Destino destino, int costo, string medio)
        {
            this.Origen = origen;
            this.Destino = destino;
            this.Costo = costo;
            this.Medio = medio;
        }


    }
}