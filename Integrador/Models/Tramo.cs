using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Tramo
    {
        private int id;
        private Destino destino;
        private DateTime arribo;
        private DateTime partida;

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
        [DataType(DataType.Date)]
        [Display(Name = "Arribo")]
        public DateTime Arribo
        {
            get
            {
                return arribo;
            }

            set
            {
                arribo = value;
            }
        }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Partida")]
        public DateTime Partida
        {
            get
            {
                return partida;
            }

            set
            {
                partida = value;
            }
        }

        public Tramo()
        {
                
        }

        public Tramo( Destino destino, DateTime arribo, DateTime partida)
        {
            this.destino = destino;
            this.arribo = arribo;
            this.partida = partida;
        }
        
    }
}