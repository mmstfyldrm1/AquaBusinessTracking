using BusinessLayer.Abstract;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoilerSteamFeedWaterCondensateDataController : ControllerBase
    {
        private readonly IBoilerSteamFeedWaterCondensateDataService _boilerSteamFeedWaterCondensateDataService;

        public BoilerSteamFeedWaterCondensateDataController(IBoilerSteamFeedWaterCondensateDataService boilerSteamFeedWaterCondensateDataService)
        {
            _boilerSteamFeedWaterCondensateDataService = boilerSteamFeedWaterCondensateDataService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _boilerSteamFeedWaterCondensateDataService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _boilerSteamFeedWaterCondensateDataService.GetWithDetails();
            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _boilerSteamFeedWaterCondensateDataService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBoilerSteamFeedWaterCondensateDataDto dto)
        {
            dto.InsertDate = DateTime.Now;
            var result = await _boilerSteamFeedWaterCondensateDataService.Add(dto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBoilerSteamFeedWaterCondensateDataDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _boilerSteamFeedWaterCondensateDataService.Update(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _boilerSteamFeedWaterCondensateDataService.Delete(id);
            return Ok();
        }



    }
}
