using BusinessLayer.Abstract;
using DTOLayer.Dtos.MassWasteDtos.MassWasteBalanceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MassWasteBalanceController : ControllerBase
    {
        private readonly IMassWasteBalanceService _service;

        public MassWasteBalanceController(IMassWasteBalanceService service)
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
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateMassWasteBalanceDto dto)
        {
            dto.InsertDate = DateTime.Now;
            var result = await _service.Add(dto);
            return Ok(result);

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateMassWasteBalanceDto dto)
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
