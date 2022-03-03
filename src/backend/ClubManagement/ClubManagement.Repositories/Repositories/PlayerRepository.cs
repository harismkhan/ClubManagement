using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagement.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext context) : base(context)
        {
        }
    }
}