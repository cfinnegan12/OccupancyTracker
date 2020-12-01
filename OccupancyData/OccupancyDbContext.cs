using Microsoft.EntityFrameworkCore;
using OccupancyData.Models;

namespace OccupancyData
{
    public class OccupancyDbContext : DbContext
    {
        public OccupancyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Computer> Computers { get; set; }

    }
}
