using BusinessLayer.Abstract;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoughPreparationController : ControllerBase
    {
        private readonly IDoughPreparationHeadService _doughPreparationHeadService;

        public DoughPreparationController(IDoughPreparationHeadService doughPreparationHeadService)
        {
            _doughPreparationHeadService = doughPreparationHeadService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _doughPreparationHeadService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _doughPreparationHeadService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _doughPreparationHeadService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDoughPreparationDto doughPreparationDto)
        {

            doughPreparationDto.InsertDate = DateTime.Now;
            var result = await _doughPreparationHeadService.Add(doughPreparationDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDoughPreparationDto updateDoughPreparationDto)
        {
            updateDoughPreparationDto.UpdateDate = DateTime.Now;
            await _doughPreparationHeadService.Update(updateDoughPreparationDto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _doughPreparationHeadService.Delete(id);
            return Ok();
        }


    }
}
