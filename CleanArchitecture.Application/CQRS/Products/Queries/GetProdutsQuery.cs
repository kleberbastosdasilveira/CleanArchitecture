using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.CQRS.Products.Queries
{
    public class GetProdutsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
