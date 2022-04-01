using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.RequestModels.CreateModels
{
    public class TeamCreateModel
    {
        public Guid ClubId { get; set; }
        public TeamLevel Level { get; set; }
    }
}
