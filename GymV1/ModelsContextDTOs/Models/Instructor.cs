namespace GymV1.ModelsContextDTOs.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public ICollection<GymClass> GymClasses { get; set; }
        public Instructor()
        {
            GymClasses = new List<GymClass>();
        }
    }
}
