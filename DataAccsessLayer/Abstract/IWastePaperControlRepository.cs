using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IWastePaperControlRepository : IGenericRepository<DB_WastePaperControl>
    {
        public Task<List<DB_WastePaperControl>> GetWithDetails();

        public Task<List<DB_WastePaperControl>> GetPreviousDay();
    }
}
