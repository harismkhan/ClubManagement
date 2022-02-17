using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Club : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string Zip { get; set; }
        public ICollection<Team> Teams { get; set; }

        public Club()
        {
            Teams = new List<Team>();
        }

        public int GetPlayersAmount()
        {
            return Teams.SelectMany(t => t.Players).Count();
        }
        public int GetCoachesAmount()
        {
            return Teams.SelectMany(t => t.Coaches).Count();
        }
    }
}