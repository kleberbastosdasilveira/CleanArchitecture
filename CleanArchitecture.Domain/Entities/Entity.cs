using Flunt.Notifications;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; protected set; }
        public DateTime DataCadastro { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;
            if (!ReferenceEquals(this, compareTo))
            {
                if (ReferenceEquals(null, compareTo)) return false;

                return Id.Equals(compareTo);
            }
            return true;
        }
    }
}
