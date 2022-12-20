using ClientAppOracleTask.Abstractions;
using ClientAppOracleTask.Entities;
using ClientAppOracleTask.Specefications;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClientAppOracleTask.Data
{
    public class EfRepository<TEntity> :
        IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<TEntity> entities;

        public EfRepository (ApplicationContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            this.entities.AddAsync(entity);
            return SaveChangesAsync();
        }

        public Task AddAsync(IEnumerable<TEntity> entity)
        {
            this.entities.AddRangeAsync(entities);
            return SaveChangesAsync();
        }

        public Task<TEntity> FindAsync(int id)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<TEntity> FindAsync(Specification<TEntity> specification)
        {
            return this.entities.FirstOrDefaultAsync(specification.Expression);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await this.entities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification)
        {
            return await this.entities.Where(specification.Expression).ToListAsync();
        }

        public Task RemoveAsync(TEntity entity)
        {
            this.entities.Remove(entity);
            return SaveChangesAsync();
        }

        public Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            this.entities.RemoveRange(entities);
            return SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            this.entities.Update(entity);
            return SaveChangesAsync();
        }

        public Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            this.entities.UpdateRange(entities);
            return SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }
    }
}
