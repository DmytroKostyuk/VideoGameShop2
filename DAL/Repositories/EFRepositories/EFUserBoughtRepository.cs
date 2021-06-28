using DAL.DbContexts;
using DAL.Entities;
using DAL.Interfaces.EFInterfaces.IEFRepositories;

namespace DAL.Repositories.EFRepositories
{
    public class EFUserBoughtRepository : GenericRepository<UserBought, int>, IEFUserBoughtRepository
    {
        private readonly MyDbContext dbcontext;

        public EFUserBoughtRepository(MyDbContext dbcontext)
            : base(dbcontext)
        { }
    }
}