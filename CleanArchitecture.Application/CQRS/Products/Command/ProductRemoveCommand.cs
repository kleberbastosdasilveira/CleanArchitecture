using CleanArchitecture.Domain.Entities;
using MediatR;
using System;

namespace CleanArchitecture.Application.CQRS.Products.Command
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
        public ProductRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
