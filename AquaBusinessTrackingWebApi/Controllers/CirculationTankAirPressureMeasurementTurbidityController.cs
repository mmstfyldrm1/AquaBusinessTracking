using BusinessLayer.Abstract;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CirculationTankAirPressureMeasurementTurbidityController : ControllerBase
    {
        private readonly ICirculationTankAirPressureMeasurementTurbidityService _circulationTurbidityService;

        public CirculationTankAirPressureMeasurementTurbidityController(ICirculationTankAirPressureMeasurementTurbidityService circulationTurbidityService)
        {
            _circulationTurbidityService = circulationTurbidityService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _circulationTurbidityService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _circulationTurbidityService.GetWithDetails();
            return Ok(result);
        }


        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _circulationTurbidityService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCirculationTankAirPressureMeasurementTurbidityDto dto)
        {
            dto.InsertDate = DateTime.Now;
            var result = await _circulationTurbidityService.Add(dto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCirculationTankAirPressureMeasurementTurbidityDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _circulationTurbidityService.Update(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _circulationTurbidityService.Delete(id);
            return Ok();
        }


    }
}
