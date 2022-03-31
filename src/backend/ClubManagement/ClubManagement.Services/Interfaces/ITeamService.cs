using ClubManagement.Domain.Models;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.ViewModels;

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
