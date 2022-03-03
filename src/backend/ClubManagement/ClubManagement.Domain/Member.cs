using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public abstract class Member : BaseEntity
    {
        public  string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public virtual Club Club {get; set; }
        public Guid ClubId { get; set; }
        public virtual Team Team { get; set; }
        public Guid TeamId { get; set; }


    }
}
