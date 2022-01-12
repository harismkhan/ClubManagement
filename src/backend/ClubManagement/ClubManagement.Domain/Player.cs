using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Player : Member
    {
        public Player(
            //string firstName, string lastName, DateTime birthDate, string address, Club club, Team team, float Height, float Weight, int Playernumber) : base(firstName, lastName, birthDate, address, club, team, Height, Weight, Playernumber
                )
        {
        }

        public float Height { get; set; }
        public float Weight { get; set; }
        public int PlayerNumber { get; set; }
    }
}
