using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagement.Repositories
{
    public class ClubRepository : BaseRepository<Club>, IClubRepository
    {
        public ClubRepository(DbContext context) : base(context)
        {
        }
    }
}