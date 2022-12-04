using Microsoft.EntityFrameworkCore;
using System;
using WebPasajero.Models;

namespace WebPasajero.Data
{
    public class PasajeroContext:DbContext
    {
        public PasajeroContext(DbContextOptions<PasajeroContext> options)
        : base(options)
        {
        }

        public DbSet<Pasajero> Pasajeros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pasajero>().HasData(
               new Pasajero
               {
                   PasajeroId = 1,
                   Nombre = "Tara",
                   Apellido = "Brewer",
                   Ciudad = "Ocala",
                   FechaNacimiento = 1992
               },
               new Pasajero
               {
                   PasajeroId = 2,
                   Nombre = "Andrew",
                   Apellido = "Tippett",
                   Ciudad = "Anaheim",
                   FechaNacimiento = 1991
               });
        }
    }
}

