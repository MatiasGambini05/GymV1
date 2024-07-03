using GymV1.ModelsContextDTOs.DTOs;
using GymV1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IUserService _userService;
        public SubscriptionController(ISubscriptionService subscriptionService, IUserService userService)
        {
            _subscriptionService = subscriptionService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllSubscriptions()
        {
            try
            {
                var allSubscriptions = _subscriptionService.GetAllSubscriptions();
                return Ok(allSubscriptions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("Current")]
        public IActionResult GetCurrentSubscription()
        {
            try
            {
                var clientEmail = User.FindFirst("Client") != null ? User.FindFirst("Client").Value : string.Empty;
                if (clientEmail == string.Empty)
                    return StatusCode(403);

                CurrentSubscriptionDTO current = _subscriptionService.GetCurrentSubscriptionDTO(clientEmail);
                return Ok(current);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult NewSubscription([FromBody] NewSubscriptionDTO newSubscriptionDTO)
        {
            try
            {
                var newSubscription = _subscriptionService.NewSubscription(newSubscriptionDTO);
                return Ok(newSubscription);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateSubscription([FromBody] UpdateSubscriptionDTO updateSubscriptionDTO)
        {
            try
            {
                var updateSubscription = _subscriptionService.UpdateSubscription(updateSubscriptionDTO);
                return Ok(updateSubscription);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteSubscription(int id)
        {
            try
            {
                var deleteSubscription = _subscriptionService.DeleteSubscription(id);
                return Ok(deleteSubscription);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
