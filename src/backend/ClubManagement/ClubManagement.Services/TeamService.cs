using ClubManagement.Domain.DomainModels;
using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;

namespace ClubManagement.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }
        public async Task Create(TeamCreateModel createModel)
        {
            var team = new Team
            {
                Level = createModel.Level,
                ClubId = createModel.ClubId,
            };

            teamRepository.Add(team);
            await teamRepository.SaveContextChanges();
        }

        public async Task Update(TeamUpdateModel updateModel)
        {
            var teamToUpdate = await teamRepository.GetAsync(updateModel.Id);

            if (teamToUpdate == null)
            {
                throw new ArgumentException();
            }

            teamToUpdate.Level = updateModel.Level;
            teamToUpdate.ClubId = updateModel.ClubId;

            teamRepository.Update(teamToUpdate);
            await teamRepository.SaveContextChanges();
        }

        public async Task<TeamViewModel> GetById(Guid id)
        {
            var team = await teamRepository.GetAsync(id);

            if (team == null)
            {
                throw new ArgumentException($"{nameof(Team)} with id {id} not found.");
            }

            return new TeamViewModel()
            {
                Id = team.Id,
                Level = team.Level,
                ClubId = team.ClubId,
            };
        }

        public async Task<IEnumerable<TeamViewModel>> GetAll()
        {
            var teams = await teamRepository.GetAllAsync();

            var teamViewModels = teams.Select(team => new TeamViewModel()
            {
                Id = team.Id,
                Level = team.Level,
                ClubId = team.ClubId,
            });

            return teamViewModels;
        }

        public async Task Delete(Guid id)
        {
            var teamToDelete = await teamRepository.GetAsync(id);

            if (teamToDelete == null)
            {
                throw new ArgumentException();
            }

            teamRepository.Remove(teamToDelete);
            await teamRepository.SaveContextChanges();
        }

    }
}
