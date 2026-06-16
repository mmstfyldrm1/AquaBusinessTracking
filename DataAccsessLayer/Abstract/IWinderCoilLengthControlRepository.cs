using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IWinderCoilLengthControlRepository : IGenericRepository<DB_WinderCoilLengthControl>
    {
        public Task<List<DB_WinderCoilLengthControl>> GetWithDetails();
    }
}
