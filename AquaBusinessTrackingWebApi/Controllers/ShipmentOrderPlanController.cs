using BusinessLayer.Abstract;
using DTOLayer.Dtos.ShipmentOrderPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentOrderPlanController : ControllerBase
    {
        private readonly ILogger<ShipmentOrderPlanController> _logger;
        readonly IShipmentOrderPlanService _shipmentOrderPlanService;

        public ShipmentOrderPlanController(ILogger<ShipmentOrderPlanController> logger, IShipmentOrderPlanService shipmentOrderPlanService)
        {
            _logger = logger;
            _shipmentOrderPlanService = shipmentOrderPlanService;
        }

        [HttpGet("getalll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var shipmentOrderPlans = await _shipmentOrderPlanService.GetList();
                return Ok(shipmentOrderPlans);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving shipment order plans.");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            try
            {
                var shipmentOrderPlans = await _shipmentOrderPlanService.GetWithDetails();
                return Ok(shipmentOrderPlans);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving shipment order plan details.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var shipmentOrderPlan = await _shipmentOrderPlanService.GetById(id);
                if (shipmentOrderPlan == null)
                {
                    return NotFound();
                }
                return Ok(shipmentOrderPlan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving shipment order plan with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateShipmentOrderPlanDto shipmentOrderPlan)
        {
            try
            {
                if (shipmentOrderPlan == null)
                {
                    return BadRequest("Shipment order plan is null.");
                }
                var result = await _shipmentOrderPlanService.Add(shipmentOrderPlan);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new shipment order plan.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShipmentOrderPlanDto shipmentOrderPlan)
        {
            try
            {
                if (shipmentOrderPlan == null)
                {
                    return BadRequest("Shipment order plan is null.");
                }
                shipmentOrderPlan.RecId = id;
                await _shipmentOrderPlanService.Update(shipmentOrderPlan);
                return Ok("Shipment order plan updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the shipment order plan.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shipmentOrderPlanService.Delete(id);
                return Ok("Shipment order plan deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the shipment order plan with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
