using DataAccsessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AquaBusinessTrackingContext _context;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(
            AquaBusinessTrackingContext context,
            ILogger<GenericRepository<T>> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public async Task TAdd(T entity)
        {
            if (entity == null)
            {
                _logger.LogWarning("Add işlemi başarısız. Entity null. ({Entity})", typeof(T).Name);
                throw new ArgumentNullException(nameof(entity));
            }

            _logger.LogInformation("Entity ekleniyor. ({Entity})", typeof(T).Name);

            await _context.Set<T>().AddAsync(entity);

            _logger.LogInformation("Entity eklendi (SaveChanges bekleniyor). ({Entity})", typeof(T).Name);
        }

        public async Task TDelete(T entity)
        {
            if (entity == null)
            {
                _logger.LogWarning("Delete işlemi başarısız. Entity null. ({Entity})", typeof(T).Name);
                throw new ArgumentNullException(nameof(entity));
            }

            _logger.LogInformation("Entity siliniyor. ({Entity})", typeof(T).Name);

            _context.Set<T>().Remove(entity);

            _logger.LogInformation("Entity silindi (SaveChanges bekleniyor). ({Entity})", typeof(T).Name);

            await Task.CompletedTask;
        }

        public async Task<List<T>> TGetAll()
        {
            _logger.LogInformation("Tüm {Entity} kayıtları getiriliyor.", typeof(T).Name);

            var result = await _context.Set<T>().ToListAsync();

            _logger.LogInformation("{Count} adet {Entity} getirildi.", result.Count, typeof(T).Name);

            return result;
        }

        public async Task<T> TGetById(int id)
        {
            _logger.LogInformation("{Entity} getiriliyor. Id={Id}", typeof(T).Name, id);

            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                _logger.LogWarning("{Entity} bulunamadı. Id={Id}", typeof(T).Name, id);
                throw new KeyNotFoundException($"{typeof(T).Name} bulunamadı.");
            }

            _logger.LogInformation("{Entity} bulundu. Id={Id}", typeof(T).Name, id);

            return entity;
        }

        public async Task TUpdate(T entity)
        {
            if (entity == null)
            {
                _logger.LogWarning("Update işlemi başarısız. Entity null. ({Entity})", typeof(T).Name);
                throw new ArgumentNullException(nameof(entity));
            }

            _logger.LogInformation("Entity güncelleniyor. ({Entity})", typeof(T).Name);

            _context.Set<T>().Update(entity);

            _logger.LogInformation("Entity güncellendi (SaveChanges bekleniyor). ({Entity})", typeof(T).Name);

            await Task.CompletedTask;
        }
    }
}