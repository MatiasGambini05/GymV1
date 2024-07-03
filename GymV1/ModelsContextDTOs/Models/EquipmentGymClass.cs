namespace GymV1.ModelsContextDTOs.Models
{
    public class EquipmentGymClass
    {
        public int EquipmentGymClassId { get; set; }
        public Equipment Equipment { get; set; }
        public int EquipmentId { get; set; }
        public GymClass GymClass { get; set; }
        public int GymClassId { get; set; }
        public int Quantity { get; set; }
    }
}
