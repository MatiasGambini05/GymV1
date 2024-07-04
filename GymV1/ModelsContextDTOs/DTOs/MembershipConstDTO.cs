using GymV1.ModelsContextDTOs.Models;
using GymV1.ModelsContextDTOs.Models.Enums;

namespace GymV1.ModelsContextDTOs.DTOs
{
    public class MembershipConstDTO
    {
        public int MembershipId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public MembershipConstDTO(Membership membership)
        {
            MembershipId = membership.MembershipId;
            StartDate = membership.StartDate;
            EndDate = membership.EndDate;
            Type = membership.Type.ToString();
        }
    }
}
