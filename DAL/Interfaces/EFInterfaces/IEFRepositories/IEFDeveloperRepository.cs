using DAL.Entities;
using DAL.Paging;
using DAL.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces.EFInterfaces.IEFRepositories
{
    public interface IEFDeveloperRepository : IGenericRepository<Developer, int>
    {
        Task<Developer> GetDeveloperByName(string name);
        Task<PagedList<Developer>> GetDevelopersPartly(DeveloperParameters developerParameters);
    }
}
