namespace ClubManagement.Domain
{
    public class Player : Member
    {
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int PlayerNumber { get; set; }
    }
}
