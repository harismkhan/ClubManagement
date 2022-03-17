using ClubManagement.Domain.Enums;

namespace ClubManagement.Domain
{
    public class Coach : Member
    { 
        public CoachType Type { get; set; }
    }
}
