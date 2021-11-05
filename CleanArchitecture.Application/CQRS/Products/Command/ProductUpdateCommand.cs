using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ResourceValidation;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;

namespace CleanArchitecture.Application.CQRS.Products.Command
{
    public class ProductUpdateCommand : Notifiable<Notification>, IComando, IRequest<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DataCadastro { get; set; }

        public void ValidarComando()
        {
            AddNotifications(new Contract<Notification>()
              .Requires()
                .IsNotEmpty(Name, nameof(Name), Message.NomeInvalido)
                .IsNotEmpty(Description, nameof(Description), Message.DescricaoInvalida)
                .IsGreaterThan(Price, 0, Message.PrecoInvalido)
                .IsGreaterThan(Stock, 0, Message.QuantidadeInvalida)
                .AreNotEquals(CategoryId, Guid.Empty, Message.CategoriaInvalida));
        }
    }
}
