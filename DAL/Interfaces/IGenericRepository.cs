using DAL.Interfaces.EntityInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class,IEntity<TId>
    {
         Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(TId Id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TId id);
    }
}
