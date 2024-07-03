using GymV1.ModelsContextDTOs.Context;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymV1.Repositories.Implementations
{
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        private readonly GymContext _gymContext;
        public EquipmentRepository(GymContext repositoryContext) : base(repositoryContext)
        {
            _gymContext = repositoryContext;
        }

        public IEnumerable<Equipment> GetAllEquipment()
        {
            return FindAll()
                .Include(egc => egc.EquipmentGymClasses)
                    .ThenInclude(gc => gc.GymClass)
                .ToList();
        }

        public Equipment GetEquipmentById(int id)
        {
            return FindByCondition(e => e.EquipmentId == id)
                .Include(egc => egc.EquipmentGymClasses)
                    .ThenInclude(gc => gc.GymClass)
                .FirstOrDefault();
        }

        public IEnumerable<Equipment> GetEquipmentsById(List<int> id)
        {
            return _gymContext.Equipments.Where(e => id.Contains(e.EquipmentId)).ToList();
        }

        public void SaveE(Equipment equipment)
        {
            if (equipment.EquipmentId == 0)
                Create(equipment);
            else
                Update(equipment);

            SaveChanges();
            RepositoryContext.ChangeTracker.Clear();
        }

        public void DeleteE(Equipment equipment)
        {
            Delete(equipment);
            SaveChanges();
        }
    }
}
