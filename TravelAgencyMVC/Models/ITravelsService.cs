using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public interface ITravelsService
    {
        Task DeleteAsync(long id);
        Travel Find(long id);
        Task<Travel> FindAsync(long id);
        IQueryable<Travel> GetAll(int? count = null, int? page = null);
        Task<Travel[]> GetAllAsync(int? count = null, int? page = null);
        Task SaveAsync(Travel travel);
    }
}
