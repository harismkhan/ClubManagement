using ClubManagement.Domain.DomainModels;
using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;

namespace ClubManagement.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository clubRepository;

        public ClubService(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public async Task Create(ClubCreateModel createModel)
        {
            var club = new Club
            {
                Name = createModel.Name,
                Street = createModel.Street,
                City = createModel.City,
                Zip = createModel.Zip,
            };

            clubRepository.Add(club);
            await clubRepository.SaveContextChanges();
        }

        public async Task Update(ClubUpdateModel updateModel)
        {
            var clubToUpdate = await clubRepository.GetAsync(updateModel.Id);

            if (clubToUpdate == null)
            {
                throw new ArgumentException();
            }

            clubToUpdate.Name = updateModel.Name;
            clubToUpdate.City = updateModel.City;
            clubToUpdate.Street = updateModel.Street;
            clubToUpdate.Zip = updateModel.Zip;

            clubRepository.Update(clubToUpdate);
            await clubRepository.SaveContextChanges();
        }

        public async Task<ClubViewModel> GetById(Guid id)
        {
            var club = await clubRepository.GetAsync(id);
            
            if (club == null)
            {
                throw new ArgumentException($"{nameof(Club)} with id {id} not found.");
            }

            return new ClubViewModel()
            {
                Id = club.Id,
                Name = club.Name,
                City = club.City,
                Street = club.Street,
                Zip = club.Zip,
            };
        }

        public async Task<IEnumerable<ClubViewModel>> GetAll()
        {
            var clubs = await clubRepository.GetAllAsync();

            var clubViewModels = clubs.Select(club => new ClubViewModel()
            {
                Id = club.Id,
                Name = club.Name,
                Street = club.Street, 
                City = club.City,
                Zip = club.Zip,
            });

            return clubViewModels;
        }

        public async Task Delete(Guid id)
        {
            var clubToDelete = await clubRepository.GetAsync(id);
            
            if (clubToDelete == null)
            {
                throw new ArgumentException();
            }

            clubRepository.Remove(clubToDelete);
            await clubRepository.SaveContextChanges();
        }

    }
}
