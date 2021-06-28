using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.EFInterfaces.IEFRepositories
{
    public interface IEFGenreRepository : IGenericRepository<Genre,int>
    {
        Task<Genre> GetGenreByName(string name);
    }
}
