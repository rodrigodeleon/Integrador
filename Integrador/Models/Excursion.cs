using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Excursion
    {
        private int id;
        private String nombre;
        private String descripcion;
        private Persona creador;
        private int duracion;
        private bool activa;
        private ICollection<Tramo> tramos;
        private ICollection<Transporte> transportes;


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
        [Display(Name = "Creador")]
        public virtual Persona Creador
        {
            get
            {
                return creador;
            }

            set
            {
                creador = value;
            }
        }
        [Required]
        public int Duracion
        {
            get
            {
                return duracion;
            }

            set
            {
                duracion = value;
            }
        }
        [Required]
        public bool Activa
        {
            get
            {
                return activa;
            }

            set
            {
                activa = value;
            }
        }

        public virtual ICollection<Tramo> Tramos
        {
            get
            {
                return tramos;
            }

            set
            {
                tramos = value;
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


        internal void getDuracion()
        {
            foreach (Tramo aux in this.tramos)
            {
                duracion += (aux.Partida - aux.Arribo).Days;
            }
            duracion++;
                                  
        }

        public int getCosto()
        {
            int costototal = 0;
            foreach (Tramo aux in Tramos)
            {
                costototal += aux.calcularCosto();
            }
            foreach (Transporte aux in Transportes)
            {
                costototal += aux.Costo;
            }

            return costototal;
        }

        public Excursion()
        {
         

        }

        public Excursion(String nombre, string descripcion, Persona persona, ICollection<Tramo> tramos)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.creador = persona;
            this.tramos = tramos;
        }
    }
}