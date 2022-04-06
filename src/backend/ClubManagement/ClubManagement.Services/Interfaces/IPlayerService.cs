using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface IPlayerService
    {
        Task Create(PlayerCreateModel createModel);
        Task Update(PlayerUpdateModel updateModel);
        Task<PlayerViewModel> GetById(Guid id);
        Task<IEnumerable<PlayerViewModel>> GetAll();
        Task<IEnumerable<PlayerViewModel>> GetAllByTeamId(Guid teamId);
        Task Delete(Guid id);
    }
}
