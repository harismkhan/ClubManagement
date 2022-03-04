using ClubManagement.Contexts;
using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.TestApp.Interfaces
{
    public class PitchManagerService : ManagerServiceBase<Pitch>, IPitchManagerService
    {
        public PitchManagerService(ClubManagementContext context, IBaseRepository<Pitch> repository) : base(context, repository)
        {
        }

        public override Task WriteEntityToConsoleAsync(Pitch entity, string? prefix = null)
        {
            throw new NotImplementedException();
        }

        protected override Task<Pitch?> GetCreateEntityFromUser()
        {
            throw new NotImplementedException();
        }

        protected override Task<Pitch> GetUpdateEntityFromUser(Pitch entity)
        {
            throw new NotImplementedException();
        }
    }
}
