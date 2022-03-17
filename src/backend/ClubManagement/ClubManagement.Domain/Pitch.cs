using ClubManagement.Backbone;

namespace ClubManagement.Domain
{
    public class Pitch : Entity
    {
        public virtual string Street { get; set; } = string.Empty;
        public virtual string City { get; set; } = string.Empty;
        public virtual string Zip { get; set; } = string.Empty;
        public virtual Club? Club { get; set; }
        public Guid? ClubId { get; set; }
    }
}
