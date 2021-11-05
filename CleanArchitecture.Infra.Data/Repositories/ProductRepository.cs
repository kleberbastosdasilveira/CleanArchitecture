using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productDbContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productDbContext = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _productDbContext.Add(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(Guid? Id)
        {
            return await _productDbContext.Products.FindAsync(Id);
        }

        public async Task<bool> GetByIdExistAsync(Guid Id)
        {
            var produtoEncontrado = await _productDbContext.Products.FirstOrDefaultAsync(p=>p.Id.Equals(Id));
            return produtoEncontrado is null;
        }

        public async Task<bool> GetByNameExistAsync(string name)
        {
            var produtoEncontrado = _productDbContext.Products.FirstOrDefaultAsync(p => p.Name.ToLower().Equals(name.ToLower()));
            return produtoEncontrado is null;
        }

        public async Task<Product> GetProductCategoryAsync(Guid? Id)
        {
            return await _productDbContext.Products.Include(c => c.Category)
                         .SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productDbContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productDbContext.Remove(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productDbContext.Update(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }
    }
}
