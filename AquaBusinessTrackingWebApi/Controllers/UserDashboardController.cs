using BusinessLayer.Abstract;
using DTOLayer.Dtos.UserDashboardDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserDashboardController : ControllerBase
    {
        private readonly IFavoriteMenuItemService _favoriteMenu;

        public UserDashboardController(IFavoriteMenuItemService favoriteMenu)
        {
            _favoriteMenu = favoriteMenu;
        }


        [HttpGet("userDashboard/{userId}")]
        public async Task<IActionResult> UserDashboard(int userId)
        {

            if (userId < 0)
            {
                return Unauthorized();
            }
            var favoriteMenuItems = await _favoriteMenu.GetFavoriteMenuItemsByUserIdAsync(userId);

            return Ok(favoriteMenuItems);
        }

        [HttpPost("addFavorite")]
        public async Task<IActionResult> AddFavorite(UserDashboardAddFavoriteModuleDto dto)
        {
            var result = await _favoriteMenu.AddFavorite(dto);

            if (!result)
                return BadRequest("Bu modül zaten favorilerde.");

            return Ok();
        }
    }
}
