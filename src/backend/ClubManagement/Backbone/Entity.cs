using System.ComponentModel.DataAnnotations.Schema;

namespace isolutions.EntityFramework.Code.First.Backbone.Data
{
    public abstract class Entity<TId>
    {
        protected Entity()
        {
        }

        protected Entity(TId id)
        {
            Id = id;
        }

        public virtual TId Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not Entity<TId> other)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Id == null || other.Id == null)
            {
                return false;
            }

            if (Id.Equals(default(TId)) || other.Id.Equals(default(TId)))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId>? a, Entity<TId>? b) => !(a == b);

        public override int GetHashCode() => Id?.GetHashCode() ?? 0;
    }

    public abstract class Entity : Entity<Guid>, IEntity
    {
        protected Entity()
        {
        }

        protected Entity(Guid id) : base(id)
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override Guid Id { get; protected set; } = Guid.NewGuid();
    }
}
