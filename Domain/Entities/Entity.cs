using System;

namespace Domain.Entities
{
    // To be used as base abstract class for domain entities
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public virtual TId Id { get; protected set; }

        protected Entity(TId id)
        {
            this.Id = id;
        }

        // EF requires an empty constructor
        protected Entity()
        {
        }

        // For simple entities, this may suffice
        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }
    }
}
