using CleanArchitecture.Application.CQRS.Products.Command;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Flunt.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.Products.Handlers
{
    public class ProductRemoveCommandHandler : Notifiable<Notification>, IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var produtoExiste = await _productRepository.GetByIdExistAsync(request.Id);
            if (!produtoExiste)
            {
                AddNotification("ProdutoId", "Produto não encontrado");
                throw new ApplicationException(this.Notifications.ToString());
            }
            else
            {
                var result = await _productRepository.GetByIdAsync(request.Id);
                return await _productRepository.RemoveAsync(result);
            }
        }
    }
}
