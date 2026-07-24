using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class DepartmentRepository : GenericRepository<DB_Department>, IDepartmentRepository
    {
        public DepartmentRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_Department>> logger) : base(context, logger)
        {
        }
    }
}
