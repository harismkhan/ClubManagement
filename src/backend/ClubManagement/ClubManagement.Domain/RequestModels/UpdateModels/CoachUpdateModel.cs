using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.RequestModels.UpdateModels
{
    public class CoachUpdateModel
    {
        public Guid Id { get; set; }
        public CoachType Type { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public Guid ClubId { get; set; }
        public Guid TeamId { get; set; }
    }
}
