using GymV1.ModelsContextDTOs.Context;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymV1.Repositories.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(GymContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .Include(us => us.Memberships)
                .Include(us => us.Subscriptions)
                .ToList();
        }

        public User GetUserById(int id) //Cuidado con .FirstOrDefault
        {
            return FindByCondition(us => us.UserId == id)
                .Include(us => us.Memberships)
                .Include(us => us.Subscriptions)
                .FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return FindByCondition(us => us.Email.ToUpper() == email.ToUpper())
                .Include(us => us.Memberships)
                .Include(us => us.Subscriptions)
                .FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return FindByCondition(us => us.Username.ToUpper() == username.ToUpper())
                .Include(us => us.Memberships)
                .Include(us => us.Subscriptions)
                .FirstOrDefault();
        }

        public void SaveU(User user)
        {
            if (user.UserId == 0)
                Create(user);
            else
                Update(user);

            SaveChanges();
            RepositoryContext.ChangeTracker.Clear();
        }

        public void DeleteU(User user)
        {
            Delete(user);
            SaveChanges();
        }
    }
}
