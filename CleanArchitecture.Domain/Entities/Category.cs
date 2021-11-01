using CleanArchitecture.Domain.ResourceValidation;
using Flunt.Notifications;
using Flunt.Validations;
using System;


namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        protected Category() { }
        public Category(string name)
        {
            Name = name;
            ValidateDomain();
        }
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
            ValidateDomain();
        }

        public void Update(string name) => Name = name;

        public void ValidateDomain()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, nameof(Name), Message.NomeInvalido)
                .IsGreaterThan(Name.Length, 3, nameof(Name), Message.NomePequeno)
                .AreNotEquals(Name.Length, 3, nameof(Name), Message.NomePequeno));
        }
    }
}
