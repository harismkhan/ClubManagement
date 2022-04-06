using ClubManagement.Database.Context;
using ClubManagement.Domain.DomainModels;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.Repositories.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(ClubManagementContext context) : base(context)
        {
        }
    }
}
