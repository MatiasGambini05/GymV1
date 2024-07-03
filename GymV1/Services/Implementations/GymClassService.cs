using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;
using GymV1.Services.Interfaces;
using NuGet.Packaging;

namespace GymV1.Services.Implementations
{
    public class GymClassService : IGymClassService
    {
        private readonly IGymClassRepository _gymClassRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        public GymClassService(IGymClassRepository gymClassRepository, IEquipmentRepository equipmentRepository)
        {
            _gymClassRepository = gymClassRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IEnumerable<GymClass> GetAllGymClasses()
        {
            return _gymClassRepository.GetAllGymClasses();
        }

        public IEnumerable<GymClass> GetGymClassesByInstructor(int id)
        {
            return _gymClassRepository.GetGymClassesByInstructor(id);
        }

        public string NewGymClass(NewGymClassDTO newGymClassDTO)
        {
            GymClass newGymClass = new GymClass
            {
                ClassName = newGymClassDTO.ClassName,
                Schedule = newGymClassDTO.Schedule,
                InstructorId = newGymClassDTO.InstructorId
            };
            _gymClassRepository.SaveGC(newGymClass);

            return "Clase creada correctamente.";
        }

        public string UpdateGymClass(UpdateGymClassDTO updateGymClassDTO)
        {
            var gymClass = _gymClassRepository.GetGymClassById(updateGymClassDTO.GymClassId);
            gymClass.ClassName = updateGymClassDTO.ClassName;
            gymClass.Schedule = updateGymClassDTO.Schedule;
            gymClass.InstructorId = updateGymClassDTO.InstructorId;
            _gymClassRepository.SaveGC(gymClass);

            return "Clase actualizada correctamente.";
        }

        public string DeleteGymClass(int id)
        {
            _gymClassRepository.DeleteGC(_gymClassRepository.GetGymClassById(id));

            return "Clase eliminada correctamente.";
        }

        public string NewGymClassEquipment(AddGymClassEquipmentDTO gymClassEquipmentDTO)
        {
            var gymClass = _gymClassRepository.GetGymClassById(gymClassEquipmentDTO.GymClassId);
            var equipmentIds = gymClassEquipmentDTO.Equipments.Select(eq => eq.EquipmentId).ToList();
            var equipments = _equipmentRepository.GetEquipmentsById(equipmentIds);

            var equipmentGymClasses = gymClassEquipmentDTO.Equipments.Select(equipmentId => new EquipmentGymClass
            {
                GymClassId = gymClassEquipmentDTO.GymClassId,
                EquipmentId = equipmentId.EquipmentId,
                Quantity = equipmentId.Quantity
            }).ToList();

            gymClass.EquipmentGymClasses.AddRange(equipmentGymClasses);
            _gymClassRepository.SaveGC(gymClass);

            return "Equipamiento para la clase agregado correctamente.";
        }

        public string DeleteEquipment(DeleteGymClassEquipmentDTO deleteGymClassEquipmentDTO)
        {
            var gymClass = _gymClassRepository.GetGymClassById(deleteGymClassEquipmentDTO.GymClassId);
            var equipmentGymClass = gymClass.EquipmentGymClasses
            .FirstOrDefault(egc => egc.EquipmentId == deleteGymClassEquipmentDTO.EquipmentId);

            gymClass.EquipmentGymClasses.Remove(equipmentGymClass);
            _gymClassRepository.SaveGC(gymClass);

            return "Equipamiento para la clase eliminado correctamente.";
        }
    }
}
