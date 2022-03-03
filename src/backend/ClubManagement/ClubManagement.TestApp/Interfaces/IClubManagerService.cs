using ClubManagement.Domain;

namespace ClubManagement.TestApp
{
    public interface IClubManagerService : IClubManagementApplicationService, IManagerService<Club>
    {
    }
}
