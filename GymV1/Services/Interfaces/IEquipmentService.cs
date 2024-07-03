using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Services.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<Equipment> GetAllEquipment();
        string NewEquipment(NewEquipmentDTO newEquipmentDTO);
        string UpdateEquipment(UpdateEquipmentDTO updateEquipmentDTO);
        string DeleteEquipment(int id);
    }
}
