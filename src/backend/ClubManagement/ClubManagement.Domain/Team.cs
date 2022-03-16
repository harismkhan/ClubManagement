﻿using ClubManagement.Backbone;
﻿using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain
{
    public class Team : Entity
    {
        public TeamLevel Level { get; set; }
        public virtual Club Club { get; set; }
        public Guid ClubId { get; set; }
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
        public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
