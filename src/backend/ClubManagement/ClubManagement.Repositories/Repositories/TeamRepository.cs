using ClubManagement.Contexts;
using ClubManagement.Domain;
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
