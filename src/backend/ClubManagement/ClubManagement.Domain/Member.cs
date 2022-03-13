using ClubManagement.Backbone;


namespace ClubManagement.Domain
{
    public abstract class Member : Entity
    {
        public  string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public virtual Club Club {get; set; }
        public Guid ClubId { get; set; }
        public virtual Team Team { get; set; }
        public Guid TeamId { get; set; }

    }
}
