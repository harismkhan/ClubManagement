using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Domain
{
    public class Member : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address {get; set; }
        public Club Club {get; set; } 
        public Team Team { get; set; }

        //public Member()
        //{

        //}
        //public Member(
        //    //string firstName, string lastName, DateTime birthDate, string address, Club club, Team team, float Height, float Weight, int PlayerNumber
        //    )
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    BirthDate = birthDate;
        //    Address = address;
        //    Club = club;
        //    team = team;
        //}

        //public Member(string firstName, string lastName, DateTime birthDate, string address, Team team, float Height, float Weight, int PlayerNumber)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    BirthDate = birthDate;
        //    Address = address;
        //    Club = defaultClub;
        //    Team = team;
        //}
    }
}
