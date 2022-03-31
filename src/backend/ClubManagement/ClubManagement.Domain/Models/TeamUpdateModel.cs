using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.Models
{
    public class TeamUpdateModel
    {
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public TeamLevel Level { get; set; }
    }
}