using ClubManagement.Domain;

namespace ClubManagement.TestApp.Interfaces
{
    public interface IPitchManagerService : IClubManagementApplicationService, IManagerService<Pitch>
    {
    }
}
