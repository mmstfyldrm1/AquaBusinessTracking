using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.Dtos.SalesScale;
using DTOLayer.Dtos.SalesScaleDtos.EsitIntegrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesScaleController : ControllerBase
    {
        private readonly ISalesScaleService _salesScaleService;
        private readonly ILogger<SalesScaleController> _logger;
        private readonly ISentezCurrentAccountQueryService _sentezCurrentAccountQueryService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public SalesScaleController(ISalesScaleService salesScaleService, ILogger<SalesScaleController> logger, ISentezCurrentAccountQueryService sentezCurrentAccountQueryService, IConfiguration configuration, IMapper mapper)
        {
            _salesScaleService = salesScaleService;
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

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation("Satış kantar listesi istendi. Kullanıcı={User}", User?.Identity?.Name);
            var result = await _salesScaleService.GetList();
            _logger.LogInformation("{Count} adet satış kantar kaydı getirildi.", result.Count());
            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation("Satış kantar detayları istendi.");
            var result = await _salesScaleService.GetWithDetails();
            _logger.LogInformation("Satış kantar detayları başarıyla getirildi.");
            return Ok(result);
        }

        [HttpGet("last30days")]
        public async Task<IActionResult> GetWithLast30Days()
        {
            _logger.LogInformation("Satış kantar son 30 gün detayları istendi.");
            var result = await _salesScaleService.GetWithLast30Days();
            _logger.LogInformation("Satış kantar son 30 gün detayları başarıyla getirildi.");

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWithSearchDetails([FromQuery] DateTime StartDate, [FromQuery] DateTime EndDate)
        {
            _logger.LogInformation("Satış kantar Detay Sayfası {StartDate} - {EndDate} istendi.", StartDate, EndDate);
            var result = await _salesScaleService.GetWithSearchDetails(StartDate, EndDate);

            _logger.LogInformation("Satış kantar Detay Sayfası {StartDate} - {EndDate} başarıyla getirildi.", StartDate, EndDate);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Satış kantar kaydı getiriliyor. Id={Id}", id);

            var result = await _salesScaleService.GetById(id);
            if (result == null)
            {
                _logger.LogWarning("Satış kantar kaydı bulunamadı. Id={Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Satış kantar kaydı bulundu. Id={Id}", id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateSalesScaleDto dto)
        {
            _logger.LogInformation("Yeni satış kantar kaydı ekleniyor. Kullanıcı={User}", User?.Identity?.Name);
            dto.InsertDate = DateTime.Now;
            dto.ScaleDate = DateTime.Now;
            dto.ScaleGap = (int)(dto.ScaleQuantity - dto.DeliveryQuantity);

            await _salesScaleService.Add(dto);
            _logger.LogInformation("Satış kantar kaydı başarıyla eklendi.");

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateSalesScaleDto dto)
        {
            _logger.LogInformation("Satış kantar kaydı güncelleniyor.");
            dto.UpdateDate = DateTime.Now;
            dto.ScaleGap = (int)(dto.ScaleQuantity - dto.DeliveryQuantity);
            await _salesScaleService.Update(dto);
            _logger.LogInformation("Satış kantar kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning("Satış kantar kaydı siliniyor. Id={Id}, Kullanıcı={User}", id, User?.Identity?.Name);
            await _salesScaleService.Delete(id);
            _logger.LogWarning("Satış kantar kaydı silindi. Id={Id}, Kullanıcı={User}", id, User?.Identity?.Name);
            return Ok();
        }

        [HttpPost("integrations")]
        [HttpPut("integrations")]
        [AllowAnonymous]
        public async Task<IActionResult> EsitSpwinProIntegrations([FromBody] CreateSalesScaleIntegrationsDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { status = "error", message = "Entegrasyon verisi boş geldi." });

                var expectedToken = _configuration["Integrations:EsitSpwin:Token"];
                if (string.IsNullOrEmpty(dto.token) || dto.token != expectedToken)
                    return StatusCode(401, new { status = "error", message = "Geçersiz token." });

                // İlk testte gelen body'yi logla, PUT'ta seq/seqnum1 nasıl geliyor gör
                _logger.LogInformation("SPWIN {Method} seq={Seq} seqnum1={Seq1} ticket={Ticket}",
                    Request.Method, dto.Seq, dto.SeqNum1, dto.TicketNo);

                var tr = new CultureInfo("tr-TR");
                DateTime? Parse(string s) =>
                    DateTime.TryParse(s, tr, DateTimeStyles.None, out var d) ? d : (DateTime?)null;

                var w1 = Parse(dto.WeighTime1);
                var w2 = Parse(dto.WeighTime2);

                // 2. tartımda 1. tartımın seq'i seqnum1'de gelir
                var lookupSeq = dto.SeqNum1 ?? dto.Seq;
                var existing = await _salesScaleService.GetByExternalSeq(lookupSeq); // yazman gerekecek

                decimal? net = dto.Net.HasValue ? Convert.ToDecimal(dto.Net.Value) : (decimal?)null;

                if (existing == null)
                {
                    var createDto = new CreateSalesScaleDto
                    {
                        ExternalSeq = lookupSeq,            // entity'ye yeni kolon ekle (long)
                        ScaleDate = w1 ?? DateTime.Now,
                        ReceiptDate = DateTime.Now,
                        ScaleHours = w2 ?? w1 ?? DateTime.Now,
                        ScaleNo = (decimal)dto.TicketNo,
                        DeliveryNumber = dto.WaybillNo ?? string.Empty,
                        CurrentAccountName = dto.FirmName ?? string.Empty,
                        TruckPlate = dto.Plate ?? string.Empty,
                        AppUserId = 37,
                        DeliveryQuantity = decimal.TryParse(dto.NetValPrevious, NumberStyles.Any, tr, out var np) ? np : 0m,
                        ScaleQuantity = net ?? 0m,
                        ScaleGap = dto.LossVal.HasValue ? (int?)Math.Round(dto.LossVal.Value) : null,
                        GapSuperVisiorId = 0,
                        GapDesicion = dto.DbaMsg ?? string.Empty,
                        InsertDate = DateTime.Now,
                        DepartmentId = 13,
                        ShiftId = 1
                    };
                    await _salesScaleService.Add(createDto);
                }
                else
                {
                    var updateDto = _mapper.Map<UpdateSalesScaleDto>(existing);

                    updateDto.ScaleHours = w2 ?? existing.ScaleHours;
                    updateDto.ScaleQuantity = net ?? existing.ScaleQuantity;
                    updateDto.ScaleGap = dto.LossVal.HasValue ? (int?)Math.Round(dto.LossVal.Value) : existing.ScaleGap;
                    updateDto.UpdateDate = DateTime.Now;

                    await _salesScaleService.Update(updateDto);
                }

                return Ok(new { status = "success" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SPWIN entegrasyon hatası");
                return Ok(new { status = "error", message = ex.Message });
            }
        }
    }
}