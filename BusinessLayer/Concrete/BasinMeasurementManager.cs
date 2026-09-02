using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using EntityLayer.Concrete;


namespace BusinessLayer.Concrete
{
    public class BasinMeasurementManager : GenericManager<DB_BasinMeasurement, BasinMeasurementDto, CreateBasinMeasurementDto, UpdateBasinMeasurementDto>, IBasinMeasurementService
    {
        private readonly IBasinMeasurementRepository _repo;
        public BasinMeasurementManager(IUnitOfWork uow, IMapper mapper, IBasinMeasurementRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<BasinMeasurementDto>> GetWithDetails()
        {
            var list = await _repo.GetWithDetails();
            var mappedList = _mapper.Map<List<BasinMeasurementDto>>(list);
            return mappedList;
        }

        public async Task<List<BasinMeasurementDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {
            var entities = await _repo.GetWithSearchDetails(StartDate, EndDate);
            var dtos = _mapper.Map<List<BasinMeasurementDto>>(entities);
            return dtos;
        }


    }
}
