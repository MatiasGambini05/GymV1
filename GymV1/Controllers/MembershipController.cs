using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _membershipService;
        private readonly IUserService _userService;
        public MembershipController(IMembershipService membershipService, IUserService userService)
        {
            _membershipService = membershipService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllMembership()
        {
            try
            {
                IEnumerable<Membership> memberships = _membershipService.GetAllMemberships();
                return Ok(memberships);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("current")]
        public IActionResult GetCurrentMembership()
        {
            try
            {
                var clientEmail = User.FindFirst("Client") != null ? User.FindFirst("Client").Value : string.Empty;
                if (clientEmail == string.Empty)
                    return StatusCode(403);

                CurrentMembershipDTO membership = _membershipService.GetCurrentMembershipDTO(clientEmail);
                return Ok(membership);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult NewMembership([FromBody] NewMembershipDTO newMembershipDTO)
        {
            try
            {
                var newMembership = _membershipService.NewMembership(newMembershipDTO);
                return Ok(newMembership);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateMembership([FromBody] UpdateMembershipDTO membershipDurationDTO)
        {
            try
            {
                var updateMembership = _membershipService.UpdateMembership(membershipDurationDTO);
                return Ok(updateMembership);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteMembership(int id)
        {
            try
            {   
                var deleteMembership = _membershipService.DeleteMembership(id);
                return Ok(deleteMembership);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
