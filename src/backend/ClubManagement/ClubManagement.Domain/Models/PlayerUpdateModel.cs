namespace ClubManagement.Domain.Models
{
    public class PlayerUpdateModel
    {
        public Guid PlayerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public decimal Height { get; set; } = 0;
        public decimal Weight { get; set; } = 0;
        public int PlayerNumber { get; set; } = 0;
        public Guid ClubId { get; set; }
        public Guid TeamId { get; set; }
    }
}
