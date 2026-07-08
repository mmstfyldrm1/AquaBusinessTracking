using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CumulativeElectricityConsumptionController : ControllerBase
    {
        private readonly ICumulativeElectricityConsumptionService _service;

        public CumulativeElectricityConsumptionController(ICumulativeElectricityConsumptionService service)
        {
            _service = service;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
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

        [HttpGet("location")]
        public async Task<IActionResult> GetLocationName()
        {
            var result = await _service.GetLocationName();
            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCumulativeElectricityConsumptionDto dto)
        {
            dto.InsertDate = DateTime.Now;
            var result = await _service.Add(dto);
            return Ok(result);

        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UpdateCumulativeElectricityConsumptionDto dto)
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
