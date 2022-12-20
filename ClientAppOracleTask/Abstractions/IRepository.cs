using ClientAppOracleTask.Entities;
using ClientAppOracleTask.Specefications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Abstractions
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Specification<TEntity> expression);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> expression);
        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entity);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveAsync(IEnumerable<TEntity> entities);
        Task SaveChangesAsync();
    }
}
