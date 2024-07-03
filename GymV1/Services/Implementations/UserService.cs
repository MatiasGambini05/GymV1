using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;
using GymV1.ModelsContextDTOs.Models.Enums;
using GymV1.Repositories.Interfaces;
using GymV1.Services.Interfaces;

namespace GymV1.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Task<User> NewUser(NewUserDTO newUserDTO)
        {
            int roleValue = newUserDTO.Email.Contains("@gymadmin.com") ? 0 : 1;
            UserRole role = (UserRole)roleValue;

            User user = new User
            {
                Username = newUserDTO.Username,
                Email = newUserDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(newUserDTO.Password),
                Role = role
            };
            _userRepository.SaveU(user);

            return Task.FromResult(user);
        }

        public string UpdateUser(string email, NewPasswordDTO newPasswordDTO)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
                return "No existe el usuario.";

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPasswordDTO.Password);
            _userRepository.SaveU(user);
            return "Contraseña actualizada correctamente.";
        }

        public string DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return "No existe el usuario.";
            
            _userRepository.DeleteU(user);
            return "Usuario borrado correctamente.";
        }
    }
}
