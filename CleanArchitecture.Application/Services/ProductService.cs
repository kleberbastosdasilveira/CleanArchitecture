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
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetById(Guid id) => _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
        public async Task<ProductDTO> GetProductCategory(Guid id) => _mapper.Map<ProductDTO>(await _productRepository.GetProductCategoryAsync(id));
        public async Task<IEnumerable<ProductDTO>> GetProducts() => _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsAsync());
        public async Task Add(ProductDTO productDTO) => await _productRepository.CreateAsync(_mapper.Map<Product>(productDTO));
        public async Task Update(ProductDTO productDTO) => await _productRepository.UpdateAsync(_mapper.Map<Product>(productDTO));
        public async Task Remove(Guid id) => await _productRepository.RemoveAsync(_productRepository.GetByIdAsync(id).Result);

    }
}
