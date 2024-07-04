using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Services.Interfaces
{
    public interface IGymClassService
    {
        IEnumerable<GymClassConstDTO> GetAllGymClasses();
        IEnumerable<GymClass> GetGymClassesByInstructor(int id);
        string NewGymClass(NewGymClassDTO newGymClassDTO);
        string UpdateGymClass(UpdateGymClassDTO updateGymClassDTO);
        string DeleteGymClass(int id);
        string NewGymClassEquipment(AddGymClassEquipmentDTO addGymClassEquipmentDTO);
        string DeleteGymClassEquipment(DeleteGymClassEquipmentDTO deleteGymClassEquipmentDTO);
    }
}
