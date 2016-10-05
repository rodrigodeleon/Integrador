using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Destino
    {
        private int id;
        private string nombre;
        private string pais;
        private string descripcion;
        private Boolean costa;
        private int costoDiario;


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
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        [Required]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
        [Required]
        public string Pais
        {
            get
            {
                return pais;
            }

            set
            {
                pais = value;
            }
        }
        [Required]
        [Display(Name = "Costo Diario")]
        public int CostoDiario
        {
            get
            {
                return costoDiario;
            }

            set
            {
                costoDiario = value;
            }
        }
        [Required]
        [Display(Name = "Tiene Costa?")]
        public bool Costa
        {
            get
            {
                return costa;
            }

            set
            {
                costa = value;
            }
        }

        public Destino()
        {
        }

        public Destino( string nombre, string pais, string descripcion, Boolean costa, int costoDiario)
        {
            
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.costa = costa;
            this.costoDiario = costoDiario;
            this.pais = pais;
        }
            
       

    }
}