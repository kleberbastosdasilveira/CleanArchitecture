using CleanArchitecture.Domain.ResourceValidation;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(Guid id, Guid categoriaId, string name, string description, decimal price, int stock, string image)
        {
            Id = id;
            CategoryId = categoriaId;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

            ValidateDomain();
        }

        public void Update(Guid categoriaId, string name, string description, decimal price, int stock, string image)
        {
            CategoryId = categoriaId;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public void ValidateDomain()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Name, nameof(Name), Message.NomeInvalido)
                .IsNotEmpty(Description, nameof(Description), Message.DescricaoInvalida)
                .IsGreaterThan(Price, 0, Message.PrecoInvalido)
                .IsGreaterThan(Stock, 0, Message.QuantidadeInvalida)
                .IsLowerThan(Image.Length, 250, nameof(Image), Message.ImagemInvalida)
                .AreNotEquals(CategoryId, Guid.Empty, Message.CategoriaInvalida));
        }
    }
}
