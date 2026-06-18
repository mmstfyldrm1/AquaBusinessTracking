using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IDoughPreparationHeadRepository : IGenericRepository<DB_DoughPreparation>
    {
        public Task<List<DB_DoughPreparation>> GetWithDetails();

        public Task<List<DB_DoughPreparation>> GetPreviousDay();
    }
}
