namespace ClubManagement.Domain.RequestModels.CreateModels
{
    public class PitchCreateModel
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public Guid? ClubId { get; set; }
    }
}
