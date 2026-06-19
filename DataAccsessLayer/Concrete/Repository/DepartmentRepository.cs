using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class DepartmentRepository : GenericRepository<DB_Department>, IDepartmentRepository
    {
        public DepartmentRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
