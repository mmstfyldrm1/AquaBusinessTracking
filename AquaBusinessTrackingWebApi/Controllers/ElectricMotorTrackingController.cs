using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElectricMotorTrackingController : ControllerBase
    {
        private readonly IElectricMotorTrackingService _electricMotorTrackingService;

        public ElectricMotorTrackingController(IElectricMotorTrackingService electricMotorTrackingService)
        {
            _electricMotorTrackingService = electricMotorTrackingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _electricMotorTrackingService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _electricMotorTrackingService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _electricMotorTrackingService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateElectricMotorDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _electricMotorTrackingService.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateElectricMotorDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _electricMotorTrackingService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _electricMotorTrackingService.Delete(id);
            return Ok();
        }
    }
}
