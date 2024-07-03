using GymV1.ModelsContextDTOs.DTOs;
using GymV1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public IActionResult GetAllEquipment()
        {
            try
            {
                var allEquipment = _equipmentService.GetAllEquipment();
                return Ok(allEquipment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult NewEquipment(NewEquipmentDTO newEquipmentDTO)
        {
            try
            {
                var newEquipment = _equipmentService.NewEquipment(newEquipmentDTO);
                return Ok(newEquipment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateEquipment(UpdateEquipmentDTO updateEquipmentDTO)
        {
            try
            {
                var updateEquipment = _equipmentService.UpdateEquipment(updateEquipmentDTO);
                return Ok(updateEquipment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteEquipment(int id)
        {
            try
            {
                var deleteEquipment = _equipmentService.DeleteEquipment(id);
                return Ok(deleteEquipment);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
