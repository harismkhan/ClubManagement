using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Pitch : Base
    {
        public string Address { get; set; }
        public Club Club { get; set; }
    }
}
