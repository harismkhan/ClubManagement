using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagement.Repositories
{
    public class PitchRepository : BaseRepository<Pitch>, IPitchRepository
    {
        public PitchRepository(DbContext context) : base(context)
        {
        }
    }
}