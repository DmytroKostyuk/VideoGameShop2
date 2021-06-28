using BLL.DTO;
using DAL.Paging;
using DAL.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces.IEFServices
{
    public interface IEFDeveloperService
    {
        Task<string> AddDeveloper(DeveloperDTO developer);

        Task UpdateDeveloper(DeveloperDTO developer);

        Task DeleteDeveloper(int Id);

        Task<DeveloperDTO> GetDeveloperById(int Id);

        Task<IEnumerable<DeveloperDTO>> GetAllDevelopers();

        Task<DeveloperDTO> GetDeveloperByName(string name);

        Task<PagedList<DeveloperDTO>> GetDevelopersPartly(DeveloperParameters developerParameters);
    }
}
