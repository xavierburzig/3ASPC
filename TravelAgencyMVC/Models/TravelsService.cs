using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Models
{
    public class TravelsService : ITravelsService
    {
        private readonly TravelsDbContext _context;

        public TravelsService()
        {
            var options = new DbContextOptionsBuilder<TravelsDbContext>()
                .UseInMemoryDatabase("TravelAgency")
                .Options;

            _context = new TravelsDbContext(options);
        }

        public TravelsService(TravelsDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(long id)
        {
            _context.Travels.Remove(new Travel { Id = id });
            await _context.SaveChangesAsync();
        }

        public Travel Find(long id)
        {
            return _context.Travels.FirstOrDefault(x => x.Id == id);
        }

        public Task<Travel> FindAsync(long id)
        {
            return _context.Travels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Travel> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _context.Travels
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public Task<Travel[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(Travel travel)
        {
            var isNew = travel.Id == default(long);

            _context.Entry(travel).State = isNew ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
