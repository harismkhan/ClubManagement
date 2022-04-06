using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.ViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public TeamLevel Level { get; set; }
        public Guid ClubId { get; set; }
    }
}
