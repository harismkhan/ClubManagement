namespace ClubManagement.Domain.DomainModels
{
    public class Player : Member
    {
        public decimal Height { get; set; } = 0;
        public decimal Weight { get; set; } = 0;
        public int PlayerNumber { get; set; } = 0;
    }
}
