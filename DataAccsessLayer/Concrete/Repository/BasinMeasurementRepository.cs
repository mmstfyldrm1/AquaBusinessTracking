using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BasinMeasurementRepository : GenericRepository<DB_BasinMeasurement>, IBasinMeasurementRepository
    {
        public BasinMeasurementRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
