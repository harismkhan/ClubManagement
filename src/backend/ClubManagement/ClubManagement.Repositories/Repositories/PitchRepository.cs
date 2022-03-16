using ClubManagement.Contexts;
using ClubManagement.Domain;
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