using DTOLayer.Dtos.UserDashboardDtos;

namespace BusinessLayer.Abstract
{
    public interface IFavoriteMenuItemService
    {
        public Task<List<UserDashboardFavoriteMenuDto>> GetFavoriteMenuItemsByUserIdAsync(int userId);

        public Task<bool> AddFavorite(UserDashboardAddFavoriteModuleDto dto);
    }
}
