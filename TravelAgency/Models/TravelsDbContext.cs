using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Models
{
    public class TravelsDbContext : DbContext
    {
        public DbSet<Travel> Travels { get; set; }

        public TravelsDbContext(DbContextOptions<TravelsDbContext> options)
            : base(options)
        {
            this.EnsureSeedData();
        }
    }
}
