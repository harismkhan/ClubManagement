namespace ClubManagement.Domain.ViewModels
{
    public class PitchViewModel
    {
        public Guid Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public Guid? ClubId { get; set; }
    }
}
