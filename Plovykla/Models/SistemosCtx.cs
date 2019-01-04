using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Plovykla.Models
{
    public class SistemosCtx : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        public SistemosCtx(DbContextOptions<SistemosCtx> options)
            : base(options)
        {

        }



        public DbSet<Kategorija> Kategorijas { get; set; }

        public DbSet<Busenos> Busenos { get; set; }

        public DbSet<Medziagos> Medziagos { get; set; }

        public DbSet<Vartotojai> Vartotojais { get; set; }

        public DbSet<Paslauga> Paslaugas { get; set; }

        public DbSet<Uzsakymas> Uzsakymas { get; set; }

        public DbSet<Baudos> Baudos { get; set; }

        public DbSet<Trukumai> Trukumais { get; set; }

        public DbSet<Atsiliepimai> Atsiliepimais { get; set; }
    }
}
