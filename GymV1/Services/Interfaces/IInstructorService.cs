using GymV1.ModelsContextDTOs.DTOs;
using GymV1.ModelsContextDTOs.Models;

namespace GymV1.Services.Interfaces
{
    public interface IInstructorService
    {
        IEnumerable<Instructor> GetAllinstructors();
        string NewInstructor(NewInstructorDTO newInstructorDTO);
        string UpdateInstructor(UpdateInstructorDTO updateInstructorDTO);
        string DeleteInstructor(int id);
    }
}
