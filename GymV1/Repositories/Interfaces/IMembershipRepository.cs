using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Repositories.Interfaces
{
    public interface IMembershipRepository
    {
        IEnumerable<Membership> GetAllMemberships();
        Membership GetMembershipById(int id);
        void SaveM (Membership membership);
        void DeleteM(Membership membership);
    }
}
