using GymV1.ModelsContextDTOs.DTOs;
using GymV1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpPut]
        public IActionResult UpdatePassword([FromBody] NewPasswordDTO newPasswordDTO)
        {
            try
            {
                var clientEmail = User.FindFirst("Client") != null ? User.FindFirst("Client").Value : string.Empty;
                if (clientEmail == string.Empty)
                    return StatusCode(403);

                var updatePassword = _userService.UpdateUser(clientEmail, newPasswordDTO);
                return Ok(updatePassword);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var deleteUser = _userService.DeleteUser(id);
                return Ok(deleteUser);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
