using ClubManagement.Contexts;
using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.TestApp
{
    public class CoachManagerService : ManagerServiceBase<Coach>, ICoachManagerService
    {
        public CoachManagerService(ClubManagementContext context, IBaseRepository<Coach> repository) : base(context, repository)
        {
        }

        public override Task WriteEntityToConsoleAsync(Coach entity, string? prefix = null)
        {
            if (!string.IsNullOrEmpty(prefix))
            {
                Console.WriteLine(prefix);
            }

            Console.WriteLine($"FirstName: {entity.FirstName}");
            Console.WriteLine($"LastName: {entity.LastName}");
            Console.WriteLine($"BirthDate: {entity.BirthDate}");
            Console.WriteLine($"Street: {entity.Street}");
            Console.WriteLine($"Zip: {entity.Zip}");
            Console.WriteLine($"City: {entity.City}");
            Console.WriteLine($"Club: {entity.Club}");
            Console.WriteLine($"Teas: {entity.Team}");
            Console.WriteLine($"Type: {entity.Type}");

            Console.WriteLine();

            return Task.CompletedTask;
        }
 
        protected override Task<Coach?> GetCreateEntityFromUser()
        {
            Console.Write("Please provide your FirstName: ");
            var firstName = Console.ReadLine();
            Console.Write("Please provide your LastName: ");
            var lastName = Console.ReadLine();
            Console.Write("Please provide your BirthDate: ");
            var birthDate = Console.ReadLine();
            Console.Write("Please provide a Street: ");
            var street = Console.ReadLine();
            Console.Write("Please provide a City: ");
            var city = Console.ReadLine();
            Console.Write("Please provide a Zip: ");
            var zip = Console.ReadLine();
            Console.Write("Please provide a Club for your Coach: ");
            var club = Console.ReadLine();
            Console.Write("Please provide a Team for your Coach: ");
            var Team = Console.ReadLine();
            Console.Write("Please provide a CoachType: ");
            var type = Console.ReadLine();


            var result = new Coach
            {
                FirstName = firstName ?? "NoCity",
                LastName = lastName ?? "NoCity",
                BirthDate = birthDate ?? "NoCity",
                Street = street ?? "NoCity",
                City = city ?? "NoCity",
                Zip = zip ?? "NoCity",
                Club = Club ?? "NoCity",
                Team = Team ?? "NoCity",
                Type = type ?? "ABC"
            };

            return Task.FromResult<Coach?>(result);
        }

        protected override Task<Coach> GetUpdateEntityFromUser(Coach entity)
        {
            Console.Write("Please provide your FirstName: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Please provide your LastName: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Please provide your BirthDate: ");
            var birthDate = Console.ReadLine();

            Console.WriteLine("Please provide your Street: ");
            var street = Console.ReadLine();

            Console.WriteLine("Please provide your City: ");
            var city = Console.ReadLine();

            Console.WriteLine("Please provide a Zip: ");
            var zip = Console.ReadLine();

            Console.WriteLine("Please provide a Club for your Coach: ");
            var club = Console.ReadLine();

            Console.WriteLine("Please provide a Team for your Coach: ");
            var team = Console.ReadLine();

            Console.WriteLine("Please provide a CoachType: ");
            var type = Console.ReadLine();

            entity.FirstName = firstName ?? entity.FirstName;
            entity.LastName = lastName ?? entity.LastName;
            entity.BirthDate = birthDate ?? entity.BirthDate;
            entity.Street = street ?? entity.Street;
            entity.City = city ?? entity.City;
            entity.Zip = zip ?? entity.Zip;



            return Task.FromResult(entity);
        }
    }
}
