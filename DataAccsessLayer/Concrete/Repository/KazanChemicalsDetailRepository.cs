using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class KazanChemicalsDetailRepository : GenericRepository<DB_KazanChemicalsDetail>, IKazanChemicalsDetailRepository
    {
        public KazanChemicalsDetailRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
