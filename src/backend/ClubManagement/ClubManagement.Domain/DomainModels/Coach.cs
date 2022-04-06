using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain.DomainModels
{
    public class Coach : Member
    { 
        public CoachType Type { get; set; }
    }
}
