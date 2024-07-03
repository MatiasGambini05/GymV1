using GymV1.ModelsContextDTOs.Context;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymV1.Repositories.Implementations
{
    public class MembershipRepository : RepositoryBase<Membership>, IMembershipRepository
    {
        public MembershipRepository(GymContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return FindAll()
                .Include(me => me.MembershipGymClasses)
                .ThenInclude(gc => gc.GymClass)
                .ToList();
        }

        public Membership GetMembershipById(int id)
        {
            return FindByCondition(me => me.MembershipId == id)
                .Include(me => me.MembershipGymClasses)
                .ThenInclude(gc => gc.GymClass)
                .FirstOrDefault();
        }

        public void SaveM(Membership membership)
        {
            if(membership.UserId == 0)
                Create(membership);
            else
                Update(membership);

            SaveChanges();
            RepositoryContext.ChangeTracker.Clear();
        }

        public void DeleteM(Membership membership)
        {
            Delete(membership);
            SaveChanges();
        }
    }
}
