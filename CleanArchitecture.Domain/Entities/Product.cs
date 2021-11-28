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
        public Product() { }
        public Product(Guid categoriaId, string name, string description, decimal price, int stock, string image)
        {
            CategoryId = categoriaId;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ValidarImagem(image);
            ValidateDomain();
        }
        #region Chain Methods
        public void Update(Guid categoriaId, string name, string description, decimal price, int stock, string image)
        {
            CategoryId = categoriaId;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            ValidateDomain();
            ValidarImagem(image);

        }

        public Product AlterarNome(string nome)
        {
            Name = nome;
            return this;
        }
        public Product AlterarDescricao(string descricao)
        {
            Description = descricao;
            return this;
        }
        public Product AlterarCategoria(Guid categoriaId)
        {
            CategoryId = categoriaId;
            return this;
        }
        public Product AlterarPreco(decimal novoPreco)
        {
            Price = novoPreco;
            return this;
        }
        public Product AlterarQuantidade(int quantidade)
        {
            Stock = quantidade;
            return this;
        }
        #endregion
        private void ValidarImagem(string image)
        {
            if (image?.Length > 250)
            {
                AddNotification(nameof(Image), Message.ImagemInvalida);
                return;
            }
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
                .AreNotEquals(CategoryId, Guid.Empty, Message.CategoriaInvalida));
        }
    }
}
