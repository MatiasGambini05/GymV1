using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;
using GymV1.ModelsContextDTOs.Models.Enums;
using GymV1.Repositories.Interfaces;
using GymV1.Services.Interfaces;

namespace GymV1.Services.Implementations
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public IEnumerable<Equipment> GetAllEquipment()
        {
            return _equipmentRepository.GetAllEquipment();
        }

        public string NewEquipment(NewEquipmentDTO newEquipmentDTO)
        {
            var typeToInt = (EquipmentType)Enum.Parse(typeof(EquipmentType), newEquipmentDTO.Type, true);
            Equipment newEquipment = new Equipment
            {
                Name = newEquipmentDTO.Name,
                Type = typeToInt,
                Stock = newEquipmentDTO.Quantity
            };
            _equipmentRepository.SaveE(newEquipment);

            return "Equipamiento creado correctamente.";
        }

        public string UpdateEquipment(UpdateEquipmentDTO updateEquipmentDTO)
        {
            var equipment = _equipmentRepository.GetEquipmentById(updateEquipmentDTO.EquipmentId);
            var typeToInt = (EquipmentType)Enum.Parse(typeof(EquipmentType), updateEquipmentDTO.Type, true);
            equipment.Name = updateEquipmentDTO.Name;
            equipment.Type = typeToInt;
            equipment.Stock = equipment.Stock + updateEquipmentDTO.Quantity;
            _equipmentRepository.SaveE(equipment);

            return "Equipo actualizado correctamente.";
        }

        public string DeleteEquipment(int id)
        {
            _equipmentRepository.DeleteE(_equipmentRepository.GetEquipmentById(id));

            return "Equipo eliminado correctamente.";
        }
    }
}
