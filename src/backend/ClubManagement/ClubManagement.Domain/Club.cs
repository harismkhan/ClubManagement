using ClubManagement.Backbone;

namespace ClubManagement.Domain
{
    public class Club : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();
        public virtual ICollection<Pitch> Pitches { get; set; } = new List<Pitch>();
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}