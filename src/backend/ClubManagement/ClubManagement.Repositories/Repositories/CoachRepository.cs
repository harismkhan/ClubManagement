using ClubManagement.Database.Context;
using ClubManagement.Domain.DomainModels;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.Repositories.Repositories
{
    public class CoachRepository : BaseRepository<Coach>, ICoachRepository
    {
        public CoachRepository(ClubManagementContext context) : base(context)
        {
        }
    }
}
