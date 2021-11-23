using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.Product.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(Guid id);
        Task<ProductDetailDTO> GetProductCategory(Guid id);
        Task<ProductDTO> GetProductsCategory(ProductDTO productDTO);
        Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(Guid id);
    }
}
