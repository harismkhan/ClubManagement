namespace ClubManagement.Domain.RequestModels.UpdateModels
{
    public class ClubUpdateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }
}