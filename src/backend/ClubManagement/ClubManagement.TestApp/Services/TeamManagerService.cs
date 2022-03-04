using ClubManagement.Contexts;
using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.TestApp.Interfaces;

namespace ClubManagement.TestApp
{
    public class TeamManagerService : ManagerServiceBase<Team>, ITeamManagerService
    {
        public TeamManagerService(ClubManagementContext context, IBaseRepository<Team> repository) : base(context, repository)
        {
        }

        public override Task WriteEntityToConsoleAsync(Team entity, string? prefix = null)
        {
            if (!string.IsNullOrEmpty(prefix))
            {
                Console.WriteLine(prefix);
            }

            Console.WriteLine($"TeamLevel: {entity.Level}");
            Console.WriteLine($"Club: {entity.Club}");
            Console.WriteLine($"Coach: {entity.Coaches}");
            Console.WriteLine($"Player: {entity.Players}");

            Console.WriteLine();

            return Task.CompletedTask;
        }

        protected override Task<Team?> GetCreateEntityFromUser()
        {
            Console.Write("Please provide the TeamLevel: ");
            var level = Console.ReadLine();
            Console.Write("Please provide the Club: ");
            var club = Console.ReadLine();
            Console.Write("Please provide the Team Coach/es: ");
            var coach = Console.ReadLine();
            Console.Write("Please provide the Players of the Team: ");
            var players = Console.ReadLine();


            var result = new Team
            {
                Level = level ?? "NoCity",
                Club = club ?? "NoClub",
                Coaches = coach ?? "NoCoach",
                Players = players ?? "Noplayer"
            };

            return Task.FromResult<Team?>(result);
        }

        protected override Task<Team> GetUpdateEntityFromUser(Team entity)
        {
            Console.Write("Please provide the TeamLevel: ");
            var level = Console.ReadLine();

            Console.Write("Please provide the Club: ");
            var club = Console.ReadLine();

            Console.Write("Please provide the Team Coach/es: ");
            var coach = Console.ReadLine();

            Console.Write("Please provide the Players of the Team: ");
            var players = Console.ReadLine();

            entity.Level = TeamLevel ?? entity.Level;
            entity.Club = club ?? entity.Club;
            entity.Coaches = coach ?? entity.Coaches;
            entity.Players = players ?? entity.Players;


            return Task.FromResult(entity);
        }
    }
}
