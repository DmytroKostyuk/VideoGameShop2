using DAL.DbContexts;
using DAL.Entities;
using DAL.Interfaces.EFInterfaces.IEFRepositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Repositories.EFRepositories
{
    public class EFPublisherRepository : GenericRepository<Publisher, int>, IEFPublisherRepository
    {

        public EFPublisherRepository(MyDbContext dbcontext)
            : base(dbcontext)
        { }

        public async Task<Publisher> GetPublisherByName(string name)
        {
            var x = await _dbcontext.Set<Publisher>().ToListAsync();

            return x.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}