using CleanArchitecture.Domain.Entities;
using MediatR;
using System;

namespace CleanArchitecture.Application.CQRS.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
