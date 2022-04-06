using ClubManagement.Domain.DomainModels;
using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;

namespace ClubManagement.Services
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository coachRepository;

        public CoachService(ICoachRepository coachRepository)
        {
            this.coachRepository = coachRepository;
        }

        public async Task Create(CoachCreateModel createModel)
        {
            var coach = new Coach
            {
                Type = createModel.Type,
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                BirthDate = createModel.BirthDate,
                Street = createModel.Street,
                City = createModel.City,
                Zip = createModel.Zip,
                ClubId = createModel.ClubId,
                TeamId = createModel.TeamId,
            };

            coachRepository.Add(coach);
            await coachRepository.SaveContextChanges();
        }

        public async Task Update(CoachUpdateModel updateModel)
        {
            var coachToUpdate = await coachRepository.GetAsync(updateModel.Id);

            if (coachToUpdate == null)
            {
                throw new ArgumentException();
            }

            coachToUpdate.Type = updateModel.Type;
            coachToUpdate.FirstName = updateModel.FirstName;
            coachToUpdate.LastName = updateModel.LastName;
            coachToUpdate.BirthDate = updateModel.BirthDate;
            coachToUpdate.City = updateModel.City;
            coachToUpdate.Street = updateModel.Street;
            coachToUpdate.Zip = updateModel.Zip;
            coachToUpdate.ClubId = updateModel.ClubId;
            coachToUpdate.TeamId = updateModel.TeamId;

            coachRepository.Update(coachToUpdate);
            await coachRepository.SaveContextChanges();
        }

        public async Task<CoachViewModel> GetById(Guid id)
        {
            var coach = await coachRepository.GetAsync(id);

            if (coach == null)
            {
                throw new ArgumentException($"{nameof(Coach)} with id {id} not found.");
            }

            return new CoachViewModel()
            {
                Id = coach.Id,
                Type = coach.Type,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                BirthDate = coach.BirthDate,
                Street = coach.Street,
                City = coach.City,
                Zip = coach.Zip,
                ClubId = coach.ClubId,
                TeamId = coach.TeamId,
            };
        }

        public async Task<IEnumerable<CoachViewModel>> GetAll()
        {
            var coaches = await coachRepository.GetAllAsync();

            var coachViewModels = coaches.Select(coach => new CoachViewModel()
            {
                Id = coach.Id,
                Type = coach.Type,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                BirthDate = coach.BirthDate,
                Street = coach.Street,
                City = coach.City,
                Zip = coach.Zip,
                ClubId = coach.ClubId,
                TeamId = coach.TeamId,
            });

            return coachViewModels;
        }
        public async Task<IEnumerable<CoachViewModel>> GetAllByTeamId(Guid teamId)
        {
            var team = await coachRepository.GetOtherAsync<Team>(teamId);

            if (team == null)
            {
                throw new ArgumentException($"{nameof(Team)} with id {teamId} not found.");
            }

            var coachViewModels = team.Coaches.Select(coach => new CoachViewModel()
            {
                Id = coach.Id,
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                BirthDate = coach.BirthDate,
                Street = coach.Street,
                City = coach.City,
                Zip = coach.Zip,
                ClubId = coach.ClubId,
                TeamId = coach.TeamId,
            });

            return coachViewModels;
        }

        public async Task Delete(Guid id)
        {
            var coachToDelete = await coachRepository.GetAsync(id);

            if (coachToDelete == null)
            {
                throw new ArgumentException();
            }

            coachRepository.Remove(coachToDelete);
            await coachRepository.SaveContextChanges();
        }

    }
}
