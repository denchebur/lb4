using ClientAppOracleTask.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Abstractions
{
    public interface IEntityService<TEntity> where TEntity : Entity
    {
        Task<ICollection<TEntity>> GetInfoAsync();
    }
}
