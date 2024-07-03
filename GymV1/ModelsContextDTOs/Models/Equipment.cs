using GymV1.ModelsContextDTOs.Models.Enums;

namespace GymV1.ModelsContextDTOs.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public int Stock { get; set; }
        public ICollection<EquipmentGymClass> EquipmentGymClasses { get; set; }
    }
}
