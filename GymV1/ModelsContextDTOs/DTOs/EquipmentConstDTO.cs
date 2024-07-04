using GymV1.ModelsContextDTOs.Models;
using GymV1.ModelsContextDTOs.Models.Enums;

namespace GymV1.ModelsContextDTOs.DTOs
{
    public class EquipmentConstDTO
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }

        public EquipmentConstDTO(Equipment equipment)
        {
            EquipmentId = equipment.EquipmentId;
            Name = equipment.Name;
            Type = equipment.Type.ToString();
            Stock = equipment.Stock;
        }
    }
}
