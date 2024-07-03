using GymV1.ModelsContextDTOs.Models.Enums;

namespace GymV1.ModelsContextDTOs.Models
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipType Type { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<MembershipGymClass> MembershipGymClasses { get; set; }
    }
}
