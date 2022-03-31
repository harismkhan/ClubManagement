using ClubManagement.Domain.Models;
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
