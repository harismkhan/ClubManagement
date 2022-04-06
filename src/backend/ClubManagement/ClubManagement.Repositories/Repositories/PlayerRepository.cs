using ClubManagement.Database.Context;
using ClubManagement.Domain.DomainModels;
using ClubManagement.Repositories.Interfaces;

namespace ClubManagement.Repositories.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ClubManagementContext context) : base(context)
        {
        }
    }
}
