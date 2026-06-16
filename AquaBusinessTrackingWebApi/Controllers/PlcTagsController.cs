using BusinessLayer.Abstract;
using DTOLayer.Dtos.PlcDtos.PlcTagsDtos;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcTagsController : ControllerBase
    {
        private readonly IPlcTagsService _plcTagsService;
        private readonly IPlcMachineService _plcMachineService;

        public PlcTagsController(IPlcTagsService plcTagsService, IPlcMachineService plcMachineService)
        {
            _plcTagsService = plcTagsService;
            _plcMachineService = plcMachineService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreatePlcMachineTagsDto dto)
        {
            var result = await _plcTagsService.Add(dto);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet("getbymachineid/{machineId}")]
        public async Task<IActionResult> GetByMachineId(int machineId)
        {
            var result = await _plcMachineService.GetById(machineId);

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _plcTagsService.GetById(id);

            return Ok(result);
        }



        [HttpGet("details")]
        public async Task<IActionResult> GetByMachineName()
        {
            var result = await _plcTagsService.GetByMachineName();

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UpdatePlcMachineTagsDto dto)
        {
            await _plcTagsService.Update(dto);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plcTagsService.Delete(id);

            return Ok();
        }
    }
}
