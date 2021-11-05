using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetById(Guid? id) => _mapper.Map<CategoryDTO>(await _categoryRepository.GetByIdAsync(id));
        public async Task<IEnumerable<CategoryDTO>> GetCategories() => _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryRepository.GetCategoriesAsync());
        public async Task Add(CategoryDTO categoryDTO) => await _categoryRepository.CreateAsync(_mapper.Map<Category>(categoryDTO));
        public async Task Update(CategoryDTO categoryDTO) => await _categoryRepository.UpdateAsync(_mapper.Map<Category>(categoryDTO));
        public async Task Remove(Guid id) => await _categoryRepository.RemoveAsync(_categoryRepository.GetByIdAsync(id).Result);

    }
}
