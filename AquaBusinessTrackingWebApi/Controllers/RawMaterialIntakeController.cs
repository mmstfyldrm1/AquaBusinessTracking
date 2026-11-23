using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.Dtos.RawMaterialIntakesDtos;
using DTOLayer.Dtos.RawMaterialIntakesDtos.EsitIntegrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RawMaterialIntakeController : ControllerBase
    {
        private readonly IRawMaterialIntakeService _service;
        private readonly ILogger<RawMaterialIntakeController> _logger;
        private readonly ISentezCurrentAccountQueryService _sentezCurrentAccountQueryService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public RawMaterialIntakeController(IRawMaterialIntakeService rawMaterialIntakeService, ILogger<RawMaterialIntakeController> logger, ISentezCurrentAccountQueryService sentezCurrentAccountQueryService, IConfiguration configuration, IMapper mapper)
        {
            _service = rawMaterialIntakeService;
            _logger = logger;
            _sentezCurrentAccountQueryService = sentezCurrentAccountQueryService;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpGet("currentaccount")]
        public async Task<IActionResult> GetCurrentAccount()
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  detayları istendi.");
            var result = await _sentezCurrentAccountQueryService.GetCurrentAccountCodeAndName();
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  detayları başarıyla getirildi.");
            return Ok(result);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Hammadde giriş listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet hammadde giriş kaydı getirildi.",
                result.Count());

            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Hammadde giriş detayları istendi. Kullanıcı={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            _logger.LogInformation(
                "Hammadde giriş detayları başarıyla getirildi.");

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {
            _logger.LogInformation(
                "Hammadde giriş detayları istendi. Kullanıcı={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithSearchDetails(StartDate, EndDate);

            _logger.LogInformation(
                "Hammadde giriş detayları başarıyla getirildi.");

            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Hammadde giriş kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Hammadde giriş kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Hammadde giriş kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateRawMaterialIntakesDto dto)
        {
            _logger.LogInformation(
                "Yeni hammadde giriş kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;
            dto.NetQuantity = dto.FilledQuantity - dto.EmptyQuantity;
            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Hammadde giriş kaydı başarıyla eklendi.");

            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateRawMaterialIntakesDto dto)
        {
            _logger.LogInformation(
                "Hammadde giriş kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;
            dto.NetQuantity = dto.FilledQuantity - dto.EmptyQuantity;
            await _service.Update(dto);

            _logger.LogInformation(
                "Hammadde giriş kaydı başarıyla güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpPost("integrations")]
        [HttpPut("integrations")]   // 2. tartım güncelleme PUT ile gelecek
        [AllowAnonymous]
        public async Task<IActionResult> EsitSpwinProIntegrations([FromBody] CreateRawMaterialIntakeIntegrationsDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { status = "error", message = "Entegrasyon verisi boş geldi." });

                var expectedToken = _configuration["Integrations:EsitSpwin:RawMaterialToken"];
                if (string.IsNullOrWhiteSpace(dto.token) || dto.token != expectedToken)
                {
                    _logger.LogWarning("Geçersiz entegrasyon tokenı.");
                    return StatusCode(401, new { status = "error", message = "Geçersiz token." });
                }

                // İlk testlerde PUT'ta seq/seqnum1 nasıl geliyor gör
                _logger.LogInformation(
                    "SPWIN {Method} seq={Seq} seqnum1={Seq1} ticket={Ticket} plate={Plate} w1={W1} w2={W2} net={Net}",
                    Request.Method, dto.Seq, dto.SeqNum1, dto.TicketNo, dto.Plate, dto.Weight1, dto.Weight2, dto.Net);

                var tr = new CultureInfo("tr-TR");
                DateTime? Parse(string s) =>
                    DateTime.TryParse(s, tr, DateTimeStyles.None, out var d) ? d : (DateTime?)null;

                var weighTime1 = Parse(dto.WeighTime1) ?? DateTime.Now;
                var weighTime2 = Parse(dto.WeighTime2) ?? weighTime1;

                // 2. tartımda 1. tartımın seq'i seqnum1'de gelir
                var lookupSeq = dto.SeqNum1 ?? dto.Seq;
                var existing = await _service.GetByExternalSeq(lookupSeq);

                decimal? net = dto.Net.HasValue ? Convert.ToDecimal(dto.Net.Value) : (decimal?)null;

                if (existing == null)
                {
                    var createDto = new CreateRawMaterialIntakesDto
                    {
                        ExternalSeq = lookupSeq,   // entity ve DTO'ya yeni kolon (long)

                        WaybillNo = dto.WaybillNo ?? string.Empty,
                        CurrentAccountName = dto.FirmName ?? string.Empty,
                        TruckPlate = dto.Plate ?? string.Empty,

                        WaybillQuantity = decimal.TryParse(dto.NetValPrevious, NumberStyles.Any, tr, out var np) ? np : 0m,
                        NetQuantity = net ?? 0m,
                        FilledQuantity = dto.FillingVal.HasValue ? Convert.ToDecimal(dto.FillingVal.Value) : 0m,
                        EmptyQuantity = dto.Weight1.HasValue ? Convert.ToDecimal(dto.Weight1.Value) : 0m,

                        ReceiptDate = weighTime1,
                        ScaleHours = weighTime2.TimeOfDay,

                        AppUserId = 37,
                        DepartmentId = 13,
                        ShiftId = 1,
                        InsertDate = DateTime.Now
                    };

                    await _service.Add(createDto);
                }
                else
                {
                    var updateDto = _mapper.Map<UpdateRawMaterialIntakesDto>(existing);

                    updateDto.NetQuantity = net ?? existing.NetQuantity;
                    updateDto.ScaleHours = weighTime2.TimeOfDay;
                    if (dto.FillingVal.HasValue)
                        updateDto.FilledQuantity = Convert.ToDecimal(dto.FillingVal.Value);
                    updateDto.UpdateDate = DateTime.Now;

                    await _service.Update(updateDto);
                }

                _logger.LogInformation("ESİT entegrasyonu başarılı. Fiş No: {TicketNo}, Plaka: {Plate}", dto.TicketNo, dto.Plate);
                return Ok(new { status = "success" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ESİT entegrasyonunda hata oluştu.");
                return Ok(new { status = "error", message = ex.Message });
            }
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Hammadde giriş kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Hammadde giriş kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}