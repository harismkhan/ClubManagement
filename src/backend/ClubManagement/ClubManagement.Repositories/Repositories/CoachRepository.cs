using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagement.Repositories
{
    public class CoachRepository : BaseRepository<Coach>, ICoachRepository
    {
        public CoachRepository(DbContext context) : base(context)
        {
        }
    }
}