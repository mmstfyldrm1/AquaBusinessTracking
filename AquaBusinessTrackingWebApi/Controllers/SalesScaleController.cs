using BusinessLayer.Abstract;
using DTOLayer.Dtos.SalesScale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesScaleController : ControllerBase
    {
        private readonly ISalesScaleService _salesScaleService;

        public SalesScaleController(ISalesScaleService salesScaleService)
        {
            _salesScaleService = salesScaleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _salesScaleService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _salesScaleService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _salesScaleService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSalesScaleDto dto)
        {
            dto.InsertDate = DateTime.Now;
            dto.ScaleDate = DateTime.Now;
            await _salesScaleService.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateSalesScaleDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _salesScaleService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _salesScaleService.Delete(id);
            return Ok();
        }
    }
}
