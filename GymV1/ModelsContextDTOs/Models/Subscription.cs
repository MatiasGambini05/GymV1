using GymV1.ModelsContextDTOs.Models.Enums;

namespace GymV1.ModelsContextDTOs.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public SubscriptionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
