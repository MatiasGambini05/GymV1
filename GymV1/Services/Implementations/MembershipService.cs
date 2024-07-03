using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;
using GymV1.ModelsContextDTOs.Models.Enums;
using GymV1.Repositories.Interfaces;
using GymV1.Services.Interfaces;

namespace GymV1.Services.Implementations
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IUserRepository _userRepository;
        public MembershipService(IMembershipRepository membershipRepository, IUserRepository userRepository)
        {
            _membershipRepository = membershipRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return _membershipRepository.GetAllMemberships();
        }

        public CurrentMembershipDTO GetCurrentMembershipDTO(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            var membership = user.Memberships.FirstOrDefault();

            return new CurrentMembershipDTO
            {
                StartDate = membership.StartDate,
                EndDate = membership.EndDate,
                Type = membership.Type.ToString()
            };
        }

        public string NewMembership(NewMembershipDTO newMembershipDTO)
        {
            var user = _userRepository.GetUserById(newMembershipDTO.UserId);
            int months = newMembershipDTO.Months;
            var typeToInt = (MembershipType)Enum.Parse(typeof(MembershipType), newMembershipDTO.Type, true);

            Membership newMembership = new Membership
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(months),
                UserId = user.UserId,
                Type = typeToInt
            };
            _membershipRepository.SaveM(newMembership);

            return "Membresía creada correctamente.";
        }

        public string UpdateMembership(UpdateMembershipDTO updateMembershipDTO)
        {
            var user = _userRepository.GetUserById(updateMembershipDTO.UserId);
            var membership = user.Memberships.FirstOrDefault();
            var typeToInt = (MembershipType)Enum.Parse(typeof(MembershipType), updateMembershipDTO.Type, true);

            membership.EndDate = membership.EndDate.AddMonths(updateMembershipDTO.Months);
            membership.Type = typeToInt;
            _membershipRepository.SaveM(membership);

            return "Membresía actualizada correctamente.";
        }

        public string DeleteMembership(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return "No existe el usuario.";

            var membership = _membershipRepository.GetMembershipById(user.UserId);
            if (membership == null)
                return "No existe la membresía.";

            _membershipRepository.DeleteM(membership);
            return "Membresía borrada correctamente.";
        }
    }
}
