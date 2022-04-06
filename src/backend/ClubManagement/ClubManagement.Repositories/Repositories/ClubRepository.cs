using ClubManagement.Database.Context;
using ClubManagement.Domain.DomainModels;
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
