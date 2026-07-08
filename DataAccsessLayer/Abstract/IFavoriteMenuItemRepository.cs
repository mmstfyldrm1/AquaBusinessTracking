using DTOLayer.Dtos.UserDashboardDtos;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IFavoriteMenuItemRepository
    {
        public Task<List<DB_FavoriteMenuItem>> GetFavoriteMenuItemsByUserIdAsync(int userId);

        public Task<bool> AddFavorite(UserDashboardAddFavoriteModuleDto dto);
    }

}
