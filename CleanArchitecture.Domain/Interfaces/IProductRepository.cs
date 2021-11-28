using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> GetByIdExistAsync(Guid Id);
        Task<bool> GetByNameExistAsync(string name); 
        Task<bool> GetByNameExistImageAsync(string name);
        Task<Product> GetProductAndCategoryAsync(Guid? Id); 
        Task<bool> GetProductExistCategoryAsync(Guid Id);  
        Task<IEnumerable<Product>> GetProductAndCategoryAsync();
    }
}
