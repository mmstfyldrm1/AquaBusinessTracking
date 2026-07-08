using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WaterPreparationAndConsumptionManager : GenericManager<DB_WaterPreparationAndConsumption, WaterPreparationAndConsumptionDto, CreateWaterPreparationAndConsumptionDto, UpdateWaterPreparationAndConsumptionDto>, IWaterPreparationAndConsumptionService
    {
        private readonly IWaterPreparationAndConsumptionRepository _repo;
        public WaterPreparationAndConsumptionManager(IUnitOfWork uow, IMapper mapper, IWaterPreparationAndConsumptionRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<WaterPreparationAndConsumptionDto>> GetPreviousDay()
        {
            var entities = await _repo.GetPreviousDay();
            var dtos = _mapper.Map<List<WaterPreparationAndConsumptionDto>>(entities);
            return dtos;
        }

        public async Task<List<WaterPreparationAndConsumptionDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<WaterPreparationAndConsumptionDto>>(entities);
            return dtos;
        }


    }
}
