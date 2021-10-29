using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryDbContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryDbContext = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _categoryDbContext.Add(category);
            await _categoryDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(Guid? Id)
        {
            return await _categoryDbContext.Categories.FindAsync(Id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryDbContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryDbContext.Remove(category);
            await _categoryDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryDbContext.Update(category);
            await _categoryDbContext.SaveChangesAsync();
            return category;
        }
    }
}
