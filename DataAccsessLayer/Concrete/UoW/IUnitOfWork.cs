using DataAccsessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.UoW
{
    public interface IUnitOfWork: IDisposable
    {
        ISalesScaleRepository SalesScale { get; }

        IElectricShiftWorkRepository ElectricShiftWork  { get; }

        IBoilerSteamFeedWaterCondensateDataRepository BoilerSteamFeedWaterCondensateDataRepository { get; }

        IGenericRepository<T> Repository<T>() where T : class;

        IBasinRepository Basin { get; }

        IDepartmentRepository Department { get; }
        IBasinMeasurementRepository BasinMeasurement { get; }

        IShiftRepository Shift { get; } 



        Task SaveChangesAsync();
    }
}
