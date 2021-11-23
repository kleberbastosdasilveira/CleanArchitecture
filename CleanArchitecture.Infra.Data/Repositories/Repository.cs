using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ApplicationDbContext _categoryDbContext;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(ApplicationDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
            DbSet = categoryDbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetAsyncId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        public virtual async Task CreateAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task RemoveAsync(object id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await _categoryDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _categoryDbContext?.Dispose();
        }
    }
}
