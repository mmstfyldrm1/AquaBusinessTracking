using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ElectiricShiftWorkController : ControllerBase
    {
        private readonly IElectiricShiftWorkService _electricShiftWorkService;

        public ElectiricShiftWorkController(IElectiricShiftWorkService electricShiftWorkService)
        {
            _electricShiftWorkService = electricShiftWorkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _electricShiftWorkService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _electricShiftWorkService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _electricShiftWorkService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateElectricShiftWorkDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _electricShiftWorkService.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateElectiricShiftWorkDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _electricShiftWorkService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _electricShiftWorkService.Delete(id);
            return Ok();
        }


    }
}
