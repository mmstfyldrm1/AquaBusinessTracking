using BusinessLayer.Abstract;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoilerOperationandChemicalConsumptionController : ControllerBase
    {
        private readonly IBoilerOperationandChemicalConsumptionService _service;
        private readonly ILogger<BoilerOperationandChemicalConsumptionController> _logger;

        public BoilerOperationandChemicalConsumptionController(
            IBoilerOperationandChemicalConsumptionService service,
            ILogger<BoilerOperationandChemicalConsumptionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Kazan Dairesi Vardiya Takip listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet kayıt getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Kazan Dairesi Vardiya Takip detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("kazanEnergyStatus")]
        public async Task<IActionResult> GetActiveKazanLocation()
        {
            _logger.LogInformation(
                "Kazan Dairesi Vardiya Takip detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetActiveShiftEnergyStatus();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWithSearchDetails([FromQuery] DateTime StartDate, [FromQuery] DateTime EndDate)
        {
            _logger.LogInformation(
                "Doğalgaz Tüketim  Detay Sayfası {StartDate} - {EndDate} istendi.",
                StartDate,
                EndDate);


            var result = await _service.GetWithSearchDetails(StartDate, EndDate);

            _logger.LogInformation(
              "Doğalgaz Tüketim  Detay  Sayfası {StartDate} - {EndDate} başarıyla getirildi.",
              StartDate,
              EndDate);


            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Kazan Dairesi Vardiya Takip kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBoilerOperationandChemicalConsumptionDto dto)
        {
            _logger.LogInformation(
                "Yeni Kazan Dairesi Vardiya Takip kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Kazan Dairesi Vardiya Takip kaydı başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UpdateBoilerOperationandChemicalConsumptionDto dto)
        {
            _logger.LogInformation(
                "Kazan Dairesi Vardiya Takip kaydı güncelleniyor. Id={Id}",
                dto.RecId);

            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Kazan Dairesi Vardiya Takip kaydı güncellendi. Id={Id}",
                dto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Kazan Dairesi Vardiya Takip kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Kazan Dairesi Vardiya Takip kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}