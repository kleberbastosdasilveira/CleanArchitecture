﻿using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.ResourceValidation;
using Flunt.Notifications;
using Flunt.Validations;


namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }
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

        public void ValidateDomain()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, nameof(Name), Message.NomeInvalido)
                .IsNotMaxValue(Name.Length,nameof(Name),Message.NomePequeno)
                .IsNotEmpty(Id,nameof(Id),Message.IdInvalido));
            
        }
    }
}
