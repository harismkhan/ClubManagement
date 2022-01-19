using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Team : Base
    {
        public ICollection<Coach> Coaches { get; set; }
        public ICollection<Player> Players { get; set; }

        public TeamLevel Level { get; set; }

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
