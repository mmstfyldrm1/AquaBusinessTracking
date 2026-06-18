using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IPurificationChemicalsConsumptionRepository : IGenericRepository<DB_PurificationChemicalsConsumption>
    {
        public Task<List<DB_PurificationChemicalsConsumption>> GetWithDetails();

        public Task<List<DB_PurificationChemicalsConsumption>> GetPreviousDay();
    }
}
