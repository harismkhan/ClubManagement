using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface ITeamService
    {
        Task Create(TeamCreateModel createModel);
        Task Update(TeamUpdateModel updateModel);
        Task<TeamViewModel?> GetById(Guid id);
        Task<IEnumerable<TeamViewModel>> GetAll();
        Task Delete(Guid id);
    }
}
