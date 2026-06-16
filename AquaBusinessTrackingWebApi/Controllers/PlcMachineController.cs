using BusinessLayer.Abstract;
using DTOLayer.Dtos.PlcDtos.PlcMachineDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlcMachineController : ControllerBase
    {
        private readonly IPlcMachineService _plcMachineService;
        private readonly IPlcTagsService _plcTagsService;

        public PlcMachineController(IPlcMachineService plcMachineService, IPlcTagsService plcTagsService)
        {
            _plcMachineService = plcMachineService;
            _plcTagsService = plcTagsService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _plcMachineService.GetList();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreatePlcMachineDto createPlcMachineDto)
        {
            var result = await _plcMachineService.Add(createPlcMachineDto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdatePlcMachineDto updatePlcMachineDto)
        {
            await _plcMachineService.Update(updatePlcMachineDto);
            return Ok();

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plcMachineService.Delete(id);
            return Ok();
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _plcMachineService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
