using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Member : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string Zip { get; set; }
        public virtual Club Club {get; set; } 
        public virtual Team Team { get; set; }

    }
}
