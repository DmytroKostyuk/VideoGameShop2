using DAL.DbContexts;
using DAL.Entities;
using DAL.Interfaces.EFInterfaces.IEFRepositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using DAL.Paging;
using DAL.Parameters;

namespace DAL.Repositories.EFRepositories
{
    public class EFGameRepository : GenericRepository<Game, int>, IEFGameRepository
    {
        private readonly IMapper _mapper;

        public EFGameRepository(MyDbContext dbcontext)
            : base(dbcontext)
        { }

        private void  GetGameByName(ref IQueryable<Game> games, string gameName)
        {
            if (!games.Any() || string.IsNullOrWhiteSpace(gameName))
                return;

            games = games.Where(g => g.Name.ToLower().Contains(gameName.Trim().ToLower()));
        }

        public async Task<Game>  GetCheapestGame()
        {
            var x = await _dbcontext.Set<Game>().ToListAsync();

            double min = x.Min(a => a.Cost);

            return x.Where(x => x.Cost == min).FirstOrDefault();
        }

        public async Task<PagedList<Game>> GetGamesPartly(GameParameters gameParameters)
        {
            var games = FindByCondition(g => g.Cost >= gameParameters.MinCost &&
                                        g.Cost <= gameParameters.MaxCost);

            GetGameByName(ref games, gameParameters.Name);

            return await PagedList<Game>.ToPagedList(games,
                gameParameters.PageNumber,
                gameParameters.PageSize);
        }

    }
}
