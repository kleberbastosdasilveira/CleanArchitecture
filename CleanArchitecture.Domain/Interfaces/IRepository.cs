using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetAsyncId(Guid id);
        Task<List<TEntity>> GetAsync();
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(object id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
