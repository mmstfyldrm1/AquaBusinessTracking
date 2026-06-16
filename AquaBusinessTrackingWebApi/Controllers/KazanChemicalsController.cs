using BusinessLayer.Abstract;
using DTOLayer.Dtos.KazanDtos.KazanDetailDtos;
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
        private readonly IKazanChemicalsDetailService _kazanDetail;

        public KazanChemicalsController(IKazanChemicalsHeadService kazanHead, IKazanChemicalsDetailService kazanDetail)
        {
            _kazanHead = kazanHead;
            _kazanDetail = kazanDetail;
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


        [HttpGet("{kazanHeadId}/kazanDetail")]
        public async Task<IActionResult> GetKazanDetails(int kazanHeadId)
        {
            var all = await _kazanDetail.GetList();
            var result = all.Where(x => x.KazanChemicalsHeadId == kazanHeadId).ToList();
            return Ok(result);
        }

        [HttpPost("{kazanHeadId}/kazanDetail")]
        public async Task<IActionResult> AddKazanDetail(int kazanHeadId, [FromBody] CreateKazanChemicalsDetailDto dto)
        {
            dto.KazanChemicalsHeadId = kazanHeadId;
            await _kazanDetail.Add(dto);
            return Ok();
        }

        [HttpPut("{kazanHeadId}/kazanDetail")]
        public async Task<IActionResult> UpdateKazanDetail(int kazanHeadId, [FromBody] UpdateKazanChemicalsDetailDto dto)
        {
            await _kazanDetail.Update(dto);
            return Ok();
        }

        [HttpDelete("{kazanHeadId}/kazanDetail/{kazanDetailId}")]
        public async Task<IActionResult> DeleteKazanDetail(int kazanHeadId, int kazanDetailId)
        {
            await _kazanDetail.Delete(kazanDetailId);
            return Ok();
        }
    }
}
