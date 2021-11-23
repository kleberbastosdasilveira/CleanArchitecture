using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Category> GetByIdAsync(Guid? Id) => await _categoryDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);

        public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _categoryDbContext.Categories.AsNoTracking().ToListAsync();

        public async Task<bool> GetByIdExistAsync(Guid Id)
        {
            var categoriaEncontrado = await _categoryDbContext.Categories.FirstOrDefaultAsync(p => p.Id.Equals(Id));
            return categoriaEncontrado is null;
        }

        public async Task<bool> GetByNameExistAsync(string name)
        {
            var categoriaEncontrado = await _categoryDbContext.Categories.FirstOrDefaultAsync(p => p.Name.ToLower().Equals(name.ToLower()));
            return categoriaEncontrado is null;
        }
    }
}
