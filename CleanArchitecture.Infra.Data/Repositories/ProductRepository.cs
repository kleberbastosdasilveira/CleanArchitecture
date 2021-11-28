using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }


        public async Task<bool> GetByIdExistAsync(Guid Id)
        {
            var produtoEncontrado = await _categoryDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id.Equals(Id));
            return produtoEncontrado is null;
        }

        public async Task<bool> GetByNameExistAsync(string name)
        {
            var produtoEncontrado = await _categoryDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Name.ToLower().Equals(name.ToLower()));
            return produtoEncontrado is null;
        }
        public async Task<bool> GetByNameExistImageAsync(string name)
        {
            var produtoEncontrado = await _categoryDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Image.ToLower().Contains(name.ToLower()));
            return produtoEncontrado is null;
        }

        public async Task<Product> GetProductAndCategoryAsync(Guid? Id)
        {
            return await _categoryDbContext.Products.AsNoTracking().Include(c => c.Category)
                         .SingleOrDefaultAsync(p => p.Id == Id);
        }
        public async Task<IEnumerable<Product>> GetProductAndCategoryAsync()
        {
            return await _categoryDbContext.Products.AsNoTracking().Include(c => c.Category)
                         .OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<bool> GetProductExistCategoryAsync(Guid Id)
        {
            var categoriaExiste = await _categoryDbContext.Products.AsNoTracking().Include(c => c.Category).Where(c => c.Category.Id.Equals(Id)).AnyAsync();
            return categoriaExiste;
        }
    }
}
