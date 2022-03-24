using ClubManagement.Services.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface IClubService
    {
        Task<ClubViewModel?> GetById(Guid id);
    }
}
