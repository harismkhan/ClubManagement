using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.Models
{
    public class TeamCreateModel
    {
        public Guid ClubId { get; set; }
        public TeamLevel Level { get; set; }
    }
}
