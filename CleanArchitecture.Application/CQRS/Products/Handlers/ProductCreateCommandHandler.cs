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
    public class ProductCreateCommandHandler : Notifiable<Notification>, IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            request.ValidarComando();

            if (!request.IsValid)
            {
                AddNotifications(request);
                throw new ApplicationException(this.Notifications.ToString());
            }

            var produtoJaExiste = await _productRepository.GetByNameExistAsync(request.Name);

            if (!produtoJaExiste)
            {
                AddNotification("ProdutoId", "O produto já está cadastrado");
                throw new ApplicationException(this.Notifications.ToString());
            }

            var nomvoProduto = new Product(request.CategoryId, request.Name, request.Description, request.Price, request.Stock, request.Image);

            return await _productRepository.CreateAsync(nomvoProduto);
        }
    }
}
