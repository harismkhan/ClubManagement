using ClubManagement.Contexts;
using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.TestApp
{
    public class PlayerManagerService : ManagerServiceBase<Player>, IPlayerManagerService
    {
        public PlayerManagerService(ClubManagementContext context, IBaseRepository<Player> repository) : base(context, repository)
        {
        }

        public override Task WriteEntityToConsoleAsync(Player entity, string? prefix = null)
        {
            if (!string.IsNullOrEmpty(prefix))
            {
                Console.WriteLine(prefix);
            }

            Console.WriteLine($"FirstName: {entity.FirstName}");
            Console.WriteLine($"LastName: {entity.LastName}");
            Console.WriteLine($"BirthDate: {entity.BirthDate}");
            Console.WriteLine($"Height: {entity.Height}");
            Console.WriteLine($"Weight: {entity.Weight}");
            Console.WriteLine($"PlayerNumber: {entity.PlayerNumber}");
            Console.WriteLine($"Street: {entity.Street}");
            Console.WriteLine($"Zip: {entity.Zip}");
            Console.WriteLine($"City: {entity.City}");
            Console.WriteLine($"Club: {entity.Club}");
            Console.WriteLine($"Team: {entity.Team}");

            Console.WriteLine();

            return Task.CompletedTask;
        }

        protected override Task<Player?> GetCreateEntityFromUser()
        {
            Console.Write("Please provide your FirstName: ");
            var firstName = Console.ReadLine();
            Console.Write("Please provide your LastName: ");
            var lastName = Console.ReadLine();
            Console.Write("Please provide your BirthDate: ");
            var birthDate = Console.ReadLine();
            Console.Write("Please provide your Height in meters: ");
            var height = Console.ReadLine();
            Console.Write("Please provide your Weight in kg: ");
            var weight = Console.ReadLine();
            Console.Write("Please provide your PlayerNumber: ");
            var playerNumber = Console.ReadLine();
            Console.Write("Please provide a Street: ");
            var street = Console.ReadLine();
            Console.Write("Please provide a City: ");
            var city = Console.ReadLine();
            Console.Write("Please provide a Zip: ");
            var zip = Console.ReadLine();
            Console.Write("Please provide a Club for your Player: ");
            var club = Console.ReadLine();
            Console.Write("Please provide a Team for your Player: ");
            var team = Console.ReadLine();


            var result = new Player
            {
                FirstName = firstName ?? "NoCity",
                LastName = lastName ?? "NoCity",
                BirthDate = birthDate ?? "NoCity",
                Height = height ?? "NoCity",
                Weight = weight ?? "NoCity",
                PlayerNumber = playerNumber ?? "NoCity",
                Street = street ?? "NoCity",
                City = city ?? "NoCity",
                Zip = zip ?? "NoCity",
                Club = club ?? "NoCity",
                Team = team ?? "NoCity"
            };

            return Task.FromResult<Player?>(result);
        }

        protected override Task<Player> GetUpdateEntityFromUser(Player entity)
        {
            Console.Write("Please provide your FirstName: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Please provide your LastName: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Please provide your BirthDate: ");
            var birthDate = Console.ReadLine();

            Console.WriteLine("Please provide your Height in meters: ");
            var height = Console.ReadLine();

            Console.WriteLine("Please provide your Weight in kg: ");
            var weight = Console.ReadLine();

            Console.WriteLine("Please provide your PlayerNumber: ");
            var playerNumber = Console.ReadLine();

            Console.WriteLine("Please provide your Street: ");
            var street = Console.ReadLine();

            Console.WriteLine("Please provide your City: ");
            var city = Console.ReadLine();

            Console.WriteLine("Please provide a Zip: ");
            var zip = Console.ReadLine();

            Console.WriteLine("Please provide a Club for your Player: ");
            var club = Console.ReadLine();

            Console.WriteLine("Please provide a Team for your Player: ");
            var team = Console.ReadLine();


            entity.FirstName = firstName ?? entity.FirstName;
            entity.LastName = lastName ?? entity.LastName;
            entity.BirthDate = birthDate ?? entity.BirthDate;
            entity.Height = height ?? entity.Height;
            entity.Weight = weight ?? entity.Weight;
            entity.PlayerNumber = playerNumber ?? entity.PlayerNumber;
            entity.Street = street ?? entity.Street;
            entity.City = city ?? entity.City;
            entity.Zip = zip ?? entity.Zip;


            return Task.FromResult(entity);
        }
    }
}
