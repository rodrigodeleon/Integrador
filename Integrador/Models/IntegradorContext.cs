using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Integrador.Models
{

    public class IntegradorContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IntegradorContext() : base("name=IntegradorContext")
        {
        }

        public System.Data.Entity.DbSet<Integrador.Models.Destino> Destinos { get; set; }

        public System.Data.Entity.DbSet<Integrador.Models.Transporte> Transportes { get; set; }

        public System.Data.Entity.DbSet<Integrador.Models.Tramo> Tramoes { get; set; }

        public System.Data.Entity.DbSet<Integrador.Models.Excursion> Excursions { get; set; }
    }
}
