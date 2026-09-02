using AquaBusinessTrackingWebApi.Services;
using BusinessLayer.Abstract;
using DTOLayer.Dtos.NotificationDtos;
using DTOLayer.Dtos.PapperMachineChemicalDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PapperMachineChemicalController : ControllerBase
    {
        private readonly IPapperMachineChemicalService _service;
        private readonly ILogger<PapperMachineChemicalController> _logger;
        private readonly ISentezInventoryQueryService _sentez;
        private readonly INotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _hub;

        public PapperMachineChemicalController(IPapperMachineChemicalService service, ILogger<PapperMachineChemicalController> logger, ISentezInventoryQueryService sentez, INotificationService notificationService, IHubContext<NotificationHub> hub)
        {
            _service = service;
            _logger = logger;
            _sentez = sentez;
            _notificationService = notificationService;
            _hub = hub;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Kağıt Makinesi Kimyasal listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet Kağıt Makinesi Kimyasal kaydı getirildi.",
                result.Count());

            return Ok(result);
        }



        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Kağıt Makinesi Kimyasal detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getChemicalInventoryList")]
        public async Task<IActionResult> GetInventoryList()
        {
            _logger.LogInformation("Kimyasal Malzemeleri istendi. User={User}", User?.Identity?.Name);
            var result = await _sentez.GetChemicalInventory();
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWithSearchDetails([FromQuery] DateTime StartDate, [FromQuery] DateTime EndDate)
        {
            _logger.LogInformation(
                "Elektrik Detay Sayfası {StartDate} - {EndDate} istendi.",
                StartDate,
                EndDate);


            var result = await _service.GetWithSearchDetails(StartDate, EndDate);

            _logger.LogInformation(
              "Elektrik Detay Sayfası {StartDate} - {EndDate} başarıyla getirildi.",
              StartDate,
              EndDate);


            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Kağıt Makinesi Kimyasal kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Kağıt Makinesi Kimyasal kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Kağıt Makinesi Kimyasal kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatePapperMachineChemicalDto dto)
        {

            _logger.LogInformation("Yeni Kağıt Makinesi Kimyasal kaydı ekleniyor. User={User}", User?.Identity?.Name); dto.InsertDate = DateTime.Now;
            var result = await _service.Add(dto);

            _logger.LogInformation("Kağıt Makinesi Kimyasal kaydı başarıyla eklendi.");

            var notifDto = new CreateNotificationDto
            {
                UserId = 5,
                Title = "Yeni Kimyasal Girişi",
                Message = $"{dto.InventoryName} malzemesi  için  {dto.IncomingQuantity} gelen {dto.ConsumedQuantity} sarf ve stok {dto.CurrentStock} ",
                Url = "/PapperMachineChemical/GetPapperMachineChemicalList",
                Icon = "cube-outline",
                Color = "warning",
                IsRead = false
            };

            var savedNotif = await _notificationService.SendAsync(notifDto);
            await _hub.Clients.Group($"user-{notifDto.UserId}")
                .SendAsync("ReceiveNotification", savedNotif);

            return Ok(result);


        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdatePapperMachineChemicalDto dto)
        {
            _logger.LogInformation(
                "Kağıt Makinesi Kimyasal kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Kağıt Makinesi Kimyasal kaydı güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Kağıt Makinesi Kimyasal kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Kağıt Makinesi Kimyasal kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}