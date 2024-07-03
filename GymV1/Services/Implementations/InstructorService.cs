using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;
using GymV1.Repositories.Interfaces;
using GymV1.Services.Interfaces;

namespace GymV1.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public IEnumerable<Instructor> GetAllinstructors()
        {
            return _instructorRepository.GetAllInstructors();
        }

        public string NewInstructor(NewInstructorDTO newInstructorDTO)
        {
            Instructor instructor = new Instructor
            {
                Name = newInstructorDTO.Name,
                Speciality = newInstructorDTO.Speciality
            };
            _instructorRepository.SaveI(instructor);

            return "Instructor creado correctamente.";
        }

        public string UpdateInstructor(UpdateInstructorDTO updateInstructorDTO)
        {
            var instructor = _instructorRepository.GetInstructorById(updateInstructorDTO.InstructorId);
            instructor.Name = updateInstructorDTO.Name;
            instructor.Speciality = updateInstructorDTO.Speciality;
            _instructorRepository.SaveI(instructor);

            return "Datos del instructor actualizados correctamente.";
        }

        public string DeleteInstructor(int id)
        {
            _instructorRepository.DeleteI(_instructorRepository.GetInstructorById(id));

            return "Instructor eliminado correctamente.";
        }
    }
}
