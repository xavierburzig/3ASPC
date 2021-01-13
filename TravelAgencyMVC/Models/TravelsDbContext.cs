using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgencyMVC.Models
{
    public class TravelsDbContext : DbContext
    {
        public DbSet<Travel> Travels { get; set; }

        public TravelsDbContext(DbContextOptions<TravelsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //this.EnsureSeedData();
        }
    }
}
