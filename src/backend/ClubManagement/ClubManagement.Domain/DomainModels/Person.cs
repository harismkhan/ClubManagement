using ClubManagement.Backbone;
using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.DomainModels
{
    public class Person : Entity
    {
        public PersonType Type { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
    }
}
