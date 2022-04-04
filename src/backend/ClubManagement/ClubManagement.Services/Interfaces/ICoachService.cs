using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface ICoachService
    {
        Task Create(CoachCreateModel createModel);
        Task Update(CoachUpdateModel updateModel);
        Task<CoachViewModel> GetById(Guid id);
        Task<IEnumerable<CoachViewModel>> GetAll();
        Task<IEnumerable<CoachViewModel>> GetAllByTeamId(Guid teamId);
        Task Delete(Guid id);

    }
}
