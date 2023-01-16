using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Airport.Models;
using Airport.Data;
namespace Airport.Data
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options)
            : base(options)
        {

        }
        public DbSet<Airport.Models.Flight> Flight { get; set; } = default!;

        public DbSet<Airport.Models.Airline> Airline { get; set; }

        public DbSet<Airport.Models.Category> Category { get; set; }

    }

        
}


