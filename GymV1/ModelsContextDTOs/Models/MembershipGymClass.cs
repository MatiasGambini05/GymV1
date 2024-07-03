namespace GymV1.ModelsContextDTOs.Models
{
    public class MembershipGymClass
    {
        public int MembershipGymClassId { get; set; }
        public Membership Membership { get; set; }
        public int MembershipId { get; set; }
        public GymClass GymClass { get; set; }
        public int GymClassId { get; set; }
    }
}
