using DAL.DbContexts;
using DAL.Entities;
using DAL.Interfaces.EFInterfaces.IEFRepositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using DAL.Parameters;
using DAL.Paging;

namespace DAL.Repositories.EFRepositories
{
    public class EFDeveloperRepository : GenericRepository<Developer, int>, IEFDeveloperRepository
    {

        public EFDeveloperRepository(MyDbContext dbcontext)
            :base(dbcontext)
        {
        }

        //Надо оптимизировать
        public async Task <Developer> GetDeveloperByName(string name)
        {
            var x = await _dbcontext.Set<Developer>().ToListAsync();

            return x.Where(x => x.Name == name).FirstOrDefault();
        }

        public async Task<PagedList<Developer>> GetDevelopersPartly(DeveloperParameters developerParameters)
        {
            return await PagedList<Developer>.ToPagedList(FindAll(),
                developerParameters.PageNumber,
                developerParameters.PageSize);
        }
    }
}
