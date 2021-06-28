using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.EFInterfaces.IEFRepositories
{
    public interface IEFPublisherRepository : IGenericRepository<Publisher,int>
    {
        Task<Publisher> GetPublisherByName(string name);
    }
}
