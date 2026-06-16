using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ShiftRepository : GenericRepository<DB_Shift>, IShiftRepository
    {
        public ShiftRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
