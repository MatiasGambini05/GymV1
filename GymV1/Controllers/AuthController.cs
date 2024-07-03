using GymV1.ModelsContextDTOs.DTOs;
using GymV1.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] NewUserDTO newUserDTO)
        {
            var check = _authService.IsEmptyFieldSignup(newUserDTO);
            if (!check)
                return BadRequest("Faltan datos.");

            var newUser = _userService.NewUser(newUserDTO);

            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var check = _authService.LoginCheck(loginDTO);
                if (!check)
                    return BadRequest("El usuario no existe o la contraseña es incorrecta.");

                var login = await _authService.Login(loginDTO);
                if (login == null)
                    return BadRequest("Ocurrió un error al generar el token JWT.");

                return Ok(login);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Logout()
        {
            try
            {
                return Ok("Logout exitoso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
