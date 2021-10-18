using Flunt.Notifications;
using System;

namespace CleanArchitecture.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
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
