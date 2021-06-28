using DAL.Entities;
using DAL.Paging;
using DAL.Parameters;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces.EFInterfaces.IEFRepositories
{
    public interface IEFGameRepository : IGenericRepository<Game,int>
    {
        Task<Game> GetCheapestGame();
        Task<PagedList<Game>> GetGamesPartly(GameParameters gameParameters);
    }
}
