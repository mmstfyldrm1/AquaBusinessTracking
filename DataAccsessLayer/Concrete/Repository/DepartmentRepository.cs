using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.Repository
{
    public class DepartmentRepository : GenericRepository<DB_Department>, IDepartmentRepository
    {
        public DepartmentRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
