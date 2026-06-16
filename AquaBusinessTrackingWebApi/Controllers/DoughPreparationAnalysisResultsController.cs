using BusinessLayer.Abstract;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationDetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoughPreparationAnalysisResultsController : ControllerBase
    {

        private readonly IDoughPreparationAnalysisResultsDetailService _service;

        public DoughPreparationAnalysisResultsController(IDoughPreparationAnalysisResultsDetailService service)
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

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDoughPreparationAnalysisResultsDto doughPreparationDto)
        {
            doughPreparationDto.InsertDate = DateTime.Now;
            var result = await _service.Add(doughPreparationDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDoughPreparationAnalysisResultsDto updateDoughPreparationDto)
        {
            await _service.Update(updateDoughPreparationDto);
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
