using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface IPitchService
    {
        Task Create(PitchCreateModel createModel);
        Task Update(PitchUpdateModel updateModel);
        Task<PitchViewModel?> GetById(Guid id);
        Task<IEnumerable<PitchViewModel>> GetAll();
        Task Delete(Guid id);
    }
}
