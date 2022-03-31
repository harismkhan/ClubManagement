using ClubManagement.Domain.Models;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface ICoachService
    {
        Task Create(CoachCreateModel createModel);
        Task Update(CoachUpdateModel updateModel);
        Task<CoachViewModel?> GetById(Guid id);
        Task<IEnumerable<CoachViewModel>> GetAll();
        Task Delete(Guid id);

    }
}
