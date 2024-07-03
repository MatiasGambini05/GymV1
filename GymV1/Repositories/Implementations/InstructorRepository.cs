using GymV1.ModelsContextDTOs.Context;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymV1.Repositories.Implementations
{
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
    {
        public InstructorRepository(GymContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return FindAll()
                .Include(gc => gc.GymClasses)
                .ToList();
        }

        public Instructor GetInstructorById(int id)
        {
            return FindByCondition(I => I.InstructorId == id)
                .Include(gc => gc.GymClasses)
                .FirstOrDefault();
        }

        public void SaveI(Instructor instructor)
        {
            if (instructor.InstructorId == 0)
                Create(instructor);
            else
                Update(instructor);

            SaveChanges();
            RepositoryContext.ChangeTracker.Clear();
        }

        public void DeleteI(Instructor instructor)
        {
            Delete(instructor);
            SaveChanges();
        }
    }
}
