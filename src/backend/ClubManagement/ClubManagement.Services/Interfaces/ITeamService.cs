using ClubManagement.Domain.ViewModels;
using ClubManagement.Services.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface ITeamService
    {
        Task<TeamViewModel?> GetById(Guid id);
    }
}
