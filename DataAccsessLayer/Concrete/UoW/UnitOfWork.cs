using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.Repository;


namespace DataAccsessLayer.Concrete.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AquaBusinessTrackingContext _context;

        public UnitOfWork(AquaBusinessTrackingContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
        public ISalesScaleRepository SalesScale => new SalesScaleRepository(_context);

        public IElectricShiftWorkRepository ElectricShiftWork => new ElectricShiftWorkRepository(_context);

        public IBoilerSteamFeedWaterCondensateDataRepository BoilerSteamFeedWaterCondensateDataRepository => new BoilerSteamFeedWaterCondensateDataRepository(_context);

        public IBasinRepository Basin => new BasinRepository(_context);

        public IBasinMeasurementRepository BasinMeasurement => new BasinMeasurementRepository(_context);

        public IDepartmentRepository Department => new DepartmentRepository(_context);

        public IShiftRepository Shift => new ShiftRepository(_context);





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
