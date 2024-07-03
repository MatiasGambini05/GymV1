using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        Task<User> NewUser(NewUserDTO newUserDTO);
        string UpdateUser(string email, NewPasswordDTO newPasswordDTO);
        string DeleteUser(int id);
    }
}
