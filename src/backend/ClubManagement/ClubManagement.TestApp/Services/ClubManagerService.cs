using ClubManagement.Contexts;
using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.TestApp.Interfaces;

namespace ClubManagement.TestApp
{
    public class ClubManagerService : ManagerServiceBase<Club>, IClubManagerService
    {
        public ClubManagerService(ClubManagementContext context, IBaseRepository<Club> repository) : base(context, repository)
        {
        }

        public override Task WriteEntityToConsoleAsync(Club entity, string? prefix = null)
        {
            if (!string.IsNullOrEmpty(prefix))
            {
                Console.WriteLine(prefix);
            }

            Console.WriteLine($"FirstName: {entity.Name}");
            Console.WriteLine($"Street: {entity.Street}");
            Console.WriteLine($"Zip: {entity.Zip}");
            Console.WriteLine($"City: {entity.City}");
            Console.WriteLine($"Club: {entity.Coaches}");
            Console.WriteLine($"Team: {entity.Players}");
            Console.WriteLine($"Team: {entity.Teams}");
            Console.WriteLine($"Team: {entity.Pitches}");


            Console.WriteLine();

            return Task.CompletedTask;
        }

        protected override async Task<Club?> GetCreateEntityFromUser()
        {
            Console.Write("Please provide a Name: ");
            var name = Console.ReadLine();
            Console.Write("Please provide a Street: ");
            var street = Console.ReadLine();
            Console.Write("Please provide a City: ");
            var city = Console.ReadLine();
            Console.Write("Please provide a Zip: ");
            var zip = Console.ReadLine();
            Console.Write("Please provide a Coach: ");
            var coaches = Console.ReadLine();
            Console.Write("Please provide a Player: ");
            var players = Console.ReadLine();
            Console.Write("Please provide a Teams: ");
            var teams = Console.ReadLine();


            var result = new Club
            {
                Name = name ?? "NoName",
                Street = street ?? "NoStreet",
                City = city ?? "NoCity",
                Zip = zip ?? "NoZip",
                Coaches = coaches ?? "NoCoaches",
                Players = players ?? "NoPlayer",
                Teams = teams ?? "NoTeams"
            };

            return Task.FromResult<Club?>(result);
        }

        protected override async Task<Club> GetUpdateEntityFromUser(Club entity)
        {
            Console.Write("Please provide a Name: ");
            var name = Console.ReadLine();
            Console.Write("Please provide a Street: ");
            var street = Console.ReadLine();
            Console.Write("Please provide a City: ");
            var city = Console.ReadLine();
            Console.Write("Please provide a Zip: ");
            var zip = Console.ReadLine();
            Console.Write("Please provide a Coach: ");
            var coaches = Console.ReadLine();
            Console.Write("Please provide a Player: ");
            var players = Console.ReadLine();
            Console.Write("Please provide a Teams: ");
            var teams = Console.ReadLine();

            entity.Name = name ?? entity.Name;
            entity.Street = street ?? entity.Street;
            entity.City = city ?? entity.City;
            entity.Zip = zip ?? entity.Zip;
            entity.Coaches = coaches ?? entity.Coaches;
            entity.Players = players ?? entity.Players;
            entity.Teams = teams ?? entity.Teams;
            return Task.FromResult(entity);

        }
    }
}
