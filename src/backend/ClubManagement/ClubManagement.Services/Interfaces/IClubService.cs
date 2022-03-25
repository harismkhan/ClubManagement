using ClubManagement.Domain.Models;
using ClubManagement.Services.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface IClubService
    {
        Task<ClubViewModel?> GetById(Guid id);
        Task<IEnumerable<ClubViewModel>> GetAll();
        Task Delete(Guid id);
        void Create(ClubCreateModel createModel);
        Task Update(ClubUpdateModel updateModel);
    }
}
