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
        private readonly ILogger<PlcMachineController> _logger;

        public PlcMachineController(
            IPlcMachineService plcMachineService,
            IPlcTagsService plcTagsService,
            ILogger<PlcMachineController> logger)
        {
            _plcMachineService = plcMachineService;
            _plcTagsService = plcTagsService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "PLC makine listesi istendi. User={User}",
                User?.Identity?.Name);

            try
            {
                var result = await _plcMachineService.GetList();

                if (result.Count > 0)
                {
                    _logger.LogInformation(
                        "{Count} adet PLC makinesi getirildi.",
                        result.Count);

                    return Ok(result);
                }

                _logger.LogWarning(
                    "PLC makine listesi boş döndü.");

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "PLC makine listesi alınırken hata oluştu.");

                return StatusCode(500, "PLC makine listesi alınamadı.");
            }
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreatePlcMachineDto createPlcMachineDto)
        {
            _logger.LogInformation(
                "Yeni PLC makinesi ekleniyor. MachineName={Name}, User={User}",
                createPlcMachineDto.Name,
                User?.Identity?.Name);

            try
            {
                var result = await _plcMachineService.Add(createPlcMachineDto);

                if (result != null)
                {
                    _logger.LogInformation(
                        "PLC makinesi başarıyla eklendi. MachineName={Name}",
                        createPlcMachineDto.Name);

                    return Ok(result);
                }

                _logger.LogWarning(
                    "PLC makinesi eklenemedi. MachineName={Name}",
                    createPlcMachineDto.Name);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "PLC makinesi eklenirken hata oluştu. MachineName={Name}",
                    createPlcMachineDto.Name);

                return StatusCode(500, "PLC makinesi eklenemedi.");
            }
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdatePlcMachineDto updatePlcMachineDto)
        {
            _logger.LogInformation(
                "PLC makinesi güncelleniyor. Id={Id}",
                id);

            try
            {
                updatePlcMachineDto.RecId = id;

                await _plcMachineService.Update(updatePlcMachineDto);

                _logger.LogInformation(
                    "PLC makinesi güncellendi. Id={Id}",
                    id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "PLC makinesi güncellenirken hata oluştu. Id={Id}",
                    id);

                return StatusCode(500, "PLC makinesi güncellenemedi.");
            }
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "PLC makinesi siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            try
            {
                await _plcMachineService.Delete(id);

                _logger.LogWarning(
                    "PLC makinesi silindi. Id={Id}",
                    id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "PLC makinesi silinirken hata oluştu. Id={Id}",
                    id);

                return StatusCode(500, "PLC makinesi silinemedi.");
            }
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "PLC makinesi getiriliyor. Id={Id}",
                id);

            try
            {
                var result = await _plcMachineService.GetById(id);

                if (result != null)
                {
                    _logger.LogInformation(
                        "PLC makinesi bulundu. Id={Id}",
                        id);

                    return Ok(result);
                }

                _logger.LogWarning(
                    "PLC makinesi bulunamadı. Id={Id}",
                    id);

                return NotFound(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "PLC makinesi alınırken hata oluştu. Id={Id}",
                    id);

                return StatusCode(500, "PLC makinesi bulunamadı.");
            }
        }
    }
}