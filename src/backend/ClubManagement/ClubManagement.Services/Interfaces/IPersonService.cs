using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;

namespace ClubManagement.Services.Interfaces
{
    public interface IPersonService
    {
        Task Create(PersonCreateModel createModel);
        Task Update(PersonUpdateModel updateModel);
        Task<PersonViewModel?> GetById(Guid id);
        Task<IEnumerable<PersonViewModel>> GetAll();
        Task Delete(Guid id);
        
    }
}
