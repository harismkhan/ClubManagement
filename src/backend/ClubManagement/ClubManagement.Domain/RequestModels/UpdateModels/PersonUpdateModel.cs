using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.RequestModels.UpdateModels
{
    public class PersonUpdateModel
    {
        public Guid Id { get; set; }
        public PersonType Type { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }
}