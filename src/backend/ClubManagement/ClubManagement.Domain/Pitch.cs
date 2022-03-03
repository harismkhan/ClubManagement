using ClubManagement.Backbone;

namespace ClubManagement.Domain
{
    public class Pitch : Entity
    {
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string Zip { get; set; }
        public virtual Club Club { get; set; }
        public Guid ClubId { get; set; }
    }
}
