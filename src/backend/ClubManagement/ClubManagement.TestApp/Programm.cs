using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagement.Domain;

namespace ClubManagement.TestApp
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            List<Club> clubs = new List<Club>();
            List<Coach> coaches = new List<Coach>();
            List<Player> players = new List<Player>();
            List<Team> teams = new List<Team>();
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Press 'a' for a player registration");
                Console.WriteLine($"Press 'b' for a coach registration");
                Console.WriteLine($"Press 'c' for a club registration");
                Console.WriteLine($"Press 'd' for a team registration");
                string response = Console.ReadLine();

                if (response == "a")
                {
                    Console.WriteLine("Register a new Player");
                    Console.WriteLine("First-Name of Player:");
                    string pFirstName = Console.ReadLine();
                    Console.WriteLine("Last-Name of Player:");
                    string pLastName = Console.ReadLine();
                    Console.WriteLine("Address of Player:");
                    string pAddress = Console.ReadLine();
                    Console.WriteLine("Club of Player:");
                    string pClub = Console.ReadLine();
                    Player player = new Player();

                    player.Id = Guid.NewGuid();
                    player.FirstName = pFirstName;
                    player.LastName = pLastName;
                    player.Address = pAddress;
                    player.Club = clubs.First(c => c.Name == pClub);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Overwiev of the new Player: \n" +
                        $"Id: . . . . . . . {player.Id} \n" +
                        $"First-Name: . . . . . . . {player.FirstName} \n" +
                        $"Last-Name:  . . . . . . . {player.LastName} \n" +
                        $"Address:  . . . . . . . . {player.Address}\n" +
                        $"Club:  . . . . . . . . {player.Club.Name}");

                    players.Add(player);
                }
                else if (response == "b")
                {
                    var coach = new Coach()
                    {
                        Id = Guid.NewGuid()
                    };
                    Console.WriteLine("First Name of Coach:");
                    coach.FirstName = Console.ReadLine();
                    Console.WriteLine("Last Name of Coach:");
                    coach.LastName = Console.ReadLine();
                    Console.WriteLine("Club of Coach:");
                    var cclub = Console.ReadLine();
                    coach.Club = clubs.First(c => c.Name == cclub);
                    Console.WriteLine("Address of Coach");
                    coach.Address = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Overwiev of the new Player: \n" +
                        $"Id: . . . . . . . {coach.Id} \n" +
                        $"First-Name: . . . . . . . {coach.FirstName} \n" +
                        $"Last-Name: . . . . . . . {coach.LastName} \n" +
                        $"Club: . . . . . . . {coach.Club.Name} \n" +
                        $"Address: . . . . . . . {coach.Address} \n");

                    coaches.Add(coach);

                }
                else if (response == "c")
                {
                    var club = new Club()
                    {
                        Id = Guid.NewGuid()
                    };
                    Console.WriteLine("Name of Club:");
                    club.Name = Console.ReadLine();
                    Console.WriteLine("Address of Club:");
                    club.Address = Console.ReadLine();

                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine(
                        $"Overwiev of the new Player: \n" +
                        $"Id: . . . . . . . {club.Id} \n" +
                        $"Club-Name: . . . . . . . {club.Name} \n" +
                        $"Address: . . . . . . . {club.Address} \n");

                    clubs.Add(club);
                }
                else if (response == "d")
                {
                    var team = new Team()
                    {
                        Id = Guid.NewGuid(),
                        Coaches = new List<Coach>(),
                    };
                    Console.WriteLine("Select Teamlevel: (1 = Senior) (2 = Active) (3 = JuniorA) (4 = JuniorB) ");

                    var selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            team.Level = TeamLevel.Senior;
                            break;
                        case "2":
                            team.Level = TeamLevel.Active;
                            break;
                        case "3":
                            team.Level = TeamLevel.JuniorA;
                            break;
                        case "4":
                            team.Level = TeamLevel.JuniorB;
                            break;
                    }
                    bool x = true;
                    while (x)
                    {
                        Console.WriteLine("Do you want to Add a Coach to the Team? (1 = yes) (2 = no)");
                        var y = Console.ReadLine();
                        if (y == "1")
                        {
                            Console.WriteLine("First and Last Name of Coach");
                            var coachName = Console.ReadLine();
                            var coachFirstName = coachName.Split(" ")[0];
                            var coachLastName = coachName.Split(" ")[1];
                            try
                            {
                                var coach = coaches.First(c => c.FirstName == coachFirstName && c.LastName == coachLastName);
                                team.Coaches.Add(coach);
                            }
                            catch
                            {
                                Console.WriteLine("Cach not found");
                            }
                        }
                        else
                        {
                            x = false;
                        }
                    }

                    string coachString = "";
                    foreach(var coach in team.Coaches)
                    {
                        coachString = coachString + coach.FirstName + coach.LastName + ", ";
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Overwiev of the new Player: \n" +
                        $"Id: . . . . . . . {team.Id} \n" +
                        $"Level: . . . . . . . {team.Level.ToString()} \n" +
                        $"Coaches: . . . . . . . {coachString} \n");
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
