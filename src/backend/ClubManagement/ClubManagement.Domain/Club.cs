using ClubManagement.Backbone;

namespace ClubManagement.Domain
{
    public class Club : Entity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Pitch> Pitches { get; set; }
    }
}