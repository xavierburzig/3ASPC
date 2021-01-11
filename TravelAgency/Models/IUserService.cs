using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public interface IUserService
    {
        Task DeleteAsync(long id);
        UsingIdentityUser Find(long id);
        Task<UsingIdentityUser> FindAsync(long id);
        IQueryable<UsingIdentityUser> GetAll(int? count = null, int? page = null);
        Task<UsingIdentityUser[]> GetAllAsync(int? count = null, int? page = null);
        Task SaveAsync(UsingIdentityUser user);
    }
}
