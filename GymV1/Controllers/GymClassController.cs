using GymV1.ModelsContextDTOs.DTOs;
using GymV1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymClassController : ControllerBase
    {
        private readonly IGymClassService _gymClassService;
        public GymClassController(IGymClassService gymClassService)
        {
            _gymClassService = gymClassService;
        }

        [HttpGet]
        public IActionResult GetAllGymClasses()
        {
            try
            {
                var allGymClasses = _gymClassService.GetAllGymClasses();
                return Ok(allGymClasses);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult NewGymClass([FromBody] NewGymClassDTO newGymClassDTO)
        {
            try
            {
                var newGymClass = _gymClassService.NewGymClass(newGymClassDTO);
                return Ok(newGymClass);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Equipment")]
        public IActionResult NewGymClassEquipment([FromBody] AddGymClassEquipmentDTO addGymClassEquipmentDTO)
        {
            try
            {
                var newGymClassEquipment = _gymClassService.NewGymClassEquipment(addGymClassEquipmentDTO);
                return Ok(newGymClassEquipment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateGymClass([FromBody] UpdateGymClassDTO updateGymClassDTO)
        {
            try
            {
                var updateGymClass = _gymClassService.UpdateGymClass(updateGymClassDTO);
                return Ok(updateGymClass);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteGymClass(int id)
        {
            try
            {
                var deleteGymClass = _gymClassService.DeleteGymClass(id);
                return Ok(deleteGymClass);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("Equipment")]
        public IActionResult DeleteGymClassEquipment([FromBody]DeleteGymClassEquipmentDTO deleteGymClassEquipmentDTO)
        {
            try
            {
                var deleteGymClassEquipment = _gymClassService.DeleteGymClassEquipment(deleteGymClassEquipmentDTO);
                return Ok(deleteGymClassEquipment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
