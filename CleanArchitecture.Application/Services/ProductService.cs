using AutoMapper;
using CleanArchitecture.Application.CQRS.Products.Command;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService : Notifiable<Notification>, IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IProductRepository productRepository, IMapper mapper, IMediator mediator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ProductDTO> GetById(Guid id) => _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
        public async Task<ProductDTO> GetProductCategory(Guid id) => _mapper.Map<ProductDTO>(await _productRepository.GetProductCategoryAsync(id));
        public async Task<IEnumerable<ProductDTO>> GetProducts() => _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsAsync());

        public async Task Add(ProductDTO productDTO)
        {
            var produtoCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(produtoCreateCommand);
        }
        public async Task Update(ProductDTO productDTO)
        {
            var produtoUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(produtoUpdateCommand);
        }
        public async Task Remove(Guid id)
        {
            var produtoRemoveCommand = new ProductRemoveCommand(id).Equals(false || true);
            if (!produtoRemoveCommand)
            {
                AddNotification("Produto", "Produto não Encontrato");
                throw new ApplicationException(this.Notifications.ToString());
            }
            await _mediator.Send(produtoRemoveCommand);
        }

    }
}
