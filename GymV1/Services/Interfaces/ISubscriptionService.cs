using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Services.Interfaces
{
    public interface ISubscriptionService
    {
        IEnumerable<Subscription> GetAllSubscriptions();
        CurrentSubscriptionDTO GetCurrentSubscriptionDTO(string email);
        string NewSubscription(NewSubscriptionDTO newSubscriptionDTO);
        string UpdateSubscription(UpdateSubscriptionDTO updateSubscriptionDTO);
        string DeleteSubscription(int id);
    }
}
