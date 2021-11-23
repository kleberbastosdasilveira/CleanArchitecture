using CleanArchitecture.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> GetByIdExistAsync(Guid Id);
        Task<bool> GetByNameExistAsync(string name);

    }
}
