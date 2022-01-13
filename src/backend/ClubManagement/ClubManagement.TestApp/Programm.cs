﻿using System;
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
            var clubs = new List<Club>();
            var coaches = new List<Coach>();
            var players = new List<Player>();
            var teams = new List<Team>();
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Press 'a' for a player registration");
                Console.WriteLine($"Press 'b' for a coach registration");
                Console.WriteLine($"Press 'c' for a club registration");
                Console.WriteLine($"Press 'd' for a team registration");
                var response = Console.ReadLine();
                switch (response)
                {
                    case "a":
                        RegisterPlayer(clubs, players);
                        break;
                    case "b":
                        RegisterCoach(clubs, coaches);
                        break;
                    case "c":
                        RegisterClub(clubs);
                        break;
                    case "d":
                        RegisterTeam(teams, coaches);
                        break;
                    default:
                        Console.WriteLine("command not found");
                        break;
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        private static void RegisterTeam(List<Team> teams, List<Coach> coaches)
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

            while (true)
            {
                Console.WriteLine("Do you want to Add a Coach to the Team? (1 = yes) (2 = no)");
                var y = Console.ReadLine();
                if (y == "1")
                {
                    AddCoachToTeam(coaches, team);
                }
                else
                {
                    break;
                }
            }

            string coachString = "";
            foreach (var coach in team.Coaches)
            {
                coachString = coachString + coach.FirstName + coach.LastName + ", ";
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                $"Overview of the new Team: \n" +
                $"Id: . . . . . . . {team.Id} \n" +
                $"Level: . . . . . . . {team.Level.ToString()} \n" +
                $"Coaches: . . . . . . . {coachString} \n");
            teams.Add(team);
        }

        private static void AddCoachToTeam(List<Coach> coaches, Team team)
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
                Console.WriteLine("Coach not found");
            }
        }

        private static void RegisterClub(List<Club> clubs)
        {
            var club = new Club()
            {
                Id = Guid.NewGuid()
            };
            Console.WriteLine("Name of Club:");
            club.Name = Console.ReadLine();
            Console.WriteLine("Street of Club:");
            club.Street = Console.ReadLine();
            Console.WriteLine("City of Club");
            club.City = Console.ReadLine();
            Console.WriteLine("Zip Code");
            club.Zip = (Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                $"Overview of the new Club: \n" +
                $"Id: . . . . . . . {club.Id} \n" +
                $"Club-Name: . . . . . . . {club.Name} \n" +
                $"Street: . . . . . . . {club.Street} \n" +
                $"City: . . . . . . . . {club.City} \n" +
                $"Zip: . . . . . . . . .{club.Zip} \n");

            clubs.Add(club);
        }

        private static void RegisterCoach(List<Club> clubs, List<Coach> coaches)
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
                $"Overview of the new Coach: \n" +
                $"Id: . . . . . . . {coach.Id} \n" +
                $"First-Name: . . . . . . . {coach.FirstName} \n" +
                $"Last-Name: . . . . . . . {coach.LastName} \n" +
                $"Club: . . . . . . . {coach.Club.Name} \n" +
                $"Address: . . . . . . . {coach.Address} \n");

            coaches.Add(coach);
        }

        private static void RegisterPlayer(List<Club> clubs, List<Player> players)
        {
            Console.WriteLine("Register a new Player");
            Console.WriteLine("First-Name of Player:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last-Name of Player:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Address of Player:");
            string Address = Console.ReadLine();
            Console.WriteLine("Club of Player:");
            string Club = Console.ReadLine();
            Player player = new Player();

            player.Id = Guid.NewGuid();
            player.FirstName = firstName;
            player.LastName = lastName;
            player.Address = Address;
            player.Club = clubs.First(c => c.Name == Club);

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
    }
}
