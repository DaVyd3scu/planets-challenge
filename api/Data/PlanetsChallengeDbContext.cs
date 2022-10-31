using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class PlanetsChallengeDbContext : DbContext
    {
        public PlanetsChallengeDbContext(DbContextOptions options) : base(options)
        {
        }

        // Entities
        public DbSet<Captain> Captains { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Robot> Robots { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
    }
}
