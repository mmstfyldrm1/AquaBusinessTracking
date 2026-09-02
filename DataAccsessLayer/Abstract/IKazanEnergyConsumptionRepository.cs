using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IKazanEnergyConsumptionRepository : IGenericRepository<DB_KazanEnergyConsumption>
    {
        public Task<List<DB_KazanEnergyConsumption>> GetWithDetails();
    }
}
