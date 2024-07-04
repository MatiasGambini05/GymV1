using GymV1.ModelsContextDTOs.Models;

namespace GymV1.ModelsContextDTOs.DTOs
{
    public class GymClassConstDTO
    {
        public string ClassName { get; set; }
        public DateTime Schedule { get; set; }
        public int InstructorId { get; set; }
        public ICollection<EquipmentConstDTO> Equipments { get; set; }
        public ICollection<MembershipConstDTO> Memberships { get; set; }

        public GymClassConstDTO(GymClass gymClass)
        {
            ClassName = gymClass.ClassName;
            Schedule = gymClass.Schedule;
            InstructorId = gymClass.InstructorId;
            Equipments = gymClass.EquipmentGymClasses.Select(egc => new EquipmentConstDTO(egc.Equipment)).ToList();
            Memberships = gymClass.MembershipGymClasses.Select(mgc => new MembershipConstDTO(mgc.Membership)).ToList();
        }
    }
}
