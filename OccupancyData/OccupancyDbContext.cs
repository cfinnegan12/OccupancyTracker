using Microsoft.EntityFrameworkCore;
using OccupancyData.Models;

namespace OccupancyData
{
    public class OccupancyDbContext : DbContext
    {
        public OccupancyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Space> Spaces { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Building> Buildings { get; set; }
    }
}
