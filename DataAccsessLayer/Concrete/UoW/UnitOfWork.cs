using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.Repository;
using Microsoft.Extensions.Logging;


namespace DataAccsessLayer.Concrete.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AquaBusinessTrackingContext _context;
        private readonly ILoggerFactory _loggerFactory;

        public UnitOfWork(AquaBusinessTrackingContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var logger = _loggerFactory.CreateLogger<GenericRepository<T>>();

            return new GenericRepository<T>(
                _context,
                logger);
        }







        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public void Dispose() => _context.Dispose();
    }
}
