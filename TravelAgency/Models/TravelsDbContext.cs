using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Models
{
    public class TravelsDbContext : DbContext
    {
        public DbSet<Travel> Travels { get; set; }
        //public DbSet<UsingIdentityUser> Users { get; set; }

        public TravelsDbContext(DbContextOptions<TravelsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            this.EnsureSeedData();
        }
    }
}
