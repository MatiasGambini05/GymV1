using GymV1.ModelsContextDTOs.DTOs;
using GymV1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IGymClassService _gymClassService;
        public InstructorController(IInstructorService instructorService, IGymClassService gymClassService)
        {
            _instructorService = instructorService;
            _gymClassService = gymClassService;
        }

        [HttpGet]
        public IActionResult GetAllInstructors()
        {
            try
            {
                var instructors = _instructorService.GetAllinstructors();
                if (instructors == null)
                    return BadRequest("No existen instructores.");

                return Ok(instructors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("/instructor/{id}")]
        public IActionResult GetGymClassesByInstructor(int id)
        {
            try
            {
                var gymClassesByInstructor = _gymClassService.GetGymClassesByInstructor(id);
                return Ok(gymClassesByInstructor);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult NewInstructor([FromBody] NewInstructorDTO newInstructorDTO)
        {
            try
            {
                var newInstructor = _instructorService.NewInstructor(newInstructorDTO);
                return Ok(newInstructor);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateInstructor([FromBody]UpdateInstructorDTO updateInstructorDTO)
        {
            try
            {
                var updateInstructor = _instructorService.UpdateInstructor(updateInstructorDTO);
                return Ok(updateInstructor);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteInstructor(int id)
        {
            try
            {
                var deleteInstructor = _instructorService.DeleteInstructor(id);
                return Ok(deleteInstructor);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
