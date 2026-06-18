using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BoilerSteamFeedWaterCondensateDataManager : GenericManager<DB_BoilerSteamFeedWaterCondensateData, BoilerSteamFeedWaterCondensateDataDto, CreateBoilerSteamFeedWaterCondensateDataDto, UpdateBoilerSteamFeedWaterCondensateDataDto>, IBoilerSteamFeedWaterCondensateDataService
    {
        private readonly IBoilerSteamFeedWaterCondensateDataRepository _repository;
        public BoilerSteamFeedWaterCondensateDataManager(IUnitOfWork uow, IMapper mapper, IBoilerSteamFeedWaterCondensateDataRepository repository) : base(uow, mapper)
        {
            _repository = repository;
        }

        public async Task<List<BoilerSteamFeedWaterCondensateDataDto>> GetPreviousDay()
        {
            var data = await _repository.GetPreviousDay();
            return _mapper.Map<List<BoilerSteamFeedWaterCondensateDataDto>>(data);
        }

        public async Task<List<BoilerSteamFeedWaterCondensateDataDto>> GetWithDetails()
        {
            var data = await _repository.GetWithDetails();
            return _mapper.Map<List<BoilerSteamFeedWaterCondensateDataDto>>(data);
        }
    }
}
