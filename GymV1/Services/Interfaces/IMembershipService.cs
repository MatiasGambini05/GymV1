using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Services.Interfaces
{
    public interface IMembershipService
    {
        IEnumerable<Membership> GetAllMemberships();
        CurrentMembershipDTO GetCurrentMembershipDTO(string email);
        string NewMembership(NewMembershipDTO NewMembershipDTO);
        string UpdateMembership(UpdateMembershipDTO updateMembershipDTO);
        string DeleteMembership(int id);
    }
}
