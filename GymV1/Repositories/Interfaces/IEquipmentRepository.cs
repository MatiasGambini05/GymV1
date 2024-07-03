using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAllEquipment();
        Equipment GetEquipmentById(int id);
        IEnumerable<Equipment> GetEquipmentsById(List<int> id);
        void SaveE(Equipment equipment);
        void DeleteE(Equipment equipment);
    }
}
