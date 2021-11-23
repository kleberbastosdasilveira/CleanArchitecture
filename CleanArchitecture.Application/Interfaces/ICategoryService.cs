using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.Category.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(Guid id); 
        Task<CategoryDeteilDTO> GetByIdDetais(Guid id);
        Task Add(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);
        Task Remove(Guid id);
    }
}
