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
    public class ProductUpdateCommandHandler : Notifiable<Notification>, IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var atualizarProduto = await _productRepository.GetByIdAsync(request.Id);
            request.ValidarComando();
            if (atualizarProduto == null && !request.IsValid)
            {
                AddNotifications(request);
                throw new ApplicationException(this.Notifications.ToString());
            }
            else
            {
                atualizarProduto.Update(request.CategoryId, request.Name, request.Description, request.Price, request.Stock, request.Image);
                return await _productRepository.UpdateAsync(atualizarProduto);
            }

        }
    }
}
