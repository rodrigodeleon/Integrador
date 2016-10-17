using System;
using System.Collections.Generic;
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