using BusinessLayer.Abstract;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasinController : ControllerBase
    {
        private readonly IBasinService _basinService;
        private readonly IBasinMeasurementService _measurementService;

        public BasinController(IBasinService basinService, IBasinMeasurementService measurementService)
        {
            _basinService = basinService;
            _measurementService = measurementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _basinService.GetList());

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            var result = await _basinService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _basinService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBasinDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _basinService.Add(dto);

            var all = await _basinService.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            return Ok(last);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasinDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _basinService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _basinService.Delete(id);
            return Ok();
        }


        [HttpGet("{basinId}/measurements")]
        public async Task<IActionResult> GetMeasurements(int basinId)
        {
            var all = await _measurementService.GetList();
            var result = all.Where(x => x.BasinId == basinId).ToList();
            return Ok(result);
        }

        [HttpPost("{basinId}/measurement")]
        public async Task<IActionResult> AddMeasurement(int basinId, [FromBody] CreateBasinMeasurementDto dto)
        {
            dto.BasinId = basinId;
            await _measurementService.Add(dto);
            return Ok();
        }

        [HttpPut("{basinId}/measurement")]
        public async Task<IActionResult> UpdateMeasurement(int basinId, [FromBody] UpdateBasinMeasurementDto dto)
        {
            await _measurementService.Update(dto);
            return Ok();
        }

        [HttpDelete("{basinId}/measurement/{measurementId}")]
        public async Task<IActionResult> DeleteMeasurement(int basinId, int measurementId)
        {
            await _measurementService.Delete(measurementId);
            return Ok();
        }
    }
}


