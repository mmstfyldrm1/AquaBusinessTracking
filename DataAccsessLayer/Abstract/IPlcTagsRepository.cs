using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IPlcTagsRepository : IGenericRepository<DB_PlcTags>
    {
        public Task<List<DB_PlcTags>> GetByMachineName();
    }
}
