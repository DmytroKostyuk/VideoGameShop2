using BLL.DTO;
using DAL.Paging;
using DAL.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces.IEFServices
{
    public interface IEFGameService
    {
        Task<string> AddGame(GameDTO game);

        Task UpdateGame(GameDTO game);

        Task DeleteGame(int Id);

        Task<GameDTO> GetGameById(int Id);

        Task<IEnumerable<GameDTO>> GetAllGames();

        Task<GameDTO> GetCheapestGame();

        Task<PagedList<GameDTO>> GetGamesPartly(GameParameters gameParameters);
    }
}
