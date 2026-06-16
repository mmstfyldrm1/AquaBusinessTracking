using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class BasinMeasurementManager : GenericManager<DB_BasinMeasurement, BasinMeasurementDto, CreateBasinMeasurementDto, UpdateBasinMeasurementDto>, IBasinMeasurementService
    {
        public BasinMeasurementManager(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
