using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Player : Member
    {

        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int PlayerNumber { get; set; }
    }
}
