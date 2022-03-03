using ClubManagement.Domain;

namespace ClubManagement.TestApp
{
    public interface ICoachManagerService : IClubManagementApplicationService, IManagerService<Coach>
    {
    }
}

