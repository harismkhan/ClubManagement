using ClubManagement.Domain;

namespace ClubManagement.TestApp.Interfaces
{
    public interface ITeamManagerService : IClubManagementApplicationService, IManagerService<Team>
    {
    }
}
