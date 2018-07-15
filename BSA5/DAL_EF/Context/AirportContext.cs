using DAL_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace DAL_EF.Context
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {


        }

        public DbSet<Aircrafts> AircraftsList { get; set; }
        public DbSet<AircraftsModels> AircraftsModelsList { get; set; }
        public DbSet<Crews> CrewsList { get; set; }
        public DbSet<Pilots> PilotsList { get; set; }
        public DbSet<Stewardesses> StewardessesList { get; set; }
        public DbSet<Departures> DeparturesList { get; set; }
        public DbSet<Flights> FlightsList { get; set; }
        public DbSet<Tickets> TicketsList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       

        }


    }
}
