using System.Collections.Generic;

namespace GymV1.ModelsContextDTOs.DTOs
{
    public class AddGymClassEquipmentDTO
    {
        public int GymClassId { get; set; }
        public List<EquipmentQuantityDTO> Equipments { get; set; }
    }
}
