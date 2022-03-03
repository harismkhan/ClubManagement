using ClubManagement.Domain;

namespace ClubManagement.TestApp
{
    public interface IPitchManagerService : IClubManagementApplicationService, IManagerService<Pitch>
    {
    }
}
