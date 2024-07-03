using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Repositories.Interfaces
{
    public interface IGymClassRepository
    {
        IEnumerable<GymClass> GetAllGymClasses();
        GymClass GetGymClassById(int id);
        IEnumerable<GymClass> GetGymClassesByInstructor(int id);
        void SaveGC(GymClass gymClass);
        void DeleteGC(GymClass gymClass);
    }
}
