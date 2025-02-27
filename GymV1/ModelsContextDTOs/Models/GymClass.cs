﻿namespace GymV1.ModelsContextDTOs.Models
{
    public class GymClass
    {
        public int GymClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime Schedule { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public ICollection<GymClassMembership> MembershipGymClasses { get; set; }
        public ICollection<GymclassEquipment> EquipmentGymClasses { get; set; }
    }
}
