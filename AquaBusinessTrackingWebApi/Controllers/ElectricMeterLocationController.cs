using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElectricMeterLocationController : ControllerBase
    {
        private readonly IElectricMeterLocationService _service;

        public ElectricMeterLocationController(IElectricMeterLocationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _service.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _service.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateElectricMeterLocationDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _service.Add(dto);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UpdateElectricMeterLocationDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _service.Update(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
