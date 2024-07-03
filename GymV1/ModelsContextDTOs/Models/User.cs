using GymV1.ModelsContextDTOs.Models.Enums;

namespace GymV1.ModelsContextDTOs.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Membership> Memberships { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
