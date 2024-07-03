using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        void SaveU(User user);
        void DeleteU(User user);
        User GetUserById(int id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
    }
}
