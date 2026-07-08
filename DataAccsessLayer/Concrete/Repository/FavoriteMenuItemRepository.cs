using DataAccsessLayer.Abstract;
using DTOLayer.Dtos.UserDashboardDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class FavoriteMenuItemRepository : IFavoriteMenuItemRepository
    {
        private readonly AquaBusinessTrackingContext _context;

        public FavoriteMenuItemRepository(AquaBusinessTrackingContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFavorite(UserDashboardAddFavoriteModuleDto dto)
        {
            if (dto == null)
            {
                return false;
            }

            var existingEntity = await _context.Db_FavoriteMenuItem
                .FirstOrDefaultAsync(x =>
                    x.AppUserId == dto.AppUserId &&
                    x.ModuleId == dto.ModuleId);

            if (existingEntity != null)
            {
                existingEntity.InUse = 1;
                existingEntity.DisplayOrder = dto.DisplayOrder;
                existingEntity.Url = dto.Url;
                existingEntity.DepartmentId = dto.DepartmentId;

                _context.Db_FavoriteMenuItem.Update(existingEntity);
            }
            else
            {
                var entity = new DB_FavoriteMenuItem
                {
                    AppUserId = dto.AppUserId,
                    ModuleId = dto.ModuleId,
                    DisplayOrder = dto.DisplayOrder,
                    Url = dto.Url,
                    DepartmentId = dto.DepartmentId,
                    InUse = 1
                };

                await _context.Db_FavoriteMenuItem.AddAsync(entity);
            }

            var affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<List<DB_FavoriteMenuItem>> GetFavoriteMenuItemsByUserIdAsync(int userId)
        {
            return await _context.Db_FavoriteMenuItem
                .Where(x => x.AppUserId == userId && x.InUse == 1)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }
    }
}
