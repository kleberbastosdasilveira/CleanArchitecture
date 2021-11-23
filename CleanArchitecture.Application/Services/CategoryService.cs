using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.Category.DTO;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Validations;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService : BaseServices, ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IProductRepository productRepository, INotificador notificador) : base(notificador)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetById(Guid id) => _mapper.Map<CategoryDTO>(await _categoryRepository.GetAsyncId(id));
        public async Task<CategoryDeteilDTO> GetByIdDetais(Guid id) => _mapper.Map<CategoryDeteilDTO>(await _categoryRepository.GetAsyncId(id));
        public async Task<IEnumerable<CategoryDTO>> GetCategories() => _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryRepository.GetAsync());
        public async Task Add(CategoryDTO categoryDTO)
        {
            if (!ExecultarValidacao(new CategoryValidation(), categoryDTO)) return;

            var existeCategoria = await _categoryRepository.GetByNameExistAsync(categoryDTO.Name);

            if (!existeCategoria)
            {
                Notificar("Já existe Categoria com esse nome");
                return;
            }
            await _categoryRepository.CreateAsync(_mapper.Map<Category>(categoryDTO));
        }

        public async Task Update(CategoryDTO categoryDTO) => await _categoryRepository.UpdateAsync(_mapper.Map<Category>(categoryDTO));
        public async Task Remove(Guid id)
        {
            if (await _categoryRepository.GetByIdExistAsync(id))
            {
                Notificar("A categoria não foi encontrada");
                return;
            }
            if (await _productRepository.GetProductExistCategoryAsync(id))
            {
                Notificar("A categoria possui prodruto cadastrado ");
                return;
            }
            await _categoryRepository.RemoveAsync(id);
        }

    }
}
