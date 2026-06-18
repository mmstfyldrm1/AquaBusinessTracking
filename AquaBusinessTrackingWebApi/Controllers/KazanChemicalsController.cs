using BusinessLayer.Abstract;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KazanChemicalsController : ControllerBase
    {
        private readonly IKazanChemicalsHeadService _kazanHead;


        public KazanChemicalsController(IKazanChemicalsHeadService kazanHead)
        {
            _kazanHead = kazanHead;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _kazanHead.GetList());

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails() =>
            Ok(await _kazanHead.GetWithDetails());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _kazanHead.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateKazanChemicalsHeadDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _kazanHead.Add(dto);

            var all = await _kazanHead.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            return Ok(last);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateKazanChemicalsHeadDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _kazanHead.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _kazanHead.Delete(id);
            return Ok();
        }


    }
}
