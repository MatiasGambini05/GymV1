namespace GymV1.ModelsContextDTOs.DTOs
{
    public class UpdateGymClassDTO
    {
        public int GymClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime Schedule { get; set; }
        public int InstructorId { get; set; }
    }
}
