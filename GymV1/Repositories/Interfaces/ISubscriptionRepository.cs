using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetAllSubscriptions();
        Subscription GetSubscriptionById(int id);
        void SaveS(Subscription subscription);
        void Deletes(Subscription subscription);
    }
}
