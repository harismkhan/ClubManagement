using ClubManagement.Database.Context;
using ClubManagement.Domain.DomainModels;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.Repositories.Repositories
{
    public class PitchRepository : BaseRepository<Pitch>, IPitchRepository
    {
        public PitchRepository(ClubManagementContext context) : base(context)
        {
        }
    }
}
