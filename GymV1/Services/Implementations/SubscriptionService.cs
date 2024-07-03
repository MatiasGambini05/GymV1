using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;
using GymV1.ModelsContextDTOs.Models.Enums;
using GymV1.Repositories.Interfaces;
using GymV1.Services.Interfaces;

namespace GymV1.Services.Implementations
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _subscriptionRepository.GetAllSubscriptions();
        }

        public CurrentSubscriptionDTO GetCurrentSubscriptionDTO(string email)
        {
            var clientEmail = _userRepository.GetUserByEmail(email);
            var subscriptions = clientEmail.Subscriptions.FirstOrDefault();

            return new CurrentSubscriptionDTO
            {
                StartDate = subscriptions.StartDate,
                EndDate = subscriptions.EndDate,
                Type = subscriptions.Type.ToString()
            };
        }

        public string NewSubscription(NewSubscriptionDTO newSubscriptionDTO)
        {
            var typeToInt = (SubscriptionType)Enum.Parse(typeof(SubscriptionType), newSubscriptionDTO.Type, true);
            Subscription newSubscription = new Subscription
            {
                UserId = newSubscriptionDTO.UserId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(newSubscriptionDTO.Days),
                Type = typeToInt
            };
            _subscriptionRepository.SaveS(newSubscription);

            return "Subscripción creada correctamente";
        }

        public string UpdateSubscription(UpdateSubscriptionDTO updateSubscriptionDTO)
        {
            var user = _userRepository.GetUserById(updateSubscriptionDTO.UserId);
            var subscription = user.Subscriptions.FirstOrDefault();
            var typeToInt = (SubscriptionType)Enum.Parse(typeof(SubscriptionType), updateSubscriptionDTO.Type, true);

            subscription.EndDate = subscription.EndDate.AddDays(updateSubscriptionDTO.Days);
            subscription.Type = typeToInt;
            _subscriptionRepository.SaveS(subscription);

            return "Subscripción actualizada correctamente.";
        }

        public string DeleteSubscription(int id)
        {
            var user = _userRepository.GetUserById(id);
            var subscription = user.Subscriptions.FirstOrDefault();

            _subscriptionRepository.Deletes(subscription);

            return "Subscripción eliminada correctamente.";
        }

    }
}
