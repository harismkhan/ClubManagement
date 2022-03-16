using ClubManagement.Backbone;

namespace ClubManagement.Domain
{
    public abstract class Member : Entity
    {
        public  string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public virtual Club? Club {get; set; }
        public Guid? ClubId { get; set; }
        public virtual Team? Team { get; set; }
        public Guid? TeamId { get; set; }

    }
}