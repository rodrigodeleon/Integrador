using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Integrador.Models
{
    public class Persona
    {
        private int id;
        private int ci;
        private String nombre;
        private String direccion;
        private int telefono;
        private String email;
        private DateTime fechaNac;
        private Boolean activo;

        [Key]
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
        [Index(IsUnique = true)]
        [Display(Name = "Cedula de Identidad")]
        public int Ci
        {
            get
            {
                return ci;
            }

            set
            {
                ci = value;
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
        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }
        [Required]
        public int Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail invalido")]
        [Required]
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNac
        {
            get
            {
                return fechaNac;
            }

            set
            {
                fechaNac = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public Persona()
        {

        }

        public Persona( int ci, String nombre, String direccion, int telefono, String email, DateTime fechaNac)
        {
            this.ci = ci;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.fechaNac = fechaNac;
        }
    }
}