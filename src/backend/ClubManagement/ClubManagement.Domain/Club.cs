using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Club : BaseEntity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}