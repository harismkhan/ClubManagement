using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Player : Member
    {

        public virtual decimal Height { get; set; }
        public virtual decimal Weight { get; set; }
        public virtual int PlayerNumber { get; set; }
    }
}
