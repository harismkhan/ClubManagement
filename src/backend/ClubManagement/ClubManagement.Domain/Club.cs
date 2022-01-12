using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Club : Base
    {
        public string Name { get; set; }
        public String Address { get; set; }
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