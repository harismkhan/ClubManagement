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
    }
}
