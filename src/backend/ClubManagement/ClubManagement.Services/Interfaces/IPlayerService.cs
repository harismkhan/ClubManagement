using ClubManagement.Domain.Models;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface IPlayerService
    {
        Task Create(PlayerCreateModel createModel);
        Task Update(PlayerUpdateModel updateModel);
        Task<PlayerViewModel?> GetById(Guid id);
        Task<IEnumerable<PlayerViewModel>> GetAll();
        Task Delete(Guid id);
        
    }
}
