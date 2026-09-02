using BusinessLayer.Abstract;
using DTOLayer.Dtos.ShipmentOrderPlanDtos.ShipmentOrderPlanDetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentOrderPlanDetailController : ControllerBase
    {
        private readonly ILogger<ShipmentOrderPlanDetailController> _logger;
        private readonly IShipmentOrderPlanDetailService _shipmentOrderPlanDetailService;

        public ShipmentOrderPlanDetailController(ILogger<ShipmentOrderPlanDetailController> logger, IShipmentOrderPlanDetailService shipmentOrderPlanDetailService)
        {
            _logger = logger;
            _shipmentOrderPlanDetailService = shipmentOrderPlanDetailService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _shipmentOrderPlanDetailService.GetList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving shipment order plan details.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _shipmentOrderPlanDetailService.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving shipment order plan detail with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("getbyplanid/{shipmentOrderPlanId}")]
        public async Task<IActionResult> GetByShipmentOrderPlanId(int shipmentOrderPlanId)
        {
            try
            {
                var result = await _shipmentOrderPlanDetailService.GetByShipmentOrderPlanId(shipmentOrderPlanId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving shipment order plan details with ShipmentOrderPlanId {shipmentOrderPlanId}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateShipmentOrderPlanDetailDto shipmentOrderPlanDetail)
        {
            try
            {
                if (shipmentOrderPlanDetail == null)
                {
                    return BadRequest("Shipment order plan detail is null.");
                }
                await _shipmentOrderPlanDetailService.Add(shipmentOrderPlanDetail);
                return Ok("Kayıt  Başarılı");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new shipment order plan detail.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }


        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateShipmentOrderPlanDetailDto shipmentOrderPlanDetail)
        {
            try
            {
                if (shipmentOrderPlanDetail == null)
                {
                    return BadRequest("Shipment order plan detail is null.");
                }
                await _shipmentOrderPlanDetailService.Update(shipmentOrderPlanDetail);
                return Ok("Güncelleme Başarılı");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the shipment order plan detail.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingDetail = await _shipmentOrderPlanDetailService.GetById(id);
                if (existingDetail == null)
                {
                    return NotFound();
                }
                await _shipmentOrderPlanDetailService.Delete(id);
                return Ok("Silme Başarılı");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the shipment order plan detail with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
