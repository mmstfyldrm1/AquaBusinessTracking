using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IRawMaterialIntakeRepository : IGenericRepository<DB_RawMaterialIntake>
    {
        public Task<List<DB_RawMaterialIntake>> GetWithDetails();
    }
}
