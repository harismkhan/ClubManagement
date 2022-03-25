using ClubManagement.Domain;
using ClubManagement.Domain.Models;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;
using ClubManagement.Services.ViewModels;

namespace ClubManagement.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository clubRepository;

        public ClubService(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public async Task<ClubViewModel?> GetById(Guid id)
        {
            var club = await clubRepository.GetAsync(id);

            return club != null ? new ClubViewModel()
            {
                Id = club.Id,
                Name = club.Name,
                City = club.City,
                Street = club.Street,
                Zip = club.Zip,
            } : null;
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
        }

        public void Create(ClubCreateModel createModel)
        {
            var club = new Club
            {
                Name = createModel.Name,
                Street = createModel.Street,
                City = createModel.City,
                Zip = createModel.Zip,
            };

            clubRepository.Add(club);
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
        }
    }
}
