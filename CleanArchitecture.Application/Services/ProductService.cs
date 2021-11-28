using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.Product.DTO;
using CleanArchitecture.Application.DTOs.Product.Validation;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : BaseServices, IProductService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetById(Guid id) => _mapper.Map<ProductDTO>(await _productRepository.GetAsyncId(id));
        public async Task<ProductDetailDTO> GetProductCategory(Guid id)
        {
            var productDetail = _mapper.Map<ProductDetailDTO>(await _productRepository.GetProductAndCategoryAsync(id));
            if (String.IsNullOrEmpty(productDetail.Image))
            {
                productDetail.Image = "produto-nao-encontrado.png";
            }
            return productDetail;
        }
        public async Task<ProductEditDTO> GetProductCategoryForEdit(Guid id)
        {
            var productDetail = _mapper.Map<ProductEditDTO>(await _productRepository.GetProductAndCategoryAsync(id));
            productDetail.Categorys = _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryRepository.GetAsync());
            if (String.IsNullOrEmpty(productDetail.Image))
            {
                productDetail.Image = "produto-nao-encontrado.png";
            }
            return productDetail;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts() => _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductAndCategoryAsync());
        public async Task<ProductDTO> GetProductsCategory(ProductDTO productDTO)
        {
            productDTO.Categorys = _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryRepository.GetAsync());
            return productDTO;
        }
        public async Task Add(ProductDTO productDTO)
        {
            if (!ExecultarValidacao(new ProductValidation(), productDTO)) return;
            await _productRepository.CreateAsync(_mapper.Map<Product>(productDTO));

        }
        public async Task<bool> UploadArquivo(IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length <= 0)
            {
                Notificar("imagem não encontrada !");
                return false;
            }
            if (!await _productRepository.GetByNameExistImageAsync(arquivo.FileName))
            {
                Notificar("Já existe um arquivo com este nome!");
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens",arquivo.FileName);

            if (File.Exists(path))
            {
                Notificar("Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        public async Task Update(ProductEditDTO productDTO)
        {
            var productEditDTO = _mapper.Map<Product>(productDTO);
            productEditDTO.AlterarCategoria(productEditDTO.CategoryId);
            productEditDTO.AlterarPreco(productDTO.Price);
            productEditDTO.AlterarNome(productDTO.Name);
            await _productRepository.UpdateAsync(_mapper.Map<Product>(productEditDTO));
        }
        public async Task Remove(Guid id)
        {
            if (await _productRepository.GetByIdExistAsync(id))
            {
                Notificar("A produto não foi encontrada");
                return;
            }

            await _productRepository.RemoveAsync(id);
        }


    }
}
