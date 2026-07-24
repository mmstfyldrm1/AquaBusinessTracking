using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IIncomingGoodsTrackingRepository : IGenericRepository<DB_IncomingGoodsTracking>
    {
        Task<List<DB_IncomingGoodsTracking>> GetWithDetails();
    }
}
