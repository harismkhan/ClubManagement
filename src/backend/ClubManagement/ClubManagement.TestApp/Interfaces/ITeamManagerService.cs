using ClubManagement.Domain;
using ClubManagement.TestApp;

namespace isolutions.EntityFramework.Code.First.FlightBookingApplication.Interfaces
{
    public interface ITeamManagerService : IClubManagementApplicationService, IManagerService<Team>
    {
    }
}
