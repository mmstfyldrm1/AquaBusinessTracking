using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ChemicalSupplierProductsRepository : GenericRepository<DB_ChemicalSupplierProducts>, IChemicalSupplierProductsRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public ChemicalSupplierProductsRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_ChemicalSupplierProducts>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_ChemicalSupplierProducts>> GetWithDetails()
        {
            return await _context.Db_ChemicalSupplierProducts
                       .Include(x => x.Shift)
                       .Include(x => x.AppUser)
                       .ToListAsync();
        }
    }
}
