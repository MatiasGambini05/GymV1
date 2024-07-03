using GymV1.ModelsContextDTOs.DTOs;
using GymV1.Services.Interfaces;
using GymV1.Repositories.Interfaces;
using System.Security.Claims;
using GymV1.ModelsContextDTOs.Models;
using GymV1.ModelsContextDTOs.Context;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GymV1.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly GymContext _gymContext;
        private readonly JwtSettings _jwtSettings;
        public AuthService(IUserRepository userRepository, GymContext gymContext, JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _gymContext = gymContext;
            _jwtSettings = jwtSettings;
        }

        public bool IsEmptyFieldSignup(NewUserDTO newUserDTO)
        {
            if (newUserDTO.Username.IsNullOrEmpty() || newUserDTO.Password.IsNullOrEmpty() || newUserDTO.Password.IsNullOrEmpty())
                return false;

            return true;
        }

        public bool LoginCheck(LoginDTO loginDTO)
        {
            User user = _userRepository.GetUserByUsername(loginDTO.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
                return false;

            return true;
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim ("Client", user.Email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<AuthResponseDTO> Login(LoginDTO loginDTO)
        {
            User user = _userRepository.GetUserByUsername(loginDTO.Username);

            string token = await GenerateJwtToken(user);

            return (new AuthResponseDTO
            {
                Username = user.Username,
                Token = token
            });
        }
    }
}
