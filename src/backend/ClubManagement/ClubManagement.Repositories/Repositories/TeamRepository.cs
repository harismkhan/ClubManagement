using ClubManagement.Domain;
using ClubManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagement.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(DbContext context) : base(context)
        {
        }
    }
}