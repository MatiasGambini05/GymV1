using GymV1.ModelsContextDTOs.Context;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymV1.Repositories.Implementations
{
    public class GymClassRepository : RepositoryBase<GymClass>, IGymClassRepository
    {
        public GymClassRepository(GymContext repositoryContext) : base (repositoryContext)
        {
        }

        public IEnumerable<GymClass> GetAllGymClasses()
        {
            return FindAll()
                .Include(mgc => mgc.MembershipGymClasses)
                    .ThenInclude(m => m.Membership)
                .Include(egc => egc.EquipmentGymClasses)
                    .ThenInclude(e => e.Equipment)
                .ToList();
        }

        public GymClass GetGymClassById(int id)
        {
            return FindByCondition(gc => gc.GymClassId == id)
                .Include(mgc => mgc.MembershipGymClasses)
                    .ThenInclude(m => m.Membership)
                .Include(egc => egc.EquipmentGymClasses)
                    .ThenInclude(e => e.Equipment)
                .FirstOrDefault();
        }

        public IEnumerable<GymClass> GetGymClassesByInstructor(int id)
        {
            return FindByCondition(gc => gc.InstructorId == id)
                .Include(mgc => mgc.MembershipGymClasses)
                    .ThenInclude(m => m.Membership)
                .Include(egc => egc.EquipmentGymClasses)
                    .ThenInclude(e => e.Equipment)
                .ToList();
        }

        public void SaveGC(GymClass gymClass)
        {
            if (gymClass.GymClassId == 0)
                Create(gymClass);
            else
                Update(gymClass);

            SaveChanges();
            RepositoryContext.ChangeTracker.Clear();
        }

        public void DeleteGC(GymClass gymClass)
        {
            Delete(gymClass);
            SaveChanges();
        }
    }
}
