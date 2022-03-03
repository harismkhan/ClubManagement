using ClubManagement.Backbone;


namespace ClubManagement.Domain
{
    public class Team : Entity
    {
        public TeamLevel Level { get; set; }
        public virtual Club Club { get; set; }
        public Guid ClubId { get; set; }
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<Coach> Coaches { get; set; }
        public ICollection<Player> Players { get; set; }

        public Team(TeamLevel level)
        {
            Level = level;
            Coaches = new List<Coach>();
            Players = new List<Player>();
        }

        public Team()
        {
        }
    }
}
