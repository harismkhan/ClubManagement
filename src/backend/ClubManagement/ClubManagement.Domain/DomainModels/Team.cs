using ClubManagement.Backbone;
﻿using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.DomainModels
{
    public class Team : Entity
    {
        public TeamLevel Level { get; set; }
        public virtual Club Club { get; set; }
        public Guid ClubId { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; } = new List<Coach>();
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
