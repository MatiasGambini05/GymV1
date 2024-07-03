using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetInstructorById(int id);
        void SaveI(Instructor instructor);
        void DeleteI(Instructor instructor);
    }
}
