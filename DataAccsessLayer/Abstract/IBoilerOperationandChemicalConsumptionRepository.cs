using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBoilerOperationandChemicalConsumptionRepository : IGenericRepository<DB_BoilerOperationandChemicalConsumption>
    {
        public Task<List<DB_BoilerOperationandChemicalConsumption>> GetWithDetails();

        public Task<List<DB_BoilerOperationandChemicalConsumption>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate);


    }
}
