using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public async Task<TeamViewModel?> GetById(Guid id)
        {
            var team = await teamRepository.GetAsync(id);

            return team != null ? new TeamViewModel()
            {
                Id = team.Id,
                Club = team.Club,
                Level = team.Level,
            } : null;
        }
    }
}
