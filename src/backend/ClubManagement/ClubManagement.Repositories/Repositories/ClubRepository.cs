using ClubManagement.Contexts;
using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.Repositories.Repositories
{
    public class ClubRepository : BaseRepository<Club>, IClubRepository
    {
        public ClubRepository(ClubManagementContext context) : base(context)
        {
        }
    }
}
