using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.ViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }
        public virtual Club? Club { get; set; }
        public TeamLevel Level { get; set; }
    }
}
