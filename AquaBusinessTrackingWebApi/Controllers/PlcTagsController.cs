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
        private readonly ILogger<PlcTagsController> _logger;

        public PlcTagsController(
            IPlcTagsService plcTagsService,
            IPlcMachineService plcMachineService,
            ILogger<PlcTagsController> logger)
        {
            _plcTagsService = plcTagsService;
            _plcMachineService = plcMachineService;
            _logger = logger;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(CreatePlcMachineTagsDto dto)
        {
            try
            {
                _logger.LogInformation("PLC Tag ekleme işlemi başladı. MachineId: {MachineId}", dto.MachineId);

                var result = await _plcTagsService.Add(dto);

                if (result == null)
                {
                    _logger.LogWarning("PLC Tag eklenemedi. DTO: {@Dto}", dto);
                    return BadRequest();
                }

                _logger.LogInformation("PLC Tag başarıyla eklendi. Result: {@Result}", result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PLC Tag ekleme sırasında hata oluştu. DTO: {@Dto}", dto);
                return StatusCode(500, "Sunucu hatası oluştu.");
            }
        }


        [HttpGet("getbymachineid/{machineId}")]
        public async Task<IActionResult> GetByMachineId(int machineId)
        {
            try
            {
                _logger.LogInformation("Makine tagleri getiriliyor. MachineId: {MachineId}", machineId);

                var result = await _plcMachineService.GetById(machineId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Makine tagleri getirilirken hata oluştu. MachineId: {MachineId}", machineId);
                return StatusCode(500);
            }
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("PLC Tag getiriliyor. Id: {Id}", id);

                var result = await _plcTagsService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PLC Tag getirme hatası. Id: {Id}", id);
                return StatusCode(500);
            }
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetByMachineName()
        {
            try
            {
                _logger.LogInformation("PLC Tag detayları getiriliyor.");

                var result = await _plcTagsService.GetByMachineName();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PLC Tag detayları getirilirken hata oluştu.");
                return StatusCode(500);
            }
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UpdatePlcMachineTagsDto dto)
        {
            try
            {
                _logger.LogInformation("PLC Tag güncelleme başladı. DTO: {@Dto}", dto);

                await _plcTagsService.Update(dto);

                _logger.LogInformation("PLC Tag güncellendi.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PLC Tag güncelleme hatası. DTO: {@Dto}", dto);
                return StatusCode(500);
            }
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("PLC Tag silme işlemi başladı. Id: {Id}", id);

                await _plcTagsService.Delete(id);

                _logger.LogInformation("PLC Tag silindi. Id: {Id}", id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PLC Tag silme hatası. Id: {Id}", id);
                return StatusCode(500);
            }
        }
    }
}