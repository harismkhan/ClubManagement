using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface IClubService
    {
        Task Create(ClubCreateModel createModel);
        Task Update(ClubUpdateModel updateModel);
        Task<ClubViewModel?> GetById(Guid id);
        Task<IEnumerable<ClubViewModel>> GetAll();
        Task Delete(Guid id);   
    }
}
