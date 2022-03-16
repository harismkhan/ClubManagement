using ClubManagement.Contexts;
using ClubManagement.Domain;
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