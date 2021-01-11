using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Models
{
    public class UsersService { 
        //    private readonly TravelsDbContext _context;

        //    public UsersService()
        //    {
        //        var options = new DbContextOptionsBuilder<TravelsDbContext>()
        //            .UseInMemoryDatabase("TravelAgency")
        //            .Options;

        //        _context = new TravelsDbContext(options);
        //    }

        //    public UsersService(TravelsDbContext context)
        //    {
        //        _context = context;
        //    }

        //    public async Task DeleteAsync(long id)
        //    {
        //        _context.Users.Remove(new UsingIdentityUser { Id = id });
        //        await _context.SaveChangesAsync();
        //    }

        //    public UsingIdentityUser Find(long id)
        //    {
        //        return _context.Users.FirstOrDefault(x => x.Id == id);
        //    }

        //    public Task<UsingIdentityUser> FindAsync(long id)
        //    {
        //        return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        //    }

        //    public IQueryable<UsingIdentityUser> GetAll(int? count = null, int? page = null)
        //    {
        //        var actualCount = count.GetValueOrDefault(10);

        //        return _context.Users
        //                .Skip(actualCount * page.GetValueOrDefault(0))
        //                .Take(actualCount);
        //    }

        //    public Task<UsingIdentityUser[]> GetAllAsync(int? count = null, int? page = null)
        //    {
        //        return GetAll(count, page).ToArrayAsync();
        //    }

        //    public async Task SaveAsync(UsingIdentityUser user)
        //    {
        //        var isNew = user.Id == default(long);

        //        _context.Entry(user).State = isNew ? EntityState.Added : EntityState.Modified;

        //        await _context.SaveChangesAsync();
        //    }
    }
}