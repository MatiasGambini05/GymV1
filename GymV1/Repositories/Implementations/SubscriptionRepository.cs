using GymV1.ModelsContextDTOs.Context;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;

namespace GymV1.Repositories.Implementations
{
    public class SubscriptionRepository: RepositoryBase<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(GymContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return FindAll()
                .ToList();
        }

        public Subscription GetSubscriptionById(int id)
        {
            return FindByCondition(s => s.UserId == id)
                .FirstOrDefault();
        }

        public void SaveS(Subscription subscription)
        {
            if (subscription.SubscriptionId == 0)
                Create(subscription);
            else
                Update(subscription);

            SaveChanges();
            RepositoryContext.ChangeTracker.Clear();
        }

        public void Deletes(Subscription subscription)
        {
            Delete(subscription);
            SaveChanges();
        }
    }
}
