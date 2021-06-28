using DAL.DbContexts;
using DAL.Entities;
using DAL.Interfaces.EFInterfaces.IEFRepositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Repositories.EFRepositories
{
    public class EFGenreRepository : GenericRepository<Genre, int>, IEFGenreRepository
    {
        

        public EFGenreRepository(MyDbContext dbcontext)
            : base(dbcontext)
        { }

        public async Task<Genre> GetGenreByName(string name)
        {
            var x = await _dbcontext.Set<Genre>().ToListAsync();

            return x.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}