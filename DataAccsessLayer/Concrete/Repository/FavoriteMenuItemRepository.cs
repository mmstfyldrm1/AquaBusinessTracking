using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class FavoriteMenuItemRepository : GenericRepository<DB_FavoriteMenuItem>, IFavoriteMenuItemRepository
    {
        private readonly AquaBusinessTrackingContext _context;

        public FavoriteMenuItemRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_FavoriteMenuItem>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<bool> AddFavorite(DB_FavoriteMenuItem dto)
        {
            if (dto == null)
            {
                return false;
            }

            var existingEntity = await _context.Db_FavoriteMenuItem
                .FirstOrDefaultAsync(x =>
                    x.AppUserId == dto.AppUserId &&
                    x.Url == dto.Url);

            if (existingEntity != null)
            {
                existingEntity.RecId = dto.RecId;
                existingEntity.InUse = 1;
                existingEntity.DisplayOrder = dto.DisplayOrder;
                existingEntity.Controller = dto.Controller;
                existingEntity.Url = dto.Url;
                existingEntity.DepartmentId = dto.DepartmentId;


                var result = _context.Update(dto);

            }
            else
            {
                var result = await _context.AddAsync(dto);
            }


            return true;
        }

        public async Task<List<DB_FavoriteMenuItem>> GetFavoriteMenuItemsByUserIdAsync(int userId)
        {
            return await _context.Db_FavoriteMenuItem
                .Where(x => x.AppUserId == userId)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
        }
    }
}
